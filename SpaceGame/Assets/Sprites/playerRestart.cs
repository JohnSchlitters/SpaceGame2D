using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (PlayerController.isDead == false)
            {
                print("I'm not dead yet!");
            }
            else if (PlayerController.isDead == true)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
