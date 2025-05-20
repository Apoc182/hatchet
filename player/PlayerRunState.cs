using Godot;
using System;

public partial class PlayerRunState : AbstractState
{

	[Export]
	private AnimatedSprite2D animatedSprite;

	[Export]
	private BaseController controller;

	[Export]
	private Player player;

	private PlayerIdleState playerIdleState;

	

	public override void _Ready(){
		playerIdleState = GetParent().GetNode<PlayerIdleState>("PlayerIdleState");
	}

	public override void Enter()
	{
		controller.DirectionChanged += OnDirectionChanged;
		animatedSprite.Play(HatchetAnimationHelper.GetAnimationName(player.directionFacing, HatchetAnimationHelper.HatchetAnimationName.Run));
	}

	private void OnDirectionChanged(Vector2 newDirection)
	{
		if (newDirection == Vector2.Zero)
		{
			nextState = playerIdleState;
		}
		animatedSprite.Play(HatchetAnimationHelper.GetAnimationName(player.directionFacing, HatchetAnimationHelper.HatchetAnimationName.Run));
	}

	public override void Exit()
	{
		controller.DirectionChanged -= OnDirectionChanged;
		nextState = null;
	}




}
