using Godot;

public static class HatchetAnimationHelper
{

    public enum HatchetAnimationName
    {
        Idle,
        Run
    }

    public static string GetAnimationName(Vector2 direction, HatchetAnimationName animationName)
    {
        string directionName;

        GD.Print(direction);

        if (direction == new Vector2(-1, -1)) directionName = "North";
        else if (direction == new Vector2(1, 1)) directionName = "South";
        else if (direction == new Vector2(1, -1)) directionName = "East";
        else if (direction == new Vector2(-1, 1)) directionName = "West";
        else if (direction == new Vector2(0, -1)) directionName = "NorthEast";
        else if (direction == new Vector2(1, 0)) directionName = "SouthEast";
        else if (direction == new Vector2(0, 1)) directionName = "SouthWest";
        else if (direction == new Vector2(-1, 0)) directionName = "NorthWest";
        else directionName = "Idle";

        return $"{animationName}{directionName}";
    }



}