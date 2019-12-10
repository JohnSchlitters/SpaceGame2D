using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int weaponnumber = 1;
    public Text UIWeaponText;
    public Text UIPlayerHPText;
    public Text UIPlayerRestart;
    
    public GameObject PulseCannonShot;
    public GameObject PlasmaLauncherShot;
    public GameObject EnergyBeamShot;
    public GameObject MissilePodShot;
    public GameObject explosionemitter;
    public GameObject playerShield;
    public Transform playerShieldLocation;
    public int pulseCount = 0;
    public int maxPulse = 1;
    public int plasmaCount = 0;
    public int maxPlasma = 1;
    public int energyCount = 0;
    public int maxEnergy = 1;
    public int missileCount = 0;
    public int maxMissile = 1;
    private int counttimer = 1;
    public float weaponCooldown = 0;
    public Transform playerPosition;
    public AudioClip playerFireA;
    public AudioClip playerFireB;
    public AudioClip playerFireC;
    public AudioClip playerFireD;
    public AudioClip PowerUp;
    public AudioClip BlowUp;
    private bool canFire;
    public static bool hasShield = false;
    public static bool isDead = false;
    public GameObject TextGameOver;
    public int playerHP;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
        Application.targetFrameRate = 144;
        playerHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        UIPlayerHPText.text = ("HP : " + playerHP);
        if (playerHP > 200)
        {
            playerHP = 200;
        }
        if (playerHP <= 0)
        {
            PlayerDeath();
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            if (playerPosition.transform.position.x > -10)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 4);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (playerPosition.transform.position.x < 10)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 4);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (weaponnumber == 1)
            {
                weaponnumber = 4;
            }
            else
            {
                weaponnumber--;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (weaponnumber == 4)
            {
                weaponnumber = 1;
            }
            else
            {
                weaponnumber++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            FirePlayerWeapon();
        }
        switch (weaponnumber)
        {
            case 1:
                UIWeaponText.text = "Weapon - Pulse Cannon";
                break;
            case 2:
                UIWeaponText.text = "Weapon - Plasma Launcher";
                break;
            case 3:
                UIWeaponText.text = "Weapon - Energy Beam";
                break;
            case 4:
                UIWeaponText.text = "Weapon - Missile Pod";
                break;
        }
        //pulse cannon controller
        if (!canFire && Time.time > weaponCooldown)
        {
            canFire = true;
        }

        if (pulseCount == maxPulse)
        {
            weaponCooldown = Time.time + 1f;
            pulseCount = 0;
        }
        //plasma weapon counter
        if (plasmaCount == maxPlasma)
        {
            weaponCooldown = Time.time + 1.5f;
            plasmaCount = 0;
        }
        //energy weapon controller
        if (energyCount == maxEnergy)
        {
            weaponCooldown = Time.time + 2f;
            energyCount = 0;
        }
        if (missileCount == maxMissile)
        {
            weaponCooldown = Time.time + 2f;
            missileCount = 0;
        }
    }

    void FirePlayerWeapon()
    {
        switch (weaponnumber)
        {
            case 1:
                FirePulseCannon();
                break;
            case 2:
                FirePlasmaLauncher();
                break;
            case 3:
                FireEnergyBeam();
                break;
            case 4:
                FireMissilePod();
                break;
        }
    }

    private void FirePulseCannon()
    {
        GameObject firedPulseShot = Instantiate(PulseCannonShot, playerPosition.position, playerPosition.rotation);
        AudioSource.PlayClipAtPoint(playerFireA, transform.position);
        firedPulseShot.name = "playerPulseShot";
        firedPulseShot.GetComponent<Rigidbody2D>().velocity = Vector2.up * 15f;;
        pulseCount++;
        weaponCooldown = Time.time + 0.1f;
        canFire = false;
    }

 
    private void FirePlasmaLauncher() 
    { 
        GameObject firedPlasmaShotL = Instantiate(PlasmaLauncherShot, playerPosition.position, playerPosition.rotation);
        GameObject firedPlasmaShotR = Instantiate(PlasmaLauncherShot, playerPosition.position, playerPosition.rotation);
        AudioSource.PlayClipAtPoint(playerFireB, transform.position); 
        firedPlasmaShotL.name = "playerPulseShotL";
        firedPlasmaShotR.name = "playerPulseShotR";
        firedPlasmaShotL.GetComponent<Rigidbody2D>().velocity = new Vector3(1f, 8f, 0f);
        firedPlasmaShotR.GetComponent<Rigidbody2D>().velocity = new Vector3(-1f, 8f, 0f);
        plasmaCount++; 
        weaponCooldown = Time.time + 0.3f; 
        canFire = false; 
    } 

    private void FireEnergyBeam()
    {
        GameObject firedPulseShot = Instantiate(EnergyBeamShot, playerPosition.position, playerPosition.rotation);
        AudioSource.PlayClipAtPoint(playerFireC, transform.position);
        firedPulseShot.name = "playerEnergyShot";
        firedPulseShot.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10f;;
        energyCount++;
        weaponCooldown = Time.time + 0.5f;
        canFire = false;
    }

    private void FireMissilePod()
    {
        GameObject launchedMissile = Instantiate(MissilePodShot, playerPosition.position, playerPosition.rotation);
        launchedMissile.name = "LaunchedMissile";
        launchedMissile.GetComponent<Rigidbody2D>().velocity = Vector2.up * 5f;;
        AudioSource.PlayClipAtPoint(playerFireD, transform.position);
        missileCount++;
        weaponCooldown = Time.time + 2f;
        canFire = false;
    }

    private void OnCollisionEnter2D(Collision2D EnemyProjectileCollide)
    {
        if (EnemyProjectileCollide.gameObject.CompareTag("EnemyPulse"))
        {
            playerHP -= 5;
            Destroy(EnemyProjectileCollide.gameObject);
            print("removed enemy pulse");
        }
        if (EnemyProjectileCollide.gameObject.CompareTag("EnemyPlasma"))
        {
            playerHP -= 10;
            Destroy(EnemyProjectileCollide.gameObject);
            print("removed enemy plasma");
        }
        
        if (EnemyProjectileCollide.gameObject.CompareTag("EnemyMissile"))
        {
            playerHP -= 15;
            Destroy(EnemyProjectileCollide.gameObject);
            print("removed enemy missile");
        }
        
        if (EnemyProjectileCollide.gameObject.CompareTag("EnemyBeam"))
        {
            playerHP -= 20;
            Destroy(EnemyProjectileCollide.gameObject);
            print("removed enemy beam");
        }
        
        // getting player powerups
        
        if (EnemyProjectileCollide.gameObject.CompareTag("PowerUpLaser"))
        {
            AudioSource.PlayClipAtPoint(PowerUp, transform.position); 
            maxEnergy++;
            Destroy(EnemyProjectileCollide.gameObject);
        }
        if (EnemyProjectileCollide.gameObject.CompareTag("PowerUpPlasma"))
        {
            AudioSource.PlayClipAtPoint(PowerUp, transform.position); 
            maxPlasma++;
            Destroy(EnemyProjectileCollide.gameObject);
        }
        if (EnemyProjectileCollide.gameObject.CompareTag("PowerUpPulse"))
        {
            AudioSource.PlayClipAtPoint(PowerUp, transform.position); 
            maxPulse++;
            Destroy(EnemyProjectileCollide.gameObject);
        }
        if (EnemyProjectileCollide.gameObject.CompareTag("PowerUpMissile"))
        {
            AudioSource.PlayClipAtPoint(PowerUp, transform.position); 
            maxMissile++;
            Destroy(EnemyProjectileCollide.gameObject);
        }
        if (EnemyProjectileCollide.gameObject.CompareTag("PowerUpHeal"))
        {
            AudioSource.PlayClipAtPoint(PowerUp, transform.position); 
            playerHP += 25;
            Destroy(EnemyProjectileCollide.gameObject);
        }
        if (EnemyProjectileCollide.gameObject.CompareTag("PowerUpShield"))
        {
            AudioSource.PlayClipAtPoint(PowerUp, transform.position);
            if (!hasShield)
            {
                GameObject playerShieldBonus = Instantiate(playerShield, playerShieldLocation.transform.position, playerShieldLocation.transform.rotation);
                playerShieldBonus.transform.SetParent(playerPosition);
                playerShieldBonus.name = "player shield";
                hasShield = true;
                Destroy(EnemyProjectileCollide.gameObject);
            }
            else if (hasShield)
            {
                PlayerShieldHP.shieldHP += 50;
                Destroy(EnemyProjectileCollide.gameObject);
            }

        }
    }

    public IEnumerator CountDown()
    {
        UIPlayerRestart.text = "5";
        yield return new WaitForSeconds(1);
        UIPlayerRestart.text = "4";
        yield return new WaitForSeconds(1);
        UIPlayerRestart.text = "3";
        yield return new WaitForSeconds(1);
        UIPlayerRestart.text = "2";
        yield return new WaitForSeconds(1);
        UIPlayerRestart.text = "1";
        yield return new WaitForSeconds(1);
        UIPlayerRestart.text = "Go!";
        yield return new WaitForSeconds(3);
        UIPlayerRestart.text = "";
    }
    private void PlayerDeath()
    {
        GameObject restartText = Instantiate(TextGameOver);
        UIPlayerRestart.text = "GAME OVER \n Press 'R' to Restart";
        isDead = true;
        restartText.name = "gameOver";
        print("Game Over, Man!");
        GameObject deadexplosionemitter = Instantiate(explosionemitter, gameObject.transform.position, gameObject.transform.rotation);
        deadexplosionemitter.name = "enemyexplosion";
        Destroy(gameObject);
        Destroy(deadexplosionemitter, 3.5f);
    }
}

