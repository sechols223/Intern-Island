extends Weapon

@export var bubble: PackedScene
@export var icicle: PackedScene
@export var steam: PackedScene
@export var water: PackedScene

@onready var firePosition: Marker2D = $FirePosition
@onready var cooldown: Timer = $CooldownTimer

func fire(direction: int, add_to_main: bool = true) -> Node2D:
	if not cooldown.is_stopped():
		return null
	var projectile = _get_current_projectile().instantiate() as Node2D
	projectile.position = firePosition.global_position
	projectile.velocity.x *= direction
	var projectile_cooldown = projectile.get("cooldown")
	if projectile_cooldown != null:
		cooldown.start(projectile_cooldown)
	else:
		cooldown.start(1)
	if add_to_main:
		get_tree().current_scene.add_child(projectile)
	return projectile

func _get_current_projectile() -> PackedScene:
	match(Seasons.GetCurrentSeason()):
		Seasons.Spring: return bubble
		Seasons.Summer: return steam
		Seasons.Fall: return water
		Seasons.Winter: return icicle
		_: return bubble
