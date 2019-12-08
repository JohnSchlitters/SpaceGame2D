using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletePlayerProjectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D detectPlayerShot)
    {
        if (detectPlayerShot.gameObject.CompareTag("PlayerPulse"))
        {
            Destroy(detectPlayerShot.gameObject);
        }
        if (detectPlayerShot.gameObject.CompareTag("PlayerPlasma"))
        {
            Destroy(detectPlayerShot.gameObject);
        }
        if (detectPlayerShot.gameObject.CompareTag("PlayerBeam"))
        {
            Destroy(detectPlayerShot.gameObject);
        }
        if (detectPlayerShot.gameObject.CompareTag("PlayerMissile"))
        {
            Destroy(detectPlayerShot.gameObject);
        }
    }
}
