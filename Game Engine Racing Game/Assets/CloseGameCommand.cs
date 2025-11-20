using UnityEngine;

public class CloseGameCommand : Command
{
    public override void Execute(Player player)
    {
        Application.Quit();
    }
}
