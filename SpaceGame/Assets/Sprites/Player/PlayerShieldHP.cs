using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldHP : MonoBehaviour
{
    public static int shieldHP;
    public PlayerController shieldTransform;
    public Transform playerShieldTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerShieldTransform = shieldTransform.playerShieldLocation;
        shieldHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHP <= 0)
        {
            PlayerController.hasShield = false;
            Destroy(gameObject);
        }

        //if (shieldHP > 100)
        {
            //shieldHP = 100;
        }
    }

    private void OnCollisionEnter2D(Collision2D EnemyProjectileCollide)
    {
        if (EnemyProjectileCollide.gameObject.CompareTag("EnemyPulse"))
        {
            shieldHP -= 5;
            Destroy(EnemyProjectileCollide.gameObject);
            print("removed enemy pulse");
        }

        if (EnemyProjectileCollide.gameObject.CompareTag("EnemyPlasma"))
        {
            shieldHP -= 10;
            Destroy(EnemyProjectileCollide.gameObject);
            print("removed enemy plasma");
        }

        if (EnemyProjectileCollide.gameObject.CompareTag("EnemyMissile"))
        {
            shieldHP -= 15;
            Destroy(EnemyProjectileCollide.gameObject);
            print("removed enemy plasma");
        }
        if (EnemyProjectileCollide.gameObject.CompareTag("EnemyBeam"))
        {
            shieldHP -= 25;
            Destroy(EnemyProjectileCollide.gameObject);
            print("removed enemy plasma");
        }
    }
}
