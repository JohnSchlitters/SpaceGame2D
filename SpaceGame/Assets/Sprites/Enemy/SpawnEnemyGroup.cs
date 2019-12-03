using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemyGroup : MonoBehaviour
{
    public GameObject enemyGunShipA;
    public GameObject enemyGunShipB;
    public Transform enemySpawn;
    public GameObject enemyMissileShip;
    public int randomvalue;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyShip", 0f, 10.0f);
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemyShip()
    {
        randomvalue = Random.Range(1, 4);

        switch (randomvalue)
        {
            case 1:
                print("select 1, L gunship");
                GameObject enemyLightGunship = Instantiate(enemyGunShipA, enemySpawn.position, enemySpawn.rotation);
                enemyLightGunship.name = "enemyLightGunship";
                break;
            case 2:
                print("select 2, L gunship");
                GameObject enemyLightGunship2 = Instantiate(enemyGunShipA, enemySpawn.position, enemySpawn.rotation);
                enemyLightGunship2.name = "enemyLightGunship";
                break;
            case 3:
                print("select 3, H gunship");
                GameObject enemyHeavyGunship = Instantiate(enemyGunShipB, enemySpawn.position, enemySpawn.rotation);
                enemyHeavyGunship.name = "enemyHeavyGunship";
                break;
            case 4:
                print("select 4, L MissileShip");
                GameObject enemyTorpedoShip = Instantiate(enemyMissileShip, enemySpawn.position, enemySpawn.rotation);
                enemyTorpedoShip.name = "enemyMissileGunship";
                break;
        }
        randomvalue = 0;
    }
}
