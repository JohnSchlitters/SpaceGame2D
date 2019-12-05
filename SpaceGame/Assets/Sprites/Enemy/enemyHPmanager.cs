using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHPmanager : MonoBehaviour
{
    [SerializeField]
    public float enemyHP = 100;

    public GameObject explosionemitter;

    public float waitTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        enemyHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
        {
            //GameObject deadexplosionemitter = Instantiate(explosionemitter, gameObject.transform.position, gameObject.transform.rotation);
            //deadexplosionemitter.name = "enemyexplosion";
            //Destroy(deadexplosionemitter, waitTime);
            Destroy(this.gameObject);
            
        }
    }
}
