using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseDamage : MonoBehaviour
{
    public enemyHPmanagerLight enemyLHealth;
    public enemyHPmanagerHeavy enemyHHealth;
    private void OnCollisionEnter2D(Collision2D enemyCollide2D)
    {
        if (enemyCollide2D.gameObject.CompareTag("EnemyLight"))
        {
            enemyLHealth.enemyHPL -= 50;
            print("enemy took 50 damage");
            Destroy(this.gameObject);
            print("removed pulse");
        }
        if (enemyCollide2D.gameObject.CompareTag("EnemyHeavy"))
        {
            enemyHHealth.enemyHPH -= 20;
            print("enemy took 25 damage");
            Destroy(this.gameObject);
            print("removed pulse");
        }
    }
}
