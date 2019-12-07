using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public enemyHPmanagerLight enemyLHealth;
    public enemyHPmanagerHeavy enemyHHealth;
    //public enemyHPmanagerMissile enemyLHealth;
    // Update is called once per frame
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
        /*if (enemyCollide2D.gameObject.CompareTag("EnemyMissile"))
        {
            enemyLHealth.enemyHPM = enemyLHealth.enemyHPM -= 34;
            print("enemy took 34 damage");
            Destroy(this.gameObject);
            print("removed laser")
        }*/
    }
}
