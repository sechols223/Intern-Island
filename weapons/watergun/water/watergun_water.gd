extends CharacterBody2D

var cooldown = 4.0/60.0
var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")

func _init():
	velocity = Vector2(300.0 + randf_range(-10.0, 10.0), -300.0 + randf_range(-20.0, 20.0))

func _process(_delta):
	look_at(global_position + velocity)

func _physics_process(delta):
	velocity.y += gravity*delta
	
	var hit = move_and_slide()
	
	for index in range(get_slide_collision_count()):
		var collision = get_slide_collision(index)
		var body = collision.get_collider()
		if body == null:
			continue
	
		if body.is_in_group("hittable"):
			body.hit("water", 1)
	
	if hit:
		die()

func die():
	queue_free()
