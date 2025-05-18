using Godot;
using System;

public partial class PlayerController : BaseController
{
	Vector2 _previous_direction = Vector2.Zero;
	bool attackHeld = false;

	private void ProcessAttack(InputEvent @event)
	{

		GD.Print(@event.IsActionPressed("attack"));
		if (@event.IsActionReleased("attack"))
		{
			EmitSignal(SignalName.AttackReleased, GetGlobalMousePosition());
			attackHeld = false;
		}

		if (@event.IsActionPressed("attack"))
		{
			EmitSignal(SignalName.AttackStarted, GetGlobalMousePosition());
			attackHeld = true;
		}
	}


	public override void _UnhandledInput(InputEvent @event)
	{
		Vector2 direction = _previous_direction;

		if (@event.IsActionPressed("left"))
		{
			direction.X -= 1;
		}
		if (@event.IsActionReleased("left"))
		{
			direction.X = 0;
		}
		if (@event.IsActionPressed("right"))
		{
			direction.X += 1;
		}
		if (@event.IsActionReleased("right"))
		{
			direction.X = 0;
		}
		if (@event.IsActionPressed("up"))
		{
			direction.Y -= 1;
		}
		if (@event.IsActionReleased("up"))
		{
			direction.Y = 0;
		}
		if (@event.IsActionPressed("down"))
		{
			direction.Y += 1;
		}
		if (@event.IsActionReleased("down"))
		{
			direction.Y = 0;
		}

		if (direction != _previous_direction)
		{
			EmitSignal(SignalName.DirectionChanged, direction);
			_previous_direction = direction;
		}

		if (direction.X != 0 || direction.Y != 0)
		{
			EmitSignal(SignalName.DirectionHeld, direction);
		}

		ProcessAttack(@event);

	}

	public override void _Process(double delta)
	{
		if (attackHeld)
		{
			EmitSignal(SignalName.AttackHeld, GetGlobalMousePosition());
		}
	}
}
