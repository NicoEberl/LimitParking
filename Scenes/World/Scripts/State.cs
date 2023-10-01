using Godot;
using System;

public partial class State : Node3D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
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
}

