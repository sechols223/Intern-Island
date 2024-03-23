extends Area2D
@onready var player = $"../../Player"
@onready var tekken = $"../../tekken"
@onready var gameMusic = $"../../kirby2"
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_body_shape_entered(body_rid, body, body_shape_index, local_shape_index):
	player.set_global_position(Vector2(player.global_position.x - 300,player.global_position.y))
	gameMusic.stop()
	tekken.play()

