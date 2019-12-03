using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int weaponnumber = 1;
    public Text UIWeaponText;
    
    public GameObject PulseCannonShot;
    public GameObject PlasmaLauncherShot;
    public GameObject EnergyBeamShot;
    public GameObject MissilePodShot;
    
    public int pulseCount = 0;
    public int maxPulse = 1;
    public int plasmaCount = 0;
    public int maxPlasma = 1;
    public int energyCount = 0;
    public int maxEnergy = 1;
    public int missileCount = 0;
    public int maxMissile = 1;
    public float weaponCooldown = 0;
    public Transform playerPosition;
    public Transform playerPlasmaL;
    public Transform playerPlasmaR;
    public AudioClip playerFireA;
    public AudioClip playerFireB;
    public AudioClip playerFireC;
    public AudioClip playerFireD;
    private bool canFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 3);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 3);
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
        GameObject firedPlasmaShotL = Instantiate(PlasmaLauncherShot, playerPlasmaL.position, playerPlasmaL.rotation * Quaternion.Euler (10f, 0f, 0f));
        GameObject firedPlasmaShotR = Instantiate(PlasmaLauncherShot, playerPlasmaR.position, playerPlasmaR.rotation * Quaternion.Euler (10f, 0f, 0f));
        AudioSource.PlayClipAtPoint(playerFireB, transform.position);
        firedPlasmaShotL.name = "playerPulseShotL";
        firedPlasmaShotR.name = "playerPulseShotR";
        firedPlasmaShotL.GetComponent<Rigidbody2D>().AddForce(350 * Vector2.up);
        firedPlasmaShotR.GetComponent<Rigidbody2D>().AddForce(350 * Vector2.up);

        //firedPlasmaShotL.GetComponent<Rigidbody2D>().velocity = (Vector2.up * 8);
        //firedPlasmaShotR.GetComponent<Rigidbody2D>().velocity = (Vector2.up * 8);
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
        AudioSource.PlayClipAtPoint(playerFireD, transform.position);
    }
}

