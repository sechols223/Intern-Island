using Godot;
using System;

public partial class PlayerInfo : Node
{
	public float speedmodifier = 1.0f;
	public float x;
	public float y;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public float GetSpeedModifier() => speedmodifier;
	
	public void setSpeedModifier(float newspeedmodifier){
		speedmodifier = newspeedmodifier;
	} 
	public void setXandY(float newX,float newY){
		x = newX;
		y = newY;
	}
	public float getX(){
		return x;
	}
	public float getY(){
		return y;
	}
}
