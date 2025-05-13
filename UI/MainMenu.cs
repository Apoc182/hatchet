using Godot;

public partial class MainMenu : Control
{
    [Export]
    private AnimatedSprite2D animatedSprite2D;

    [Export]
    private Button startButton;

    [Export]
    private Button exitButton;

    public override void _Ready()
    {
        animatedSprite2D.Play();
        startButton.Pressed += onStartButtonPressed;
        exitButton.Pressed += onExitButtonPressed;
    }

    private void onStartButtonPressed(){
        GetTree().ChangeSceneToFile("res://world/world.tscn");
    }

    private void onExitButtonPressed(){
        GetTree().Quit();
    }

}
