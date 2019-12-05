using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyHeavyShoot : MonoBehaviour
{
    public GameObject EPlasmaCannonShot;

    public AudioClip enemyFireB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int randomShoot = Random.Range(1, 300);

        if (randomShoot > 298)
        {
            EFirePulseCannon();
            Invoke("EFirePulseCannon", 1f);
        }
    }
    private void EFirePulseCannon()
    {
        GameObject efiredPulseShot = Instantiate(EPlasmaCannonShot, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(enemyFireB, transform.position);
        efiredPulseShot.name = "enemyPlamsaShot";
        efiredPulseShot.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5f;;
    }
}