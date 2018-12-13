using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float buttonTimer = 0.5f;
    public int buttonCount = 0;

    public float speed;
    public float speedModifier;

    public Rigidbody2D rb;
    private Vector2 moveVelocity;

    public float pressInterval = 0.5f; // Half a second before reset
    public int pressCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        //Get move input for use in Fixed Update
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        

        //Sprint by holding Left Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveVelocity = moveInput.normalized * speed * speedModifier;
        }
        else
        {
            moveVelocity = moveInput.normalized * speed;
        }

        //Dash dodge by double tapping a directional key
        if (Input.GetKeyDown("Up"))
        {

            if (pressInterval > 0 && pressCount == 1/*Number of Taps you want Minus One*/)
            {
                //Has double tapped
            }
            else
            {
                pressInterval = 0.5f;
                pressCount += 1;
            }
        }

        if (pressInterval > 0)
        {

            pressInterval -= 1 * Time.deltaTime;

        }
        else
        {
            pressCount = 0;
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
}
