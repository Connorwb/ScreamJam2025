class_name Player_Base extends CharacterBody2D

var Speed: int 
var Gravity: int 
var ScreenSize: Vector2 
var carried_velocity: Vector2
var Col: CollisionShape2D
var SelfBoundary: RectangleShape2D
var animatedSprite2D: AnimatedSprite2D
@export var jumpHeight: float = -900.0 
@export var mirrored: bool = false 
var ctrl_velocity: Vector2 = Vector2.ZERO 

func _ready():
    Col = $CollisionShape2D 
    animatedSprite2D = $AnimatedSprite2D 
    
    if Col:
        SelfBoundary = Col.shape as RectangleShape2D
        
    ScreenSize = get_viewport_rect().size

func _physics_process(delta: float) -> void:
    carried_velocity.y += Gravity * delta
    
    if Input.is_action_pressed("move_right"):
        move_right()
    
    if Input.is_action_pressed("move_left"):
        move_left()


    velocity = carried_velocity + ctrl_velocity

    move_and_slide() 

    if velocity.length() < 50:
        animatedSprite2D.animation = "Idle"

    if IsOnFloorMod():
        if Input.is_action_pressed("jump"):
            carried_velocity.y = jumpHeight 
        else:
            carried_velocity.y = 0 
    else: # If not on floor
        animatedSprite2D.animation = "Jumping"
        
    if IsOnCeilingMod():
        carried_velocity.y = 0 

    animatedSprite2D.play()

func move_left():
    ctrl_velocity.x = -Speed 
    animatedSprite2D.animation = "Walking"
    animatedSprite2D.flip_h = mirrored

func move_right():
    ctrl_velocity.x = Speed
    animatedSprite2D.animation = "Walking"
    animatedSprite2D.flip_h = not mirrored

func IsOnFloorMod() -> bool:
    return is_on_floor()
    
func IsOnCeilingMod() -> bool:
    return is_on_ceiling()