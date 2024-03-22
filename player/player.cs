using Godot;
using System;




public partial class player : CharacterBody2D
{

	private const string MOVE_UP = "move_up";
	private const string MOVE_DOWN = "move_down";
	private const string MOVE_LEFT = "move_left";
	private const string MOVE_RIGHT = "move_right";

	private float _speed = 100;
	private float _jumpSpeed = -400;
	public float Gravity { get; set; } = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	public override void _Input(InputEvent inputEvent)
	{

	}

	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector(MOVE_LEFT, MOVE_RIGHT, MOVE_UP, MOVE_DOWN);



		Velocity = inputDirection * _speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;
		velocity.Y += Gravity * (float)delta;

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = _jumpSpeed;
		}

		float direction = Input.GetAxis("ui_left", "ui_right");
		velocity.X = direction * _speed;

		Velocity = velocity;
		MoveAndSlide();
	}
}
