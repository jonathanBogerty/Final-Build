using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;

    public Transform player;

    public float TimeLeft;
    public bool TimerOn = false;
    void Update()
    {
        if (player.position.y < -10)
        {
            TimerOn = true;
        }
        else
        {
            TimerOn = false;
            TimeLeft = 15;
        }

        if (TimerOn == true)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                playerHealth.TakeDamage(damage);
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);
    }

}