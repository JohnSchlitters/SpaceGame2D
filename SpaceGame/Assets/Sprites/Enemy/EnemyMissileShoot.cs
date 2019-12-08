using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileShoot : MonoBehaviour
{
    public AudioClip enemyFireD;
    public GameObject missilePrefab;
    void Start()
    {
        InvokeRepeating("EFireMissile", 0f, 10f);
    }
    private void EFireMissile()
    {
        Instantiate(missilePrefab, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
        AudioSource.PlayClipAtPoint(enemyFireD, transform.position);
        missilePrefab.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
        missilePrefab.name = "enemyMissile";
    }
}
