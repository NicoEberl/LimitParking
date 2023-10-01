public static class CurrentGameState
{
    public static int currentRound { get; set; } = 1;
    public static int currentScore { get; set; } = 0;
    public static float timeNeeded { get; set; }


    public static void ResetState()
    {
        currentRound = 0;
        currentScore = 0;
    }

    public static string PrintState()
    {
        return $"Current round {currentRound}\nCurrent score: {currentScore}";
    }
}