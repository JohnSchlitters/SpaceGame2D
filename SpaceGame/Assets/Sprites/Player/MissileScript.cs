using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    // Start is called before the first frame update
 
    public Transform closestTarget;

    public float rocketSpeed = 25f;

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
/*        rocketBody.velocity = transform.up * rocketSpeed * Time.deltaTime;
        Vector3 targetVector = closestTarget.position - transform.position;
        float rotateIndex = Vector3.Cross(targetVector, transform.up).z;
        rocketBody.angularVelocity = -1 * rotateIndex * missileTurn * Time.deltaTime; */
    }
}
