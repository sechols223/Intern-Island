using Godot;
using Godot.Collections;

public partial class Seasons : Node
{
	public string Summer { get; } = "summer";
	public string Fall { get; } = "fall";
	public string Winter { get; } = "winter";
	public string Spring { get; } = "spring";
	
	public Array<string> SeasonsQueue = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SeasonsQueue.AddRange(new[] {Summer, Fall, Winter, Spring});
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public string GetCurrentSeason() => SeasonsQueue[0];
}
