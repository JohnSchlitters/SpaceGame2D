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

    public GameObject pulseCannonShot;

    public GameObject plasmaLauncherShot;

    public GameObject energyBeamShot;

    public GameObject missilePodShot;

    private Transform playerPosition;
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

        if (Input.GetKeyDown(KeyCode.Space))
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

    void FirePulseCannon()
    {
        GameObject firedPulseShot = Instantiate(pulseCannonShot, playerPosition.position, playerPosition.rotation);
        firedPulseShot.name = "playerPulseShot";
        firedPulseShot.GetComponent<Rigidbody2D>().velocity = playerPosition.forward * 15f;
    }

    void FirePlasmaLauncher()
    {
        
    }

    void FireEnergyBeam()
    {
        
    }

    void FireMissilePod()
    {
        
    }
}

