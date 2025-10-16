extends "res://Scripts/Player.gd"

@export var AlivePair: CharacterBody2D

func _ready():
	
	ScreenSize = get_viewport_rect().size
	carried_velocity = Vector2.ZERO

	Col = $DeadCol
	animatedSprite2D = $AnimatedSprite2D

	if Col and Col.shape is RectangleShape2D:
		SelfBoundary = Col.shape as RectangleShape2D
		
	jumpHeight = 300.0 
	Speed = 275
	Gravity = -600 
	mirrored = true


func _physics_process(delta: float) -> void:
	ctrl_velocity.x = 0

	if Input.is_action_pressed("regroup"):
		if Input.is_action_pressed("move_left") or Input.is_action_pressed("move_right"):
			pass
		else:
			if AlivePair and is_instance_valid(AlivePair):
				if AlivePair.global_position.x > global_position.x:
					move_right()
				elif AlivePair.global_position.x < global_position.x:
					move_left()
					

	super._physics_process(delta)


func IsOnFloorMod() -> bool:
	return is_on_ceiling()

func IsOnCeilingMod() -> bool:
	return is_on_floor()
