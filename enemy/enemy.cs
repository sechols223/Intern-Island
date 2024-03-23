using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	private AnimatedSprite2D _animatedSprite;
	private CollisionShape2D _collisionShape;
	public Seasons _seasons;
	private Signal signal;

	public const float BaseSpeed = 50.0f;
	public const float JumpVelocity = -400.0f;

	public int direction = -1;
	public int debuf = 1;
	public float health = 50.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private void _on_animated_sprite_2d_animation_finished(){
		if(_animatedSprite.Animation == "hit"){
			_animatedSprite.Play("crawl");
		}
	}

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
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

		//Change speed based on season
		var speed = currentSeason switch
		{
			"summer" => BaseSpeed * 3,
			"spring" => BaseSpeed,
			"winter" => BaseSpeed / 3,
			"fall" => BaseSpeed,
			_ => BaseSpeed,
		};


		if(health > 0)
		{
			velocity.X = speed * direction;
			Velocity = velocity;
			MoveAndSlide();
		}
	}

	public async void hit(string type, float damage)
	{
		health -= damage;
		_animatedSprite.Play("hit");
		if(health < 0)
		{
			death();
		}
	}

	public void death()
	{
		_collisionShape.SetDeferred("disabled", true);
		_animatedSprite.Play("dead");
		var tween = CreateTween();
		tween.TweenProperty(_animatedSprite, "scale", Vector2.Zero, 2.0f);
		tween.TweenCallback(Callable.From(QueueFree));
	}
}
