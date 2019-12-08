using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public GameObject closestEnemyTarget;
    public float rocketSpeed = 1f;
    public float missileTurn = 15f;

    private Rigidbody2D rocketBody;
    void Start()
    {
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Enemy");
        closestEnemyTarget = null;
        float minimumDistance = Mathf.Infinity;
        for (int e = 0; e < allTargets.Length; e++)
        {
            float thatDist = Vector3.Distance(transform.position, allTargets[e].transform.position);
            if (thatDist < minimumDistance)
            {
                minimumDistance = thatDist;
                closestEnemyTarget = allTargets[e];
            }
        }
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
        rocketBody.velocity = (transform.up) * rocketSpeed;
    }
}
