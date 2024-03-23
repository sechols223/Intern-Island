extends StaticBody2D

var tween: Tween

func hit(type: String, damage: int):
	if tween:
		tween.kill()
	tween = create_tween()
	tween.tween_property($Sprite2D, "modulate", Color(1, 0, 0), 0.1)
	tween.tween_property($Sprite2D, "modulate", Color(1, 1, 1), 0.1)
