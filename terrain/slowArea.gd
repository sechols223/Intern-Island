extends Area2D
@onready var leaves = $"../../Leaves"
@onready var leaves2 = $"../../Leaves2"
var Inside = false;

func _on_body_shape_entered(body_rid, body, body_shape_index, local_shape_index):
	Inside = true;

func _on_body_shape_exited(body_rid, body, body_shape_index, local_shape_index):
	Inside = false;
	PlayerInfo.setSpeedModifier(float(1));

func season_change(season):
	if(Inside):
		if(season == Seasons.Summer):
			PlayerInfo.setSpeedModifier(float(1));
		if(season == Seasons.Fall):
			PlayerInfo.setSpeedModifier(float(1));
		if(season == Seasons.Spring):
			PlayerInfo.setSpeedModifier(float(.5));
		if(season == Seasons.Winter):
			PlayerInfo.setSpeedModifier(float(3));
			
	if(season == Seasons.Summer):
		leaves.set_position(Vector2(-72,364))
		leaves2.set_position(Vector2(-52,364))
	if(season == Seasons.Fall):
		leaves.set_position(Vector2(-72,-64))
		leaves2.set_position(Vector2(52,-64))
	if(season == Seasons.Spring):
		leaves.set_position(Vector2(-72,364))
		leaves2.set_position(Vector2(-52,364))
	if(season == Seasons.Winter):
		leaves.set_position(Vector2(-72,364))
		leaves2.set_position(Vector2(-52,364))
		
func _process(delta):
	season_change(Seasons.GetCurrentSeason())
	pass
