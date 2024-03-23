extends Node2D

var direction = 1

func _physics_process(_delta):
	var child = get_child(0)
	if child is Weapon:
		if Input.is_action_pressed("fire"):
			child.fire(direction)
