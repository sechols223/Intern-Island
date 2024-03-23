extends Area2D

var Inside = false;

func _on_body_shape_entered(body_rid, body, body_shape_index, local_shape_index):
	Inside = true;

func _on_body_shape_exited(body_rid, body, body_shape_index, local_shape_index):
	Inside = false;

func season_change(season):
	if(season == Seasons.Summer):
		PlayerInfo.setSpeedModifier(float(1));
	if(season == Seasons.Fall):
		PlayerInfo.setSpeedModifier(float(1));
	if(season == Seasons.Spring):
		PlayerInfo.setSpeedModifier(float(.5));
	if(season == Seasons.Winter):
		PlayerInfo.setSpeedModifier(float(3));
	
func _process(delta):
	if(Inside):
		season_change(Seasons.GetCurrentSeason())
	pass
