using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemyHPmanagerLight : MonoBehaviour
{
    [SerializeField]
    public int enemyHPL;

    public GameObject explosionemitter;
    public GameObject mexplosionemitter;
    public GameObject powerupHeal;
    public GameObject powerupPulse;
    public GameObject powerupPlasma;
    public GameObject powerupEnergy;
    public GameObject powerupShield;
    public AudioClip BlowUp;
    
    public float waitTime = 10f;
    public ScoreKeeper getPlayerScoreStats;
    // Start is called before the first frame update
    void Start()
    {
        enemyHPL = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHPL <= 0)
        {
            DestroyShip();
        }
    }
    private void OnCollisionEnter2D(Collision2D enemyCollide2D)
    {
        if (enemyCollide2D.gameObject.CompareTag("PlayerPulse"))
        {
            enemyHPL -= 50;
            print("enemy took 50 damage");
            Destroy(enemyCollide2D.gameObject);
            print("removed pulse");
        }
        if (enemyCollide2D.gameObject.CompareTag("PlayerPlasma"))
        {
            enemyHPL -= 60;
            print("enemy took 60 damage");
            Destroy(enemyCollide2D.gameObject);
            print("removed plasma");
        }
        if (enemyCollide2D.gameObject.CompareTag("PlayerBeam"))
        {
            enemyHPL -= 500;
            print("enemy took  500 damage");
        }
        if (enemyCollide2D.gameObject.CompareTag("PlayerMissile"))
        {
            enemyHPL -= 100;
            print("enemy took  100 damage");
            Destroy(enemyCollide2D.gameObject);
            GameObject missileexplosionemitter = Instantiate(mexplosionemitter, gameObject.transform.position, gameObject.transform.rotation);
            missileexplosionemitter.name = "enemyexplosion";
            Destroy(missileexplosionemitter, 1f);
        }
    }

    private void DestroyShip()
    {
        int dropchance = UnityEngine.Random.Range(0,10);
        if (dropchance >= 8)
        {
            int itemchance = UnityEngine.Random.Range(0, 10);
            if (itemchance <= 6)
            {
                int typeChance = UnityEngine.Random.Range(1, 10);
                if (typeChance <= 6)
                {
                    GameObject HealDrop = Instantiate(powerupHeal, gameObject.transform.position, gameObject.transform.rotation);
                    HealDrop.name = "playerHeal";
                }
                GameObject Shield = Instantiate(powerupShield, gameObject.transform.position, gameObject.transform.rotation);
                Shield.name = "playerShiel";
            }

            if (itemchance > 6)
            {
                int poweruptype = UnityEngine.Random.Range(1, 3);
                switch (poweruptype)
                {
                    case 1:
                        GameObject PulseDrop = Instantiate(powerupPulse, gameObject.transform.position, gameObject.transform.rotation);
                        PulseDrop.name = "playerPulse";
                        break;
                    case 2:
                        GameObject PlasmaDrop = Instantiate(powerupPlasma, gameObject.transform.position, gameObject.transform.rotation);
                        PlasmaDrop.name = "playerPlasma";
                        break;
                    case 3:
                        GameObject EnergyDrop = Instantiate(powerupEnergy, gameObject.transform.position, gameObject.transform.rotation);
                        EnergyDrop.name = "playerEnergy";
                        break;
                }
            }
        }
        AudioSource.PlayClipAtPoint(BlowUp, transform.position); 
        ScoreKeeper.playerScore += (100 * ScoreKeeper.playerMultiplier);
        ScoreKeeper.playerKillCount++;
        GameObject deadexplosionemitter = Instantiate(explosionemitter, gameObject.transform.position, gameObject.transform.rotation);
        deadexplosionemitter.name = "enemyexplosion";
        Destroy(gameObject);
        Destroy(deadexplosionemitter, waitTime);
    }
}
