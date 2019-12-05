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
    public float enemyspeed = 0.25f;
    private Vector2 position;
    private float moveDuration = 4.0f;
    private float waitBeforeMove = 3.0f;
    public float enemyhp;

    private bool arrived = false;
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!arrived)
        {
            arrived = true;
            float randomXposition = Random.Range(-6.0f, 6.0f); //random left right
            float randomYposition = Random.Range(1.5f, 2.5f); //random up down
            StartCoroutine(MoveToPoint(new Vector3(randomXposition, randomYposition, 0)));
        }
    }

    private IEnumerator MoveToPoint (Vector3 targetposition)
    {
        float movetimer = 0.0f;
        Vector3 startposition = transform.position;

        while (movetimer < moveDuration) //while it's still moving
        {
            movetimer += Time.deltaTime;
            float t = movetimer / moveDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f); //more t is slower movement
            transform.position = Vector3.Lerp(startposition, targetposition, t);

            yield return null;
        }

        yield return new WaitForSeconds(waitBeforeMove);
        arrived = false;
    }
}
