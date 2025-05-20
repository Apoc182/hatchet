using Godot;
using System;

public abstract partial class BaseController : Node2D
{
    // Define signals
    [Signal]
    public delegate void DirectionChangedEventHandler(Vector2 newDirection);

    [Signal]
    public delegate void DirectionHeldEventHandler(Vector2 direction);

    [Signal]
    public delegate void AttackStartedEventHandler(Vector2 targetPosition);


    [Signal]
    public delegate void AttackHeldEventHandler(Vector2 targetPosition);

    [Signal]
    public delegate void AttackReleasedEventHandler(Vector2 targetPosition);

    [Signal]
    public delegate void InventoryPressedEventHandler();

    [Signal]
    public delegate void InventoryReleasedEventHandler();
}