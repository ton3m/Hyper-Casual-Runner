using System;

public class StartGameButton : ActionButton
{
    public void Initialize(Action start) => SetOnClicked(start);
}