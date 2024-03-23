extends Node

func _physics_process(delta):
	var gun = $Watergun as Weapon
	gun.fire(1)
	


func _on_cycle_seasons_timer_timeout():
	Seasons.CycleSeasons()
