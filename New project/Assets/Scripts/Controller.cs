using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalImpulse;
    float speedX;
    bool isGrounded;
    bool isRight = true;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -horizontalSpeed;

            if (isRight == true)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isRight = false;
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;

            if (isRight == false)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isRight = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }

        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
    
    