using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	private AnimatedSprite2D _animatedSprite;
	public Seasons _seasons;

	public const float BaseSpeed = 50.0f;
	public const float SummerSpeed = BaseSpeed + 100;
	public const float SpringSpeed = BaseSpeed / 4;
	public const float JumpVelocity = -400.0f;

	public int direction = -1;
	public int debuf = 1;
	public float health = 50.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _seasons = GetNode<Seasons>("/root/Seasons");

		if (direction == 1)
        {
			_animatedSprite.FlipH = true;
		}
		_animatedSprite.Play("crawl");
	}

	public override void _PhysicsProcess(double delta)
	{
        Vector2 velocity = Velocity;
		var currentSeason = _seasons.GetCurrentSeason();

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;
		
		//Turn around when hit wall
		if (IsOnWall())
		{
			direction = -direction;
			_animatedSprite.FlipH = !_animatedSprite.FlipH;
		}

		if (health < 0)
		{
			_animatedSprite.Stop();
		}

		//Change speed based on season
		var speed = currentSeason switch
		{
			"summer" => SummerSpeed,
			"spring" => SpringSpeed,
			"winter" => SummerSpeed,
			"fall" => SpringSpeed,
			_ => BaseSpeed,
		};

		if(health > 0)
		{
			velocity.X = speed * direction;
			Velocity = velocity;
			MoveAndSlide();
		}
	}

	public void hit(string type, float damage)
	{
		health -= damage;
		GD.Print(health, " ", type);
	}
}