extends Node
@onready var gameMusic = $kirby2
# Called when the node enters the scene tree for the first time.
func _ready():
	gameMusic.play()


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
