using Godot;
using System;

public partial class ParkingSpace : Area3D
{

	private VehicleBody3D car;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		car = (VehicleBody3D)GetTree().GetFirstNodeInGroup("car");
		if (car == null)
		{
			throw new Exception("no car provided in group car");
		}
		AddUserSignal(CustomSignalNames.CAR_PARKED_IN);
	}

	public override void _PhysicsProcess(double delta)
	{
		// Check if car object is in signal
		if (OverlapsBody(car))
		{
			ObjectIsInShape();
		}

	}

	public void ObjectIsInShape()
	{
		EmitSignal(CustomSignalNames.CAR_PARKED_IN);
	}

}
