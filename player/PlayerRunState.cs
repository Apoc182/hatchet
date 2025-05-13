using Godot;
using System;

public partial class PlayerRunState : Node2D, IState
{

	[Export]
	private AnimatedSprite2D animatedSprite;

	[Export]
	private BaseController controller;

	[Export]
	private Player player;

	private IState playerIdleState;

	private IState nextState = null;

	public override void _Ready(){
		playerIdleState = GetParent().GetNode<PlayerIdleState>("PlayerIdleState");
	}

	public void Enter()
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

	public void Exit()
	{
		controller.DirectionChanged -= OnDirectionChanged;
		nextState = null;
	}

	public IState Process(double delta)
	{
		if (nextState != null)
		{
			return nextState;
		}
		return this;
	}

}
