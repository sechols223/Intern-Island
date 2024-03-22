extends RigidBody2D

@onready var colorRect = $ColorRect

var season = "fall"
# Called when the node enters the scene tree for the first time.
func _ready():
	
	pass # Replace with function body.

func _season_change(newSeason):
	if(newSeason != season):
		season = newSeason
		if(newSeason == "fall"):
			colorRect.color = Color.SADDLE_BROWN
	
		

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
