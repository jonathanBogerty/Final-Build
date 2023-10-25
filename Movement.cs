using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public Transform player;
    public GameObject feet;
    public LayerMask groundLayer;

    public float groundCheckCircle = 0.1f;

    //public LogicScript logic;
    public float velocityHorizontal = 0f;
    public float velocityVertical = 0f;

    public float maxVelocityGround = 1f;
    public float maxUpSpeed = 5f;
    public float maxFlySpeed = 10;
    public float flipSpeed = 5f;

    bool previousGround = true;

    public float upAcceleration = 2.5f;
    public float groundAcceleration = 0.5f;
    public float airAcceleration = 0.5f;
    public float up = 2f;
    public float distToGround;
    public float speedGround = 0.5f;
    public float speedAir = 2f;

    bool inWater;

    float LastYPosition;

    // Start is called before the first frame update
    void Start()
    {
       // logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feet.transform.position, distToGround + groundCheckCircle, groundLayer);
    }



    // Update is called once per frame
    void Update()
    {
        if (player.position.y < -10f)
        {
            inWater = true;

            if (upAcceleration > 0)
            {
                upAcceleration = upAcceleration * -1;
            }
        }
        if (player.position.y > -10f)
        {
            inWater = false;
            if ( upAcceleration < 0)
            {
                upAcceleration = upAcceleration * -1;
            }
        }

        if (LastYPosition < -10f && player.position.y > -10f)
        {
            Flip(flipSpeed);
        }
        if (LastYPosition > -10f && player.position.y < -10f)
        {
            Flip(flipSpeed * -1);
        }
        LastYPosition = Rigidbody.position.y;

       

        if (Input.GetKeyDown("z") == true || Input.GetKeyDown("m") == true)
        {
            velocityVertical = Rigidbody.velocity.y + upAcceleration;
            if (Rigidbody.velocity.y > maxUpSpeed)
            {
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, maxUpSpeed);
            }
            else
            {
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, velocityVertical);
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                if (Rigidbody.velocity.x >= maxFlySpeed && Input.GetAxis("Horizontal") > 0)
                {
                    velocityHorizontal = maxFlySpeed;
                }
                else if (Rigidbody.velocity.x <= (maxFlySpeed * -1) && Input.GetAxis("Horizontal") < 0)
                {
                    velocityHorizontal = maxFlySpeed * -1;
                }
                else
                {
                    velocityHorizontal = Rigidbody.velocity.x + Input.GetAxis("Horizontal") * airAcceleration;
                }
                Rigidbody.velocity = new Vector2(velocityHorizontal, Rigidbody.velocity.y);
            }
        }

        else if (IsGrounded())
        {
            if (previousGround == false)
            {
                //logic.IncreaseScore();
            }
            previousGround = true;
            if (Input.GetKeyDown("z") == true || Input.GetKeyDown("m") == true)
            {
                velocityVertical = Rigidbody.velocity.y + upAcceleration;
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, velocityVertical);
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                if (Rigidbody.velocity.x >= maxVelocityGround)
                {
                    velocityHorizontal = maxVelocityGround;
                }
                else if (Rigidbody.velocity.x <= (maxVelocityGround * -1))
                {
                    velocityHorizontal = maxVelocityGround * -1;
                }
                else
                {
                    velocityHorizontal = Rigidbody.velocity.x + Input.GetAxis("Horizontal") * groundAcceleration;
                }
                Rigidbody.velocity = new Vector2(velocityHorizontal, Rigidbody.velocity.y);
            }


        }
        else
        {
            previousGround = false;
        }
    }
    void Flip(float direction)
    {
        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, direction);
    }
}