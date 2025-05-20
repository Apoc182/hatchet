using Godot;
using System;
using System.Diagnostics;

public partial class PlayerIdleState : AbstractState
{

	[Export]
	private BaseController controller;

	[Export]
	private AnimatedSprite2D animatedSprite;

	[Export]
	private Player player;

	private AbstractState playerRunState;


	public override void _Ready(){
		playerRunState = GetParent().GetNode<PlayerRunState>("PlayerRunState");
	}



	public override void Enter()
	{
		nextState = null;
		controller.DirectionChanged += OnDirectionChanged;
		animatedSprite.Play(
			HatchetAnimationHelper.GetAnimationName(
				player.directionFacing, 
				HatchetAnimationHelper.HatchetAnimationName.Idle
			)
		);
	}

	private void OnDirectionChanged(Vector2 newDirection)
	{
		if (newDirection != Vector2.Zero)
		{
			nextState = playerRunState;
		}
	}

	public override void Exit()
	{
		controller.DirectionChanged -= OnDirectionChanged;
	}


}
