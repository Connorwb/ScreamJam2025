extends Area2D

@export var triggered_control : Control
@export var seek_collision_layer : int

var panel : Panel
var label : Label
var text : RichTextLabel
var active : bool

func _ready() -> void:
	panel = triggered_control.get_child(0)
	label = triggered_control.get_child(1)
	text = triggered_control.get_child(2)

func _process(_delta: float) -> void:
	if active:
		text.visible_characters += 1


func _on_body_entered(_body: Node2D) -> void:
	active = true
	panel.visible = true
	label.visible = true
	text.visible = true
	text.visible_characters = 0


func _on_body_exited(_body: Node2D) -> void:
	active = false
	panel.visible = false
	label.visible = false
	text.visible = false
