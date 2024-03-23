using Godot;
using System;
using System.Threading.Tasks;

public partial class player : CharacterBody2D
{

	private bool _canDash = true;
	private bool _dashing = false;
	private float _speed = 100;
	private float _jumpSpeed = -400;
	private Vector2? _dashingTo;
	public float Gravity { get; set; } = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public float lastDirection = 1;
	public Seasons _seasons;
	public PlayerInfo _playerInfo;
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

			float direction = Input.GetAxis("move_left", "move_right");
			lastDirection = direction == 0f ? lastDirection : direction;
			GetNode<GodotObject>("WeaponHolderPivot").Set("scale", new Vector2(lastDirection, 1));
			GetNode<GodotObject>("WeaponHolderPivot/WeaponHolder").Set("direction", (int)Math.Round(lastDirection));
			float speed = _speed;
			
			_playerInfo = GetNode<PlayerInfo>("/root/PlayerInfo");
					 
			velocity.X = direction * speed * _playerInfo.GetSpeedModifier();
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
		float direction = Input.GetAxis("move_left", "move_right");
		if (Input.IsActionJustPressed("movement_action"))
		{
			if (_canDash)
			{
				Tween tween = GetTree().CreateTween();
				
				var position = Position;
				position.X = Position.X * direction;
				tween.TweenProperty(this, "position", new Vector2(100, 0) * direction, 0.25f).AsRelative();
				_timer.Start();
				_canDash = false;
			}
		}
		MoveAndSlide();
	}
}
