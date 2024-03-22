using Godot;
using System;

public partial class player : Area2D
{

	[Export]
	public float Velocity { get; set; } = 400;

	public Vector2 ScreenSize { get; set; }

	const string MOVE_UP = "move_up";
	const string MOVE_DOWN = "move_down";
	const string MOVE_LEFT = "move_left";
	const string MOVE_RIGHT = "move_right";

	public override void _Ready()
	{
		GD.Print("Player Loaded");
		ScreenSize = GetViewportRect().Size;
	}

	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;
		if (Input.IsActionPressed(MOVE_UP))
		{
			velocity.Y -= 1;
		}

		if (Input.IsActionPressed(MOVE_DOWN))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed(MOVE_RIGHT))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed(MOVE_LEFT))
		{
			velocity.X -= 1;
		}

		var animatedSprite2D = GetNode<AnimatedSprite2D>(nameof(AnimatedSprite2D));

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Velocity;
			animatedSprite2D.Play();
			SetPosition(velocity, delta);
		}
		else
		{
			animatedSprite2D.Stop();
		}
	}

	public void SetPosition(Vector2 velocity, double delta)
	{
		Position += velocity * (float)delta;
		Position = new Vector2(x: Mathf.Clamp(Position.X, 0, ScreenSize.X), y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y));
	}

	public Vector2 GetVelocity()
	{
		var velocity = Vector2.Zero;
		if (IsUpPressed())
		{
			velocity.Y += 1;
		}

		if (IsDownPressed())
		{
			velocity.Y -= 1;
		}

		if (IsRightPressed())
		{
			velocity.X += 1;
		}

		if (IsLeftPressed())
		{
			velocity.X -= 1;
		}


		return velocity;
	}

	public bool IsUpPressed() => Input.IsActionPressed(MOVE_UP);
	public bool IsDownPressed() => Input.IsActionPressed(MOVE_DOWN);
	public bool IsRightPressed() => Input.IsActionPressed(MOVE_RIGHT);
	public bool IsLeftPressed() => Input.IsActionPressed(MOVE_LEFT);
}
