using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyManeuverScriptA : MonoBehaviour
{
    // Start is called before the first frame update
    private float enemytimer = 10;
    private int pointselect = 0;
    public Transform enemyPointL;
    public Transform enemyPointC;
    public Transform enemyPointR;
    float enemyspeed = 10f;
    private Vector2 position;
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        enemytimer -= 1 * Time.deltaTime;
        if (enemytimer <= 0f)
        {
            pointselect = Random.Range(1, 3);
            switch (pointselect)
            {
                case 1:
                    float step1 = enemyspeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, enemyPointL.transform.position, step1);
                    break;
                case 2:
                    float step2 = enemyspeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, enemyPointC.transform.position, step2);
                    break;
                case 3:
                    float step3 = enemyspeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, enemyPointR.transform.position, step3);
                    break;
            }
        }

        enemytimer = 10f;
    }
}
