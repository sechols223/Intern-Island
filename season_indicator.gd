extends Control

@export_group("Colors")
@export var summer: Color
@export var fall: Color
@export var winter: Color
@export var spring: Color

@onready var colors = {
	"summer": summer,
	"fall": fall,
	"winter": winter,
	"spring": spring,
}

@onready var graph_container: Container = $GraphPanel/GraphContainer

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	var season_queue = Seasons.SeasonsQueue as Array
	var cycle_timer = Seasons.CycleTimer as Timer
	
	for index in range(season_queue.size() + 1):
		var child = graph_container.get_child(index) as ColorRect
		if not child:
			child = _makeColorRect()
			graph_container.add_child(child)
		
		if index < season_queue.size():
			child.color = colors[season_queue[index]]
		else:
			child.color = colors[season_queue[0]]
	
	var first_child = graph_container.get_child(0) as ColorRect
	var last_child = graph_container.get_child(season_queue.size()) as ColorRect
	
	first_child.size_flags_stretch_ratio = cycle_timer.time_left/cycle_timer.wait_time
	last_child.size_flags_stretch_ratio = 1 - cycle_timer.time_left/cycle_timer.wait_time

func _makeColorRect() -> ColorRect:
	var rect = ColorRect.new()
	rect.size_flags_horizontal = Control.SIZE_FILL | Control.SIZE_EXPAND
	return rect
