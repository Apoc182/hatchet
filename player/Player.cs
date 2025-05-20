using System;
using Godot;


public partial class Player : CharacterBody2D
{
	// Speed of the player
	[Export]
	public float speed = 200.0f;

	[Export]
	private Node2D backpack;

	[Export]
	public BaseController controller;

	public Vector2 directionFacing = Vector2.Down;
	
	public bool canMove = true;

	public override void _Ready()
	{
		controller.DirectionChanged += DirectionFacingHandler;
		controller.DirectionHeld += CalculateVelocity;
		controller.DirectionChanged += (Vector2 direction) => { if (direction == Vector2.Zero) Velocity = Vector2.Zero; };

	}


	private void CalculateVelocity(Vector2 direction)
	{

		Velocity = CartesianToIsometric(direction);
		Velocity = Velocity * speed;
	}

	private void DirectionFacingHandler(Vector2 direction){
		if(direction != Vector2.Zero) directionFacing = direction;
	}

	public Vector2 CartesianToIsometric(Vector2 direction)
	{
		direction = direction.Normalized();
		if(direction.X != 0 && direction.Y != 0){
	    	return new Vector2(direction.X, direction.Y / 2);
		}
		return direction;

	}


	public override void _PhysicsProcess(double delta)
	{
		if(canMove) MoveAndSlide();
	}
}
