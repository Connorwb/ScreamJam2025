extends Area2D

@export var actuate_anim: AnimationPlayer 

func _on_body_entered(body: Node2D) -> void:
	print("Body '%s' entered" % body.name)

	if (!(body.name == "PlayerDead")):
		pass
		
	if is_instance_valid(actuate_anim):
		actuate_anim.play("Rise")


func _on_body_exited(body: Node2D) -> void:
	print("Body '%s' exited" % body.name)

	if (!(body.name == "PlayerDead")):
		pass

	if is_instance_valid(actuate_anim):
		actuate_anim.play_backwards("Rise")
