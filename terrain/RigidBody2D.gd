extends RigidBody2D

@onready var colorRect = $ColorRect
@onready var waterCollision = $"."
var season 
# Called when the node enters the scene tree for the first time.
func _ready():
	
	pass # Replace with function body.

func season_change(newSeason):
	if(newSeason != season):
		season = newSeason
		if(newSeason == Seasons.Fall):
			colorRect.color = Color.DARK_BLUE
			waterCollision.set_collision_layer_value(1,false)
	
		if(newSeason == Seasons.Winter):
			colorRect.color = Color.LIGHT_BLUE
			waterCollision.set_collision_layer_value(1,true)
	
		if(newSeason == Seasons.Summer):
			colorRect.color = Color.DODGER_BLUE
			waterCollision.set_collision_layer_value(1,false)
	
		if(newSeason == Seasons.Spring):
			colorRect.color = Color.SADDLE_BROWN
			waterCollision.set_collision_layer_value(1,true)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	season_change(Seasons.GetCurrentSeason())
	pass
