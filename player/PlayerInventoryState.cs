using Godot;
using System;

public partial class PlayerInventoryState : AbstractState
{

	[Export]
	private BaseController controller;

	[Export]
	private StateMachine playerStateMachine;

	[Export]
	private Node2D backpack;

	// This needs to be fucked off. We should be handling the movement logic in the states. They should decide what is ok and what isnt.
	[Export]
	private Player player;

	[Export]
	private PlayerIdleState playerIdleState;

    public override void _Ready()
    {
		controller.InventoryPressed += OnInventoryPressed;
		controller.InventoryReleased += OnInventoryReleased;
    }


	public void OnInventoryPressed()
	{
		playerStateMachine.InterruptCurrentState(this);
	}

	public void OnInventoryReleased()
	{
		nextState = playerIdleState;
	}

	public override void Enter()
	{
		player.canMove = false;
		backpack.Visible = true;
	}

    public override void Exit()
    {
		player.canMove = true;
		backpack.Visible = false;
    }
}
