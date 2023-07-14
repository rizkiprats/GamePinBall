using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper_Controller : MonoBehaviour
{
    public float multiplier;
    public Collider Bola;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == Bola)
        {
            Rigidbody bolaRig = collision.gameObject.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
        }
    }
}
