using UnityEngine;

public static class ScoreController
{
    public static int Score { get; private set; }

    static ScoreController()
    {
        Score = 0;
    }

    public static void AddScore(int value)
    {
        Score += value;
    }

    public static void ResetScore()
    {
        Score = 0;
    }
}
