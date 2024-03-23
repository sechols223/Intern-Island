extends Area2D

var season = ""
# Called when the node enters the scene tree for the first time.
func _ready():
	
	pass # Replace with function body.

func season_change(newSeason):
	if(newSeason != season):
		season = newSeason
		#if(newSeason == "fall"):
			#colorRect.color = Color.DARK_BLUE
	#
		#if(newSeason == "winter"):
			#colorRect.color = Color.LIGHT_BLUE
	#
		#if(newSeason == "summer"):
			#colorRect.color = Color.DODGER_BLUE
	#
		#if(newSeason == "spring"):
			#colorRect.color = Color.SADDLE_BROWN

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	season_change("fall")
	pass
