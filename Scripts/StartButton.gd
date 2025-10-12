extends Area2D

var _is_mouse_inside: bool = false 


func _ready() -> void:
    _is_mouse_inside = false
    
    connect("mouse_entered", _on_mouse_entered)
    connect("mouse_exited", _on_mouse_exited)
    
    input_pickable = true


func _process(_delta: float) -> void:
    if _is_mouse_inside:
        if Input.is_action_just_pressed("select"):
            get_tree().change_scene_to_file("res://Scenes/Level1.tscn")


func _on_mouse_entered() -> void:
    _is_mouse_inside = true

func _on_mouse_exited() -> void:
    _is_mouse_inside = false