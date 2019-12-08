using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeamShoot : MonoBehaviour
{
    public AudioClip enemyFireC;

    public GameObject EBeamLaser;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BeamShoot", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BeamShoot()
    {
        GameObject efiredBeam = Instantiate(EBeamLaser, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(enemyFireC, transform.position);
        efiredBeam.name = "enemyPlamsaShotL";
        efiredBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -5f, 0f);
    }
}
