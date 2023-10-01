using System;
using Godot;

public static class CurrentGameState
{
    public static int currentRound { get; set; } = 1;
    public static int currentScore { get; set; } = 0;
    public static double timeLeft { get; set; } = 0;
    public static double time { get; set; } = GetInitTime();

    public static void ResetState()
    {
        currentRound = 0;
        currentScore = 0;
    }

    public static string PrintState()
    {
        return $"Current round {currentRound}\nCurrent score: {currentScore}";
    }

    private static double GetInitTime() {
        var config = new ConfigFile();

        var error = config.Load("res://Config/config.cfg");

        if (error != Error.Ok) {
            throw new Exception("Can not load config file");
        }

        return config.GetValue("game", "init_time").AsDouble();
    }
}