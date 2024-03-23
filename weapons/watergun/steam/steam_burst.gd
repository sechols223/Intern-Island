extends Node2D

var velocity = Vector2(1, 0)
@export var steam: PackedScene
@export var amount = 3

func _ready():
	for i in range(amount):
		var new_steam = steam.instantiate()
		new_steam.position = global_position
		new_steam.velocity.x *= velocity.x
		new_steam.velocity.x += randf_range(-20, 20)
		new_steam.velocity.y += randf_range(-10, 10)
		new_steam.rotation = randf_range(0, 360)
		add_sibling(new_steam)
	queue_free()
