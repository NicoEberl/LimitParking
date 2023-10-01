using Godot;
using System;

public partial class LoosScreen : Node
{
	private Label highScoreLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	   highScoreLabel = GetNode<Label>("HBoxContainer/VBoxContainer/HighScore");
	   highScoreLabel.Text = $"High score: {CurrentGameState.currentScore}";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnTryAgainPressed() {
		CurrentGameState.ResetState();
		GetTree().ChangeSceneToFile("res://Scenes/World/ParkingWorld.tscn");
	}
}
