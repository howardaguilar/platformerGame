using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class EthanBlendController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;

    private float move = 1;
    public float moveAmplify = 1;
    public float amplify = 2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walking animation start
        move = Input.GetAxis("Horizontal");
        move = (Input.GetKey(KeyCode.LeftShift)) ? move * amplify : move; //TURBO!!!
        animator.SetFloat("Speed", Mathf.Abs(move));

        

        //turn Ethan Model with 
        float y = (move < 0) ? 270 : 90;
        Vector3 input = new Vector3(0, y, 0);
        transform.eulerAngles = input;
        // Walking animation end
    }

    private void FixedUpdate()
    {
        //Vector3 nextFrameMove = new Vector3(0, rb.velocity.y, (move * moveAmplify)); // Could help with jump // Horizontal and Vertical together?
        rb.velocity = (Vector3.right * move * moveAmplify); // Update walking position
    }
}

