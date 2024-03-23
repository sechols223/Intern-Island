using Godot;
using System;
using System.Threading.Tasks;

public partial class player : CharacterBody2D
{
	
	private bool _dashing = false;
	[Export]
	public float Speed { get; set; } = 200;
	[Export]
	public float JumpSpeed { get; set; } = -400;

	[Export]
	public int DashMultiplier { get; set; } = 600;

    public float Gravity { get; set; } = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public float lastDirection = 1;

	private Timer _cooldownTimer;
	private Timer _dashTimer;
    private GpuParticles2D _dashClouds;

    public override void _Ready()
	{
		_cooldownTimer = GetNode<Timer>("CooldownTimer");
		_dashTimer = GetNode<Timer>("DashTimer");
		_dashClouds = GetNode<GpuParticles2D>("DashClouds");
	}

	public override void _PhysicsProcess(double delta)
	{
		float direction = Input.GetAxis("move_left", "move_right");
		lastDirection = direction == 0f ? lastDirection : direction;
		if (_dashTimer.IsStopped())
		{
			_dashClouds.Emitting = false;
			var velocity = Velocity;

			velocity.Y += Gravity * (float)delta;

			if (Input.IsActionJustPressed("jump") && IsOnFloor())
			{
				velocity.Y = JumpSpeed;
			}

			GetNode<GodotObject>("WeaponHolderPivot").Set("scale", new Vector2(lastDirection, 1));
			GetNode<GodotObject>("WeaponHolderPivot/WeaponHolder").Set("direction", (int)Math.Round(lastDirection));
			float speed = Speed;

			velocity.X = direction * speed;

			Velocity = velocity;
			if (Input.IsActionJustPressed("movement_action"))
			{
				Dash();
			}
		}
		else
		{
			_dashClouds.Emitting = true;
			Velocity = new Vector2(DashMultiplier * lastDirection, 0);
		}
		MoveAndSlide();
	}

	private void Dash()
	{
		if (_cooldownTimer.IsStopped())
		{
			_dashTimer.Start();
			_cooldownTimer.Start();
		}
	}
}
