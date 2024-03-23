extends Node2D

@onready var sprite = $Kazuya
var enter = false
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_area_2d_body_shape_entered(body_rid, body, body_shape_index, local_shape_index):
	print(1)
	sprite.set_global_position(Vector2(6575,992))
	PlayerInfo.setXandY(PlayerInfo.getX()-200,PlayerInfo.getY())
