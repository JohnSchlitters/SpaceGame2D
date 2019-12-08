using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHPmanagerHeavy2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyHPH;

    public GameObject explosionemitter;
    public GameObject mexplosionemitter;
    public float waitTime = 10f;
    public GameObject powerupHeal;
    public GameObject powerupPulse;
    public GameObject powerupPlasma;
    public GameObject powerupEnergy;
    public GameObject powerupMissile;
    public AudioClip BlowUp;
    //public ScoreKeeper getPlayerScoreStats;

    // Start is called before the first frame update
    void Start()
    {
        enemyHPH = 300;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHPH <= 0)
        {
            DestroyShip();
        }
    }

    private void OnCollisionEnter2D(Collision2D enemyCollide2D)
    {
        if (enemyCollide2D.gameObject.CompareTag("PlayerPulse"))
        {
            enemyHPH -= 50;
            print("enemy took 50 damage");
            Destroy(enemyCollide2D.gameObject);
            print("removed pulse");
        }

        if (enemyCollide2D.gameObject.CompareTag("PlayerPlasma"))
        {
            enemyHPH -= 60;
            print("enemy took 60 damage");
            Destroy(enemyCollide2D.gameObject);
            print("removed plasma");
        }

        if (enemyCollide2D.gameObject.CompareTag("PlayerBeam"))
        {
            enemyHPH -= 500;
            print("enemy took 500 damage");
        }
        if (enemyCollide2D.gameObject.CompareTag("PlayerMissile"))
        {
            enemyHPH -= 100;
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
        if (dropchance >= 4)
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
        ScoreKeeper.playerScore += (300 * ScoreKeeper.playerMultiplier);
        ScoreKeeper.playerKillCount++;
        GameObject deadexplosionemitter = Instantiate(explosionemitter, gameObject.transform.position, gameObject.transform.rotation);
        GameObject deadexplosionemitter2 = Instantiate(explosionemitter, gameObject.transform.position, gameObject.transform.rotation);
        deadexplosionemitter.name = "enemyexplosion";
        deadexplosionemitter2.name = "enemyexplosion";
        Destroy(gameObject);
        Destroy(deadexplosionemitter, waitTime);
        Destroy(deadexplosionemitter2, waitTime);
    }
}

