using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", destroyTime);
    }

    // Update is called once per frame
    private void DestroyObject()
    { 
        Destroy (this.gameObject);
    }
}
