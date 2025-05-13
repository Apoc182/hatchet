using Godot;
using System;

public interface IState
{
    // Called when entering the state
    void Enter();

    // Called when exiting the state
    void Exit();

    // Called every frame, returns the next state
    IState Process(double delta);
}