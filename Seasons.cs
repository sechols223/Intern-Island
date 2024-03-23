using Godot;
using Godot.Collections;

public partial class Seasons : Node
{
	public string Summer { get; } = "summer";
	public string Fall { get; } = "fall";
	public string Winter { get; } = "winter";
	public string Spring { get; } = "spring";
	
	public Array<string> SeasonsQueue = new();

	public Timer CycleTimer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SeasonsQueue.AddRange(new[] {Summer, Fall, Winter, Spring});
		CycleTimer = GetNode<Timer>("CycleTimer");
	}

	public string GetCurrentSeason() => SeasonsQueue[0];

	public void CycleSeasons() {
		var firstSeason = SeasonsQueue[0];
		SeasonsQueue.RemoveAt(0);
		SeasonsQueue.Add(firstSeason);
	}
	
	private void _on_cycle_timer_timeout()
	{
		CycleSeasons();
	}
}
