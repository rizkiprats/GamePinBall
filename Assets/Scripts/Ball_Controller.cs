using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    // set max speed nya di inspector
    public float maxSpeed;

    private Rigidbody rig;
    private Vector3 InitialPosition; // Variabel posisi bola di awal

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        InitialPosition = transform.position; // Simpan posisinya
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

    private void OnCollisionEnter(Collision collision)
    {
        // Kalau nabrak tembok bawah (Restart Wall bakal restart)
        if (collision.gameObject.CompareTag("RestartWall"))
        {
            // Congrats you lose restarting the ball position
            transform.position = InitialPosition;
            
            // Jaga jaga reset kecepatan bola jadi 0 (biar gak gerak pas respawn)
            rig.velocity = Vector3.zero;
        }
    }
}
