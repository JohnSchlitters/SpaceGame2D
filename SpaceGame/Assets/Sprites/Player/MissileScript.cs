using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public GameObject closestEnemyTarget;
    public float rocketSpeed = 25f;

    public float missileTurn = 100f;

    private Rigidbody2D rocketBody;
    void Start()
    {
        GameObject FindClosestByTag(string Enemy)
        {
            GameObject[] target;
            target = GameObject.FindGameObjectsWithTag(Enemy);
            GameObject closestEnemyTarget = null;
            float targetDistance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject targ in target)
            {
                Vector3 diff = targ.transform.position - position;
                float currentDistance = diff.sqrMagnitude;
                if (currentDistance < targetDistance)
                {
                    closestEnemyTarget = targ;
                    targetDistance = currentDistance;
                }
            }

            return closestEnemyTarget;
        }

        closestEnemyTarget = closestEnemyTarget;
        rocketBody = GetComponent<Rigidbody2D>();
        rocketBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 missileDirection = (Vector2) closestEnemyTarget.transform.position - rocketBody.position;
        missileDirection.Normalize();
        float rotateIndex = Vector3.Cross(missileDirection, transform.up * 1).z;
        rocketBody.angularVelocity = -missileTurn * rotateIndex;
        rocketBody.velocity = (transform.up * 1) * rocketSpeed;
    }

    private void OnTriggerEnter2D(Collider2D detectEnemy)
    {
        closestEnemyTarget = detectEnemy.collider2D;
    }
}
