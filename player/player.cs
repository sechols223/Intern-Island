using Godot;
using System;
using System.Threading.Tasks;

public partial class player : CharacterBody2D
{

	[Export]
	public int DashMultiplier { get; set; } = 8;
	[Export]
	public float DashDistance { get; set; } = 20.0f;
	private const string MOVE_UP = "move_up";
	private const string MOVE_DOWN = "move_down";
	private const string MOVE_LEFT = "move_left";
	private const string MOVE_RIGHT = "move_right";
	private bool _canDash = true;
	private bool _dashing = false;
	private float _speed = 100;
	private float _jumpSpeed = -400;
	private Vector2? _dashingTo;
	public float Gravity { get; set; } = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private Timer _timer;
	public override void _Ready()
	{
		Timer timer = GetNode<Timer>("DashTimer");
		timer.WaitTime = 1.5f;

		_timer = timer;
	}

	public void OnTimeout()
	{
		_canDash = true;
		_timer.Stop();
	}
	public override void _PhysicsProcess(double delta)
	{
		if (!_dashing)
		{
			var velocity = Velocity;

			velocity.Y += Gravity * (float)delta;

			if (Input.IsActionJustPressed("jump") && IsOnFloor())
			{
				velocity.Y = _jumpSpeed;
			}

			float direction = Input.GetAxis("ui_left", "ui_right");
			float speed = _speed;

			velocity.X = direction * speed;

			Velocity = velocity;

			Dash();
		}
		else
		{
			if (_dashingTo != null)
			{
				if (Position.DistanceTo(_dashingTo.Value) > 10)
				{
					MoveAndSlide();
				}
				else
				{
					_dashingTo = null;
					_dashing = false;
				}
			}

		}
	}

	private void Dash()
	{
		float direction = Input.GetAxis("ui_left", "ui_right");
		if (Input.IsActionJustPressed("movement_action"))
		{
			if (_canDash)
			{
				var position = Position;
				position.X = (Position.X + DashDistance) * direction;

				var speed = _speed * DashMultiplier;
				Velocity = Position.DirectionTo(position) * (float)speed;
				_dashingTo = position;
				_timer.Start();
				_canDash = false;
			}
		}
		MoveAndSlide();
	}
}
