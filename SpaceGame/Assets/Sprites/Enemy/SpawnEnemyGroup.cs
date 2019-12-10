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
    public GameObject enemySuperGunShip;
    public GameObject enemyBeamShipA;
    public int randomvalue;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyLightShip1", 5f, 10.0f);
        InvokeRepeating("SpawnEnemyLightShip2", 25f, 10.0f);
        InvokeRepeating("SpawnEnemyHeavyShip1", 45f, 15.0f);
        InvokeRepeating("SpawnEnemyLightShip3", 85f, 12.5f);
        InvokeRepeating("SpawnEnemyHeavyShip2", 105f, 10.0f);
        InvokeRepeating("SpawnEnemyMissileShip1", 125f, 15.0f);
        InvokeRepeating("SpawnEnemySuperHeavy", 165f, 20.0f);
    }

    private void SpawnEnemyLightShip1() //wave 1
    {
        print("select 1, L gunship");
                GameObject enemyLightGunship = Instantiate(enemyGunShipA, enemySpawn.position, enemySpawn.rotation);
                enemyLightGunship.name = "enemyLightGunship";
                GameObject enemyLightGunship2 = Instantiate(enemyGunShipA, enemySpawn.position, enemySpawn.rotation);
                enemyLightGunship.name = "enemyLightGunship2";
    }
    private void SpawnEnemyLightShip2() //wave 2
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
    private void SpawnEnemyHeavyShip1() //wave 3
    {
        randomvalue = Random.Range(1, 3);

        switch (randomvalue)
        {
            case 1:
                print("select 1, H gunship");
                GameObject enemyLightGunship2 = Instantiate(enemyGunShipA, enemySpawn.position, enemySpawn.rotation);
                enemyLightGunship2.name = "enemyLightGunship";
                break;
            case 2:
                print("select 2, H gunship");
                GameObject enemyHeavyGunship = Instantiate(enemyGunShipB, enemySpawn.position, enemySpawn.rotation);
                enemyHeavyGunship.name = "enemyHeavyGunship";
                break;
            case 3:
                print("select 3, M MissileShip");
                GameObject enemyTorpedoShip = Instantiate(enemyMissileShip, enemySpawn.position, enemySpawn.rotation);
                enemyTorpedoShip.name = "enemyMissileGunship";
                break;
        }
        randomvalue = 0;
    }
    private void SpawnEnemyLightShip3() //wave 4
    {
        randomvalue = Random.Range(1, 2);
        if (randomvalue == 1)
        {
            print("select 1, L gunship");
            GameObject enemyLightGunship = Instantiate(enemyGunShipA, enemySpawn.position, enemySpawn.rotation);
            enemyLightGunship.name = "enemyLightGunship";
            GameObject enemyLightGunship2 = Instantiate(enemyGunShipA, enemySpawn.position, enemySpawn.rotation);
            enemyLightGunship2.name = "enemyLightGunship2";
            GameObject enemyLightGunship3 = Instantiate(enemyBeamShipA, enemySpawn.position, enemySpawn.rotation);
            enemyLightGunship3.name = "enemyBeamShip1";
        }
    }
    private void SpawnEnemyHeavyShip2() //wave 5
    {
                print("select 2, H gunship");
                GameObject enemyHeavyGunship = Instantiate(enemyGunShipB, enemySpawn.position, enemySpawn.rotation);
                enemyHeavyGunship.name = "enemyHeavyGunship";
                GameObject enemyHeavyGunship2 = Instantiate(enemyGunShipB, enemySpawn.position, enemySpawn.rotation);
                enemyHeavyGunship2.name = "enemyHeavyGunship2";
    }
    private void SpawnEnemyMissileShip1() //wave 6
    {
        print("select 3, M MissileShip");
        GameObject enemyTorpedoShip = Instantiate(enemyMissileShip, enemySpawn.position, enemySpawn.rotation);
        enemyTorpedoShip.name = "enemyMissileGunship";
    }
    private void SpawnEnemySuperHeavy() //wave 1
    {
        print("select 1, L gunship");
        GameObject enemySuperGunshipA = Instantiate(enemySuperGunShip, enemySpawn.position, enemySpawn.rotation);
        enemySuperGunshipA.name = "enemySuperGunShip";
    }
}
