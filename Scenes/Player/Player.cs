using Godot;
using System;

public partial class Player : Node3D
{


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Connect(CustomSignalNames.CAR_PARKED_IN, new Callable(this, nameof(OnCarParkedIn)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnCarParkedIn()
	{
		GD.Print("Car parked in Signal received");
	}
}
