using Godot;
using System;

public abstract partial class AbstractState : Node2D
{

    protected AbstractState nextState = null;
    // Called when entering the state
    public abstract void Enter();

    // Called when exiting the state
    public abstract void Exit();

    // Use signals to manually override the current state.
    public void Interrupt(AbstractState state) {
        nextState = state;
    }

    // Called every frame, returns the next state
    public AbstractState Process(double delta) {
        if (nextState != null)
        {
            AbstractState state = nextState;
            nextState = null;
            return state;
        }
        return this;
    }
}