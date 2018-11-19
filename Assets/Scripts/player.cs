using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    Rigidbody rb;
    public float xForce;
    //public float maxVeloc;
    public float thrust;
    private bool isGrounded;
    //public GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        //float yVeloc = rb.velocity.y;
        bool isJump = Input.GetButtonDown("Jump");
        Vector3 jump = new Vector3(0, 100, 0);

        if (x > 0)
        {
            //rb.velocity = new Vector3(maxVeloc, yVeloc, 0);
            rb.AddForce(new Vector3(xForce, 0, 0));
        }
        else if (x < 0) rb.AddForce(new Vector3(-xForce, 0, 0)); //rb.velocity = new Vector3(-maxVeloc, yVeloc, 0);

        if (isJump && isGrounded)
        {
            rb.AddForce(jump * thrust);
            isGrounded = false;
        }

        if (rb.position.y < -3f) {
            FindObjectOfType<GameManager>().gameLost();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameWin"))
        {
            FindObjectOfType<GameManager>().gameWin();
        }
    }

}
