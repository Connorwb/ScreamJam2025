extends Area2D

@export var triggered_control : Control
@export var seek_collision_layer : int
@export var dissapear : Sprite2D

var panel : Panel
var label : Label
var text : RichTextLabel
var active : bool
var activated : bool

func _ready() -> void:
	text = triggered_control.get_child(2)

func _process(_delta: float) -> void:
	if active:
		text.visible_characters += 1


func _on_body_entered(body: Node2D) -> void:
	print("Body '%s' entered" % body.name)
	if (!(body.name == "PlayerDead") and  !(body.name == "PlayerAlive")):
		return

	active = true
	triggered_control.visible = true
	text.visible_characters = 0
	set_meta("Entered", true)


func _on_body_exited(body: Node2D) -> void:
	if (!(body.name == "PlayerDead") and  !(body.name == "PlayerAlive")):
		return

	if dissapear and dissapear is Sprite2D:
		dissapear.visible = false

	active = false
	triggered_control.visible = false
