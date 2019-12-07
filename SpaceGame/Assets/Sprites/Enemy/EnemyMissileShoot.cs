using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileShoot : MonoBehaviour
{
    public GameObject EMissileShot;
    public AudioClip enemyFireD;
    void Start()
    {
        InvokeRepeating("EFireMissile", 0f, 15f);
    }
    private void EFireMissile()
    {
        GameObject eFiredMissile = Instantiate(EMissileShot, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(enemyFireD, transform.position);
        eFiredMissile.name = "enemyPlamsaShotL";
    }
}
