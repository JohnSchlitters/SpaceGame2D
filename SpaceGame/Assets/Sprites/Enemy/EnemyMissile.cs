using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
public GameObject PlayerTarget;
public float rocketSpeed = 1f;
public GameObject mexplosionemitter;
public float missileTurn = 10f;

private Rigidbody2D rocketBody;
void Start()
{
    PlayerTarget = GameObject.Find ("Player");
    rocketBody = GetComponent<Rigidbody2D>();
    rocketBody.gravityScale = 0;
}

// Update is called once per frame
void Update()
{
    PlayerTarget.transform.position = PlayerTarget.transform.position;
    Vector2 missileDirection = (Vector2) PlayerTarget.transform.position - rocketBody.position;
    missileDirection.Normalize();
    float rotateIndex = Vector3.Cross(missileDirection, transform.up * -1).z;
    rocketBody.angularVelocity = -missileTurn * rotateIndex;
    rocketBody.velocity = (transform.up * -1) * rocketSpeed;
}
private void OnCollisionEnter2D(Collision2D missileDeath)
{
    if (missileDeath.gameObject.CompareTag("PlayerPulse"))
    {
        GameObject missileexplosionemitter = Instantiate(mexplosionemitter, gameObject.transform.position, gameObject.transform.rotation);
        missileexplosionemitter.name = "enemyexplosion";
        Destroy(missileexplosionemitter, 2f);
        Destroy(missileDeath.gameObject);
        Destroy(gameObject);
        print("missile destroyed");
    }
    if (missileDeath.gameObject.CompareTag("PlayerPlasma"))
    {
        GameObject missileexplosionemitter = Instantiate(mexplosionemitter, gameObject.transform.position, gameObject.transform.rotation);
        missileexplosionemitter.name = "enemyexplosion";
        Destroy(missileexplosionemitter, 2f);
        Destroy(missileDeath.gameObject);
        Destroy(gameObject);
        print("missile destroyed");
    }
    if (missileDeath.gameObject.CompareTag("PlayerBeam"))
    {
        GameObject missileexplosionemitter = Instantiate(mexplosionemitter, gameObject.transform.position, gameObject.transform.rotation);
        missileexplosionemitter.name = "enemyexplosion";
        Destroy(missileexplosionemitter, 2f);
        Destroy(gameObject);
        print("missile destroyed");
    }
}
}
