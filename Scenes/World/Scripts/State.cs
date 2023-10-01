using Godot;
using System;


public partial class State : Node3D
{
	public ConfigFile config = new();
	public Timer time;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Error err = config.Load("res://Config/config.cfg");

		if (err != Error.Ok)
		{
			throw new Exception("Error loading config file. Abort!");
		}
		GD.Print(CurrentGameState.PrintState());

		time = GetNode<Timer>("Timer");
	}

	public void OnCarParkedIn()
	{
		time.Stop();

		CurrentGameState.timeLeft = time.TimeLeft;
		CurrentGameState.time -= config.GetValue("game", "time_decrease_per_round").AsDouble() + CurrentGameState.timeLeft;
		CurrentGameState.currentRound += 1;
		CurrentGameState.currentScore += 100;

		GD.Print(CurrentGameState.PrintState());

		// Get to next round screen;
		GetTree().ReloadCurrentScene();
	}

	public void OnCollideStaticCar()
	{
		// TODO: Load game over
		GetTree().ChangeSceneToFile("res://UI/LooseScreen.tscn");
	}

	public void OnTimeout()
	{
		GetTree().ChangeSceneToFile("res://UI/LooseScreen.tscn");

	}
}

