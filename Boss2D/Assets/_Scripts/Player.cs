using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string Name { get; set; }

    public int HighScore { get; set; }

    public int CurrentScore { get; set; }

    public bool Active { get; set; }

    public bool IsActive()
    {
        return Active;
    }

    public void UpdatePlayer(int newScore)
    {
        if (newScore > HighScore)
        {
            HighScore = newScore;
        }
        Active = false;
    }
}
