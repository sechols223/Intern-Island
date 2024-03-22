using Godot;
using System;

public partial class Seasons : Node
{
	public string Summer { get; } = "summer";
	public string Fall { get; } = "fall";
	public string Winter { get; } = "winter";
	public string Spring { get; } = "spring";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
