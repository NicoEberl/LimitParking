using Godot;

using Godot;
using System;

public partial class StaticCar : StaticBody3D
{

	private State state;
	private CollisionShape3D collisionShape3D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		state = (State)GetTree().GetFirstNodeInGroup("root");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// TODO: Check collision with player car

	}

	public void OnBodyEntered(Node3D node)
	{	

		if (node.GetParent().Name == "Player")
		{
			GD.Print("Collided with parked car");
			// Send to state
			state.OnCollideStaticCar();
			// TODO: Let explode
			return;
		}

	}
}
