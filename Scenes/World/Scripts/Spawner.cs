using Godot;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

public partial class Spawner : Node
{
	[Export]
	private int amountOfFreeParkingSpaces = 2;
	private PackedScene sceneStaticCar;
	private PackedScene sceneFreeParkingSpace;

	private Godot.Collections.Array<Node> spawners;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get all available spawners
		spawners = GetTree().GetNodesInGroup("spawn");

		GD.Print(spawners);

		sceneStaticCar = GD.Load<PackedScene>("res://Models/ProtoTypeStaticCar/StaticCar.tscn");
		sceneFreeParkingSpace = GD.Load<PackedScene>("res://Scenes/ParkingSpace/ParkingSpace.tscn");

		GD.Print(sceneFreeParkingSpace);

		// Then shuffle and spawn either a static vehicle or a free parking space;
		SpawnInParkingSpace();

	}


	public void SpawnInParkingSpace()
	{

		// Maybe scramble the array because it might get mostly the first elements free parking spaces spawned
		spawners.Shuffle();

		if (spawners.Count < amountOfFreeParkingSpaces)
		{
			throw new Exception("can not have more free parking spaced then spawners");
		}

		for (int i = 0; i <= amountOfFreeParkingSpaces; i++)
		{
			var nodeFreeParkingSpace = sceneFreeParkingSpace.Instantiate();
			spawners[i].AddChild(nodeFreeParkingSpace);
		}

		for (int i = amountOfFreeParkingSpaces +1; i < spawners.Count; i++)
		{
			var nodeStaticCar = sceneStaticCar.Instantiate();
			spawners[i].AddChild(nodeStaticCar);
		}

	}
}