extends Node2D
@onready var sprite = $FallTree
@onready var box = $Fallbox
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if(Seasons.GetCurrentSeason() == Seasons.Fall):
		set_visible(true)
		box.set_collision_layer_value(1,true)
	else:
		set_visible(false)
		box.set_collision_layer_value(1,false)
	pass
