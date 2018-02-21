using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerScore
{

    private static int score = 0;

    public static int Score
    {
        get { return score; }
    }

    public static void AddScore()
    {
        score++;
    }
}
