extends ParallaxLayer

var defY = 1080
var defX = 1920
var offset = 26

func _process(_delta: float) -> void:
	var ScreenSize = get_viewport_rect().size
	motion_offset.y = ((ScreenSize.y - defY)/2) + (offset * (defY - ScreenSize.y)/defY)
