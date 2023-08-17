extends KinematicBody2D

var velocity : Vector2

export var max_speed : int = 700
export var gravity : float = 55
export var jump_force : int = 1000
var acceleration : int = 150
export var cayote_time : int = 15
var cayote_counter : int = 0
var roll_force : int = 1250
var rightleft : bool = true
var dashready : bool = true
var can_jump : bool = true
var jumptimer : bool = false 

enum states {idle, walk, slowing, jump, fall, roll} 
var player_state = states.idle

onready var dashlenght = get_node("Timer")
onready var dashcolldown = get_node("Timer2")
onready var jumpcooldown = get_node("Timer3")

func _ready():
	dashlenght .wait_time = 0.2
	dashlenght .one_shot = true
	dashlenght .connect("timeout", self, "_on_timer_timeout")
	
	dashcolldown .wait_time = 2
	dashcolldown .one_shot = true
	dashcolldown .connect("timeout", self, "_on_timer_timeout2")
	
	jumpcooldown .wait_time = 1
	jumpcooldown .one_shot = true
	jumpcooldown .connect("timeout", self, "_on_timer_timeout3")


func _physics_process(_delta):
	#gravity
	if not is_on_floor():
		velocity.y += gravity
		if velocity.y > 2000:
			velocity.y = 2000

	#movement
	if player_state != states.roll:	
		if Input.is_action_pressed("ui_right"):
			velocity.x += acceleration 
			rightleft = true
			player_state = states.walk
		
		elif Input.is_action_pressed("ui_left"):
			velocity.x -= acceleration
			rightleft = false
			player_state = states.walk
		else:
			velocity.x = lerp(velocity.x,0,0.2)
			player_state = states.slowing
		
		velocity.x = clamp(velocity.x, -max_speed, max_speed)  
	
	#jump
	if can_jump:
		if Input.is_action_pressed("Jump"):
			if cayote_counter > 0:
				velocity.y = -jump_force
				player_state = states.jump
				cayote_counter = 0
				can_jump = false
				jumptimer = true

	if Input.is_action_just_released("Jump"):
		if velocity.y < 0:
			velocity.y += 400
			player_state = states.fall
	#coyote timer
	if is_on_floor():
		if jumptimer:
			jumpcooldown.start()
			jumptimer = false
		cayote_counter = cayote_time
	if not is_on_floor():
		if cayote_counter > 0:
			cayote_counter -= 1
	#dash
	if Input.is_action_just_pressed("roll"):
		if dashready:
			if rightleft:
				velocity.x = roll_force
				player_state = states.roll
				dashready = false
				dashlenght .start()
				dashcolldown.start()
			else:
				velocity.x = -roll_force
				player_state = states.roll
				dashready = false
				dashlenght .start()
				dashcolldown.start()
	
	velocity = move_and_slide(velocity, Vector2.UP)
	
func _on_timer_timeout():
	player_state = states.idle
	
func _on_timer_timeout2():
	dashready = true
	
func _on_timer_timeout3():
	can_jump = true

