extends CharacterBody2D

var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")

func _init():
	velocity = Vector2(200.0, 0.0)

func _physics_process(delta):
	velocity.y += gravity * delta
	var collision_info = move_and_collide(velocity * delta)
	
	if collision_info:
		var collider = collision_info.get_collider()
		if collider is Node and collider.is_in_group("hittable"):
			collider.hit("bubble", 10)
			pop()
		velocity = velocity.bounce(collision_info.get_normal())

func pop():
	queue_free()

func _on_pop_timer_timeout():
	pop()
