using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    private GameObject closestEnemyTarget;
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
        rocketBody = GetComponent<Rigidbody2D>();
        rocketBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rocketBody.velocity = transform.up * rocketSpeed * Time.deltaTime;
        Vector3 targetVector = closestEnemyTarget.transform.position - transform.position;
        float rotateIndex = Vector3.Cross(targetVector, transform.up).z;
        rocketBody.angularVelocity = -1 * rotateIndex * missileTurn * Time.deltaTime;
    }
}
