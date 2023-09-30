using Godot;
using System;

public partial class Car : VehicleBody3D
{
	[Export]
	private int speed = 1;
	[Export]
	private int mass = 40;
	[Export]
	private int accellaration = 1;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("forward"))
		{
			GD.Print("FOWARD");
		}
		if (Input.IsActionJustPressed("backward"))
		{
			GD.Print("BACKWARD");
		}
		if (Input.IsActionJustPressed("left"))
		{
			GD.Print("LEFT");
		}
		if (Input.IsActionJustPressed("right"))
		{
			GD.Print("RIGHT");
		}

	}
}
