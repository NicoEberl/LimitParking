using Godot;
using System;
using System.Collections.Immutable;

public partial class GameTimer : Timer
{

	private ConfigFile config = new();
	private double initTime;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Error err = config.Load("res://Config/config.cfg");

		if (err != Error.Ok)
		{
			throw new Exception("Error loading config file. Abort!");
		}

		GD.Print(config.GetSectionKeys("game"));
		initTime = CurrentGameState.time;

		WaitTime = initTime;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
