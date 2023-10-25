    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFishMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;


    void Update()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
            {
                transform.localScale = new Vector2(-1, 1);
                patrolDestination = 1;
            }
        }
        else if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
            {
                transform.localScale = new Vector2(1, 1);
                patrolDestination = 0;
            }
        }
    }
}
