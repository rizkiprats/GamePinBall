using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    // set max speed nya di inspector
    public float maxSpeed;

    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // cek besaran (magnitude) kecepatannya
        if (rig.velocity.magnitude > maxSpeed)
        {
            // kalau melebihi buat vector velocity baru dengan besaran max speed
            rig.velocity = rig.velocity.normalized * maxSpeed;
        }
    }
}
