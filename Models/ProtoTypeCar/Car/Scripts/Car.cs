using Godot;
using System;

public partial class Car : VehicleBody3D
{
	[Export]
	private int speed = 1;
	[Export]
	private int acceleration = 100;
	[Export]
	private int BRAKE_FORCE = 15;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

			float input = Input.GetAxis("backward", "forward");
			float steering = Input.GetAxis("left", "right");

			EngineForce = input * acceleration;
			Steering = steering * 100;

	}
}
