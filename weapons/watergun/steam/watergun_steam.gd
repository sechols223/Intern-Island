extends Area2D

var velocity = Vector2(200.0, 0.0)
@export var floatUpAcceleration = 10.0
@export var slowDownAcceleration = 70.0

func _physics_process(delta):
	# steam slows down
	velocity.x = move_toward(velocity.x, 0, slowDownAcceleration*delta)
	
	# steam floats up slowly
	velocity.y -= floatUpAcceleration*delta
	position += velocity*delta
	
	var hit_bodies = get_overlapping_bodies()
	for body in hit_bodies:
		if body.is_in_group("hittable"):
			body.hit("steam", delta * 5)

func fade():
	var tween = create_tween()
	tween.tween_property(self, "modulate", Color(1,1,1,0), 1.0)
	tween.tween_callback(queue_free)

func _on_fade_timer_timeout():
	fade()
