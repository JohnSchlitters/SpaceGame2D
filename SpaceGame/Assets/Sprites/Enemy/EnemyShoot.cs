using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject EPulseCannonShot;
    public AudioClip enemyFireA;
    void Update()
    {
        int randomShoot = Random.Range(1, 200);

        if (randomShoot >= 199)
        {
            EFirePulseCannon();
        }
    }
    
    private void EFirePulseCannon()
    {
            GameObject efiredPulseShot = Instantiate(EPulseCannonShot, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(enemyFireA, transform.position);
            efiredPulseShot.name = "enemyPulseShot";
            efiredPulseShot.GetComponent<Rigidbody2D>().velocity = Vector2.down * 10f;

    }
}
