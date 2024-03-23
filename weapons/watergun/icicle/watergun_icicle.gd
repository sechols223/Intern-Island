extends CharacterBody2D

func _ready():
	velocity = Vector2(500.0, 0.0)

func _physics_process(delta):
	var hit = move_and_slide()
	
	for index in range(get_slide_collision_count()):
		var collision = get_slide_collision(index)
		var body = collision.get_collider()
		if body == null:
			continue
		
		if body.is_in_group("hittable"):
			body.hit("ice", 20)

	if hit:
		die()

func die():
	queue_free()
