using Godot;
using System.Collections.Generic;

public partial class StateMachine : Node
{
	private IState _currentState;

	public override void _Ready()
	{
		var states = new List<IState>();

		foreach (Node child in GetChildren())
		{
			if (child is IState state)
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

	public override void _Process(double delta)
	{
		Process(delta);
	}

	public IState Process(double delta){

		IState nextState = _currentState.Process(delta);
		
		if(nextState != _currentState){
			_currentState.Exit();
			_currentState = nextState;
			_currentState.Enter();
		}

		return _currentState;
	}
}
