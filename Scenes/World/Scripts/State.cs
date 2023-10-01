using Godot;
using System;


public partial class State : Node3D
{
	public ConfigFile config = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Error err = config.Load("res://Config/config.cfg");

		if (err != Error.Ok)
		{
			throw new Exception("Error loading config file. Abort!");
		}
		GD.Print(CurrentGameState.PrintState());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public void OnCarParkedIn()
	{
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

