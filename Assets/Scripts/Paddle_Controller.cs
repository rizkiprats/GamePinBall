using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Controller : MonoBehaviour
{
    [SerializeField] KeyCode key;

    private float targetPressed;
    private float targetRelease;

    [SerializeField]private float springPower;
    [SerializeField] private float speed;

    HingeJoint hinge;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    void ReadInput()
    {
        JointSpring jointspring = hinge.spring;
        jointspring.spring = springPower * speed * Time.deltaTime;

        if (Input.GetKey(key))
        {
            jointspring.targetPosition = targetPressed;
        }
        else
        {
            jointspring.targetPosition = targetRelease;
        }

        hinge.spring = jointspring;
    }

}