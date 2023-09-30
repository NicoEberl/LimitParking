using Godot;
using System;

public partial class ParkingSpace : Area3D
{
	private VehicleBody3D car;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{ 
		car = (VehicleBody3D)GetTree().GetFirstNodeInGroup("car");
	}

	public override void _PhysicsProcess(double delta)
	{
		if (OverlapsBody(car))
		{
			ObjectIsInShape(car);
		}

	}

	public void ObjectIsInShape(Node collider)
	{
		GD.Print("SUCCESSFULLY PARKED IN!");
	}

}
