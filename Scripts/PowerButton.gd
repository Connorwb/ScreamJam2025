extends StaticBody2D

@export var actuate_anim: AnimationPlayer 

var depressed: Node2D 
var inactive: Node2D  

func _ready() -> void:
	depressed = $Depressed 
	inactive = $Ready    

	var detection_area = find_child("DetectionArea") 
	if detection_area and detection_area is Area2D:
		detection_area.body_entered.connect(_on_detection_area_body_entered)
		detection_area.body_exited.connect(_on_detection_area_body_exited)

func _on_detection_area_body_entered(node: Node2D) -> void:
	
	print("Body '%s' entered" % node.name)
	
	if is_instance_valid(depressed):
		depressed.visible = true
	if is_instance_valid(inactive):
		inactive.visible = false
		
	if is_instance_valid(actuate_anim):
		actuate_anim.play("Rise")

func _on_detection_area_body_exited(node: Node2D) -> void:
	
	print("Body '%s' exited" % node.name)
	
	if is_instance_valid(depressed):
		depressed.visible = false
	if is_instance_valid(inactive):
		inactive.visible = true

	if is_instance_valid(actuate_anim):
		actuate_anim.play_backwards("Rise")
