extends Camera2D

var AlivePlayer: CharacterBody2D
var DeadPlayer: CharacterBody2D

func _ready() -> void:
	AlivePlayer = get_node("/root/Node/PlayerAlive")
	DeadPlayer = get_node("/root/Node/PlayerDead")  


func _process(_delta: float) -> void:
	if is_instance_valid(AlivePlayer) and is_instance_valid(DeadPlayer):
		var alive_x: float = AlivePlayer.global_position.x
		var dead_x: float = DeadPlayer.global_position.x
		

		var new_x: float = (alive_x + dead_x) / 2.0
		
		var current_y: float = global_position.y
		
		global_position = Vector2(new_x, current_y)
