using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1;
    public bool isGrounded = false;
    float scaleX = 1;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        // Walk
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        // Flip the sprite to set the direction
        if (Input.GetAxis("Horizontal") != 0)
        {
            //
            //sprite.flipX = Input.GetAxis("Horizontal") < 0;
            int direction = 1;
            if (Input.GetAxis("Horizontal") < 0)
            {
                direction = -1;
            }
            transform.localScale = new Vector3(scaleX * direction, transform.localScale.y, transform.localScale.z);
        }

        // Animator
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
}
