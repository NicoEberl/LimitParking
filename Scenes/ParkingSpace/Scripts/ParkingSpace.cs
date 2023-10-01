using Godot;
using System;

public partial class ParkingSpace : Area3D
{
	private VehicleBody3D car;

	private State state;

	private bool hasParkedIn = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		state = (State)GetTree().GetFirstNodeInGroup("root");
		car = (VehicleBody3D)GetTree().GetFirstNodeInGroup("car");
		if (car == null)
		{
			throw new Exception("no car provided in group car");
		}

	}

	public override void _PhysicsProcess(double delta)
	{
		// Check if car object is in signal
		if (OverlapsBody(car) && !hasParkedIn)
		{
			state.OnCarParkedIn();
			this.hasParkedIn = true;
		}
	}
}
