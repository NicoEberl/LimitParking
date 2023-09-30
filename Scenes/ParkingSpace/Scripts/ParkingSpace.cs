using Godot;
using System;

public partial class ParkingSpace : Area3D
{
	[Export]
	private VehicleBody3D car;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{ }

	public override void _PhysicsProcess(double delta)
	{
		if (OverlapsBody(car))
		{
			ObjectIsInShape(car);
		}
		GD.Print(OverlapsBody(car));

	}

	public void ObjectIsInShape(Node collider)
	{
		GD.Print("Collerider is in Shape");
	}

}
