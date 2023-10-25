using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScaler : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D Rigidbody2D;

    // Update is called once per frame
    void Update()
    {
       if (player.position.y > -10f)
        {
            Physics2D.gravity = new Vector2(0, -9.8f);
        }
        else
        {
            Physics2D.gravity = new Vector2(0, 9.8f);
        }
    }
}
