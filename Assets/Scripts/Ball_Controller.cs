using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnCollisionEnter(Collision collision)
    {
        // Kalau nabrak tembok bawah bruh
        if (collision.gameObject.CompareTag("RestartWall"))
        {
            // Congrats you lose
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
