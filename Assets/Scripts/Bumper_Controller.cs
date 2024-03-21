using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper_Controller : MonoBehaviour
{
    public Material FirstMaterial;
    public Material SecondMaterial;
    public Material ThirdMaterial;

    public Renderer renderer;

    public float multiplier;
    public Collider Bola;

    public int Counter;

    private void Start() 
    {
        Counter = 0;
        renderer = GetComponent<Renderer>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == Bola)
        {
            Rigidbody bolaRig = collision.gameObject.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            switch(Counter) 
            {
                case 0:
                    renderer.material = SecondMaterial;
                    Counter += 1;
                    break;
                case 1:
                    renderer.material = ThirdMaterial;
                    Counter += 1;
                    break;
                default:
                    renderer.material = FirstMaterial;
                    Counter = 0;
                    break;
            }

        }
    }
}
