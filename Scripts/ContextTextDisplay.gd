extends Area2D

@export var triggered_control_before : Control
@export var triggered_control_after : Control
@export var seek_collision_layer : int
@export var seek_activated : Area2D
@export var actuate_anim: AnimationPlayer 


var panel : Panel
var label : Label
var text : RichTextLabel
var active : bool
var triggered_control : Control

func _ready() -> void:
	triggered_control = triggered_control_before
	text = triggered_control.get_child(2)

func _process(_delta: float) -> void:
	if active:
		text.visible_characters += 1
	if seek_activated.get_meta("Entered") :
		print("GOT THING")
		triggered_control = triggered_control_after

func _on_body_entered(body: Node2D) -> void:
	if (!(body.name == "PlayerDead") and  !(body.name == "PlayerAlive")):
		return

	print("Body '%s' entered" % body.name)
	active = true
	triggered_control.visible = true
	text.visible_characters = 0


func _on_body_exited(body: Node2D) -> void:
	if (!(body.name == "PlayerDead") and  !(body.name == "PlayerAlive")):
		return

	active = false
	triggered_control.visible = false
	if seek_activated.get_meta("Entered") :
		actuate_anim.play("End")
