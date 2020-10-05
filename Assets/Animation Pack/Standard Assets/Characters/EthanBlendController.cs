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
    public float moveAmplify = 5;
    public float amplify = 2;

    // Jump Variable
    public float distToGround = 1f;
    public float jumpForce = 20f;
    public bool isGrounded = false;
    // Points and coins
    public Display message;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        message = GameObject.Find("Display").GetComponent<Display>();
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

        // Jump Code
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = (Vector3.up * jumpForce * 100f);
            Debug.Log("JUMPING");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = (Vector3.right * move * moveAmplify); // Update walking position

        // Jump Code
        if (Physics.Raycast(transform.position, Vector3.down, distToGround/3))
        {
            isGrounded = true;
            //Debug.Log("Grounded");
        } else
        {
            // Jump animation
            isGrounded = false;
            //Debug.Log("Not Grounded");
        }
    }
    
    // Collision on Blocks!
    private void OnCollisionEnter(Collision other)
    {
        // Check to see what block player collided with
        if (other.gameObject.name == "Brick(Clone)")
        {
            Destroy(other.gameObject);
            message.updatePoint();

        }
        else if (other.gameObject.name == "QuestionBox(Clone)")
        {
            Destroy(other.gameObject);
            message.updateCoin();
        }
    }
}

