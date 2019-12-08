using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHPmanagerMissile : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyHPM;

    public GameObject explosionemitter;
    public GameObject mexplosionemitter;

    public float waitTime = 10f;
    public GameObject powerupPulse;
    public GameObject powerupPlasma;
    public GameObject powerupEnergy;
    public GameObject powerupMissile;
    public AudioClip BlowUp;
    //public ScoreKeeper getPlayerScoreStats;

    // Start is called before the first frame update
    void Start()
    {
        enemyHPM = 150;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHPM <= 0)
        {
            DestroyShip();
        }
    }

    private void OnCollisionEnter2D(Collision2D enemyCollide2D)
    {
        if (enemyCollide2D.gameObject.CompareTag("PlayerPulse"))
        {
            enemyHPM -= 50;
            print("enemy took 50 damage");
            Destroy(enemyCollide2D.gameObject);
            print("removed pulse");
        }

        if (enemyCollide2D.gameObject.CompareTag("PlayerPlasma"))
        {
            enemyHPM -= 60;
            print("enemy took 60 damage");
            Destroy(enemyCollide2D.gameObject);
            print("removed plasma");
        }

        if (enemyCollide2D.gameObject.CompareTag("PlayerBeam"))
        {
            enemyHPM -= 500;
            print("enemy took 500 damage");
        }
        if (enemyCollide2D.gameObject.CompareTag("PlayerMissile"))
        {
            enemyHPM -= 100;
            print("enemy took  100 damage");
            Destroy(enemyCollide2D.gameObject);
            GameObject missileexplosionemitter = Instantiate(mexplosionemitter, gameObject.transform.position, gameObject.transform.rotation);
            missileexplosionemitter.name = "enemyexplosion";
            Destroy(missileexplosionemitter, 1f);
        }
    }

    private void DestroyShip()
    {
        int dropchance = Random.Range(0,10);
        if (dropchance >= 5)
        {
           int poweruptype = Random.Range(1, 4);
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
                    case 4:
                        GameObject MissileDrop = Instantiate(powerupMissile, gameObject.transform.position, gameObject.transform.rotation);
                        MissileDrop.name = "playerEnergy";
                        break;
                }
        }
        AudioSource.PlayClipAtPoint(BlowUp, transform.position); 
        ScoreKeeper.playerScore += (150 * ScoreKeeper.playerMultiplier);
        ScoreKeeper.playerKillCount++;
        GameObject deadexplosionemitter = Instantiate(explosionemitter, gameObject.transform.position, gameObject.transform.rotation);
        deadexplosionemitter.name = "enemyexplosion";
        Destroy(gameObject);
        Destroy(deadexplosionemitter, waitTime);
    }
}