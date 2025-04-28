using System;
using Godot;


public partial class Player : CharacterBody2D
{
	// Speed of the player
	[Export]
	public float Speed = 200.0f;

	[Export]
	public AnimatedSprite2D animatedSprite2D;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Vector2.Zero; // The player's movement vector
		String direction = PlayerAnimatedSprite2d.DEFAULT;

		// Get input direction
		if (Input.IsActionPressed("ui_right"))
		{
			velocity.X += 1;
			direction = PlayerAnimatedSprite2d.WALK_EAST;
		}
		if (Input.IsActionPressed("ui_left"))
		{
			velocity.X -= 1;
			direction = PlayerAnimatedSprite2d.WALK_WEST;

		}
		if (Input.IsActionPressed("ui_down"))
		{
			velocity.Y += 1;
			direction = PlayerAnimatedSprite2d.WALK_SOUTH;

		}
		if (Input.IsActionPressed("ui_up"))
		{
			velocity.Y -= 1;
			direction = PlayerAnimatedSprite2d.WALK_NORTH;

		}

		animatedSprite2D.Play(direction);

		// Normalize the velocity to ensure consistent speed in all directions
		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
		}

		// Move the player
		Velocity = velocity;
		MoveAndSlide();
	}
}
