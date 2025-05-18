using Godot;
using System;
using System.Collections.Generic;

public partial class Shooter : Node2D
{

    [Export]
    private PackedScene projectile;
    
    [Export]
    private int poolSize = 10;

    [Export]
    private int projectileSpeed;

    [Export]
    private double rateOfFireCooldown;

    [Export]
    private Timer rateOfFireCooldownTimer;

    private List<Projectile> projectilePool = new List<Projectile>();

    public override void _Ready()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var instance = projectile.Instantiate<Projectile>();
            instance.Visible = false;
            GetTree().Root.AddChild(instance);
            projectilePool.Add(instance);
        }

        rateOfFireCooldownTimer.WaitTime = rateOfFireCooldown;
    }

    private Projectile GetPooledProjectile()
    {
        foreach (var p in projectilePool)
        {
            if (!p.Visible)
                return p;
        }
        return null; // pool exhausted
    }

    public void OnPlayerControllerAttack(Vector2 targetPosition)
    {

        if (!rateOfFireCooldownTimer.IsStopped())
        {
            return;
        }

        rateOfFireCooldownTimer.Start();

        var p = GetPooledProjectile();
        if (p != null)
        {
            p.GlobalPosition = GlobalPosition;
            p.Visible = true;
            p.Fire((targetPosition - GlobalPosition).Normalized(), projectileSpeed);
        }
    }
}
