using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject EPulseCannonShot;

    public AudioClip enemyFireA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int randomShoot = Random.Range(1, 100);

        if (randomShoot > 98)
        {
            EFirePulseCannon();
        }
    }
    private void EFirePulseCannon()
    {
        GameObject efiredPulseShot = Instantiate(EPulseCannonShot, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(enemyFireA, transform.position);
        efiredPulseShot.name = "enemyPulseShot";
        efiredPulseShot.GetComponent<Rigidbody2D>().velocity = Vector2.down * 10f;;
    }
}
