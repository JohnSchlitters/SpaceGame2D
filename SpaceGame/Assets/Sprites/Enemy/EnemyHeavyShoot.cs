using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class EnemyHeavyShoot : MonoBehaviour
{
    public GameObject EPlasmaCannonShot;
    public AudioClip enemyFireB;
    void Update()
    {
        int randomShoot = Random.Range(1, 500);

        if (randomShoot >= 499)
        {
            EFirePulseCannon();
        }
    }
    private void EFirePulseCannon()
    {
        GameObject efiredPulseShotL = Instantiate(EPlasmaCannonShot, transform.position, transform.rotation);
            GameObject efiredPulseShotR = Instantiate(EPlasmaCannonShot, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(enemyFireB, transform.position);
            efiredPulseShotL.name = "enemyPlamsaShotL";
            efiredPulseShotL.name = "enemyPlamsaShotR";
            efiredPulseShotL.GetComponent<Rigidbody2D>().velocity = new Vector3(-1f, -1f, 0f);
            efiredPulseShotR.GetComponent<Rigidbody2D>().velocity = new Vector3(1f, -1f, 0f);
    }
}