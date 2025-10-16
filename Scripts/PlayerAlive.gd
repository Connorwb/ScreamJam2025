extends "res://Scripts/Player.gd"

func _ready() -> void:
	ScreenSize = get_viewport_rect().size 
	carried_velocity = Vector2.ZERO
	
	Col = $AliveCol 
	animatedSprite2D = $AnimatedSprite2D
	
	if Col and Col.shape is RectangleShape2D:
		SelfBoundary = Col.shape as RectangleShape2D
		
	jumpHeight = -325.0
	Speed = 275
	Gravity = 600
	mirrored = false

func _physics_process(delta: float) -> void:
	super._physics_process(delta)
	ctrl_velocity = Vector2.ZERO


func IsOnFloorMod() -> bool:
	return is_on_floor()

func IsOnCeilingMod() -> bool:
	return is_on_ceiling()
