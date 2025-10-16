extends StaticBody2D

@export var actuate_obj_body: StaticBody2D 
@export var toggle_layer: int = 1

var actuate_obj_unop: Node2D 
var actuate_obj_open: Node2D 
var depressed: Node2D      
var inactive: Node2D       

func _ready() -> void:
	if is_instance_valid(actuate_obj_body):
		actuate_obj_unop = actuate_obj_body.get_child(1)
		actuate_obj_open = actuate_obj_body.get_child(2)
		
	depressed = $Depressed 
	inactive = $Ready    
	
	var detection_area = find_child("DetectionArea")
	if detection_area and detection_area is Area2D:
		detection_area.body_entered.connect(_on_detection_area_body_entered)


func _on_detection_area_body_entered(node: Node2D) -> void:
	print("Body '%s' entered" % node.name)
	
	if (!(node.name == "PlayerDead")):
		return
	
	if is_instance_valid(actuate_obj_unop):
		actuate_obj_unop.visible = false
	if is_instance_valid(actuate_obj_open):
		actuate_obj_open.visible = true
		
	if is_instance_valid(actuate_obj_body):
		var bit_to_remove: int = 1 << (toggle_layer - 1)
		actuate_obj_body.collision_layer &= ~bit_to_remove
	
	if is_instance_valid(depressed):
		depressed.visible = true
	if is_instance_valid(inactive):
		inactive.visible = false
