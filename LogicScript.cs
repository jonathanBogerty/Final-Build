using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextAlignment ScoreText;

    [ContextMenu("Increase Score")]
    public void IncreaseScore()
    {
        playerScore++;
        //ScoreText.text = playerScore.ToString();
    }
}
