using UnityEngine;

public class MoveLeftr : Command
{
    public override void Execute(Player player)
    {
        player.currentPath--;
        if (player.currentPath == 0)
        {
            player.currentPath = 1;
        }
    }
}
