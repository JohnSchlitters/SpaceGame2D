using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
public GameObject PlayerTarget;
public float rocketSpeed = 0.02f;

public float missileTurn = 100f;

private Rigidbody2D rocketBody;
void Start()
{
rocketBody = GetComponent<Rigidbody2D>();
rocketBody.gravityScale = 0;
}

// Update is called once per frame
void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.transform.position, rocketSpeed * Time.deltaTime * 0.1f);
        transform.LookAt(PlayerTarget.transform.position);
        //rocketBody.velocity = transform.up * rocketSpeed * Time.deltaTime;
        //Vector3 targetVector = PlayerTarget.transform.position - transform.position;
        //float rotateIndex = Vector3.Cross(targetVector, transform.up).z;
        //rocketBody.angularVelocity = -1 * rotateIndex * missileTurn * Time.deltaTime;
    }
}
