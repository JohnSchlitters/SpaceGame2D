using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class enemyHPmanagerHeavy : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyHPH;

    public GameObject explosionemitter;

    public float waitTime = 10f;
    public GameObject powerupHeal;
    public GameObject powerupPulse;
    public GameObject powerupPlasma;
    public GameObject powerupEnergy;
    public AudioClip BlowUp;
    //public ScoreKeeper getPlayerScoreStats;

    // Start is called before the first frame update
    void Start()
    {
        enemyHPH = 200;
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
    }

    private void DestroyShip()
    {
        int dropchance = UnityEngine.Random.Range(0,10);
        if (dropchance >= 8)
        {
            int itemchance = UnityEngine.Random.Range(0, 10);
            if (itemchance <= 3)
            {
                GameObject HealDrop = Instantiate(powerupHeal, gameObject.transform.position, gameObject.transform.rotation);
                HealDrop.name = "playerHeal";
            }

            if (itemchance > 3)
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
        ScoreKeeper.playerScore += (150 * ScoreKeeper.playerMultiplier);
        ScoreKeeper.playerKillCount++;
        GameObject deadexplosionemitter = Instantiate(explosionemitter, gameObject.transform.position, gameObject.transform.rotation);
        deadexplosionemitter.name = "enemyexplosion";
        Destroy(gameObject);
        Destroy(deadexplosionemitter, waitTime);
    }
}
