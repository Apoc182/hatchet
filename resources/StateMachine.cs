using Godot;
using System.Collections.Generic;

public partial class StateMachine : Node
{
	private AbstractState _currentState;

	public override void _Ready()
	{
		var states = new List<AbstractState>();

		foreach (Node child in GetChildren())
		{
			if (child is AbstractState state)
			{
				states.Add(state);
			}
		}

		if (states.Count > 0)
		{
			_currentState = states[0];
			_currentState.Enter();
		}
	}

	public void InterruptCurrentState(AbstractState state)
	{
		_currentState.Interrupt(state);
	}

	public override void _Process(double delta)
	{
		Process(delta);
	}

	public AbstractState Process(double delta){

		AbstractState nextState = _currentState.Process(delta);
		
		if (nextState != _currentState)
		{
			_currentState.Exit();
			_currentState = nextState;
			_currentState.Enter();
		}

		return _currentState;
	}
}
