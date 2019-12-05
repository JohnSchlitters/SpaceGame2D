using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public enemyHPmanager enemyLHealth;
    private int playerPulseDamage = 50;
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D enemyCollide2D)
    {
        if (enemyCollide2D.gameObject.CompareTag("EnemyLight"))
        {
            enemyLHealth.enemyHP = enemyLHealth.enemyHP -= 50;
            print("enemy took 50 damage");
            Destroy(this.gameObject);
            print("removed laser");
        }
        if (enemyCollide2D.gameObject.CompareTag("EnemyHeavy"))
        {
            enemyLHealth.enemyHP = enemyLHealth.enemyHP -= 20;
            print("enemy took 25 damage");
            Destroy(this.gameObject);
            print("removed laser");
        }
        if (enemyCollide2D.gameObject.CompareTag("EnemyMissile"))
        {
            enemyLHealth.enemyHP = enemyLHealth.enemyHP -= 34;
            print("enemy took 34 damage");
            Destroy(this.gameObject);
            print("removed laser");
        }
    }
}
