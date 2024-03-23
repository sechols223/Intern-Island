extends RigidBody2D

@onready var colorRect = $ColorRect
@onready var waterCollision = $CollisionShape2D
var season = ""
# Called when the node enters the scene tree for the first time.
func _ready():
	
	pass # Replace with function body.

func season_change(newSeason):
	if(newSeason != season):
		season = newSeason
		if(newSeason == "fall"):
			colorRect.color = Color.DARK_BLUE
			get_node("CollisionShape2D").disabled = true 
	
		if(newSeason == "winter"):
			colorRect.color = Color.LIGHT_BLUE
			waterCollision.disabled = false
	
		if(newSeason == "summer"):
			colorRect.color = Color.DODGER_BLUE
			waterCollision.disabled = true
	
		if(newSeason == "spring"):
			colorRect.color = Color.SADDLE_BROWN
			waterCollision.disabled = false

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	season_change("fall")
	pass
