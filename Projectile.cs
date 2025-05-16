using Godot;
using System;

public partial class Projectile : Area2D
{

    private bool inMotion = false;
    private Vector2 direction;
    private int speed;

    public void Fire(Vector2 direction, int speed)
    {
        this.direction = direction;
        this.speed = speed;
        inMotion = true;
    }

    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition += direction * speed;
    }

    public void onScreenExited()
    {
        Visible = false;
    }



}
