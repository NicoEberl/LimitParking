using Godot;
using System;

public partial class ShowTimer : Label
{
	private Timer time;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		time = GetNode<Timer>("../../Timer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text = $"Time left: {Math.Round(time.TimeLeft, 3)}";
	}
}
