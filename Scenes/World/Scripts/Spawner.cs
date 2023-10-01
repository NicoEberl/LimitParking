using Godot;
using System;


public partial class Spawner : Node
{
	private int amountOfFreeParkingSpaces = 100;
	private PackedScene sceneStaticCar;
	private PackedScene sceneFreeParkingSpace;

	private Godot.Collections.Array<Node> spawners;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Print free parking spaces
		GD.Print($"Free parking spaces: {this.amountOfFreeParkingSpaces}");
		// Get all available spawners
		spawners = GetChildren();

		sceneStaticCar = GD.Load<PackedScene>("res://Models/ProtoTypeStaticCar/StaticCar.tscn");
		sceneFreeParkingSpace = GD.Load<PackedScene>("res://Scenes/ParkingSpace/ParkingSpace.tscn");

		// Then shuffle and spawn either a static vehicle or a free parking space;
		SpawnInParkingSpace();

	}

	public void SpawnInParkingSpace()
	{

		// Maybe scramble the array because it might get mostly the first elements free parking spaces spawned
		spawners.Shuffle();

		GD.Print(spawners.Count);
		if (spawners.Count < amountOfFreeParkingSpaces)
		{
			throw new Exception("can not have more free parking spaced then spawners");
		}

		for (int i = 0; i < spawners.Count; i++)
		{
			if (i <= amountOfFreeParkingSpaces - 1)
			{
				var nodeFreeParkingSpace = sceneFreeParkingSpace.Instantiate();
				spawners[i].AddChild(nodeFreeParkingSpace);

				GD.Print("Create free parking space");
			}
			else
			{
				var nodeStaticCar = sceneStaticCar.Instantiate();
				spawners[i].AddChild(nodeStaticCar);
			}
		}


	}
}
