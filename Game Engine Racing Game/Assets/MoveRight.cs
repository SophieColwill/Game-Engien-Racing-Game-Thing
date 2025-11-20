using UnityEngine;

public class MoveRight : Command
{
    public override void Execute(Player player)
    {
        player.currentPath++;
        if (player.currentPath == 4)
        {
            player.currentPath = 3;
        }
    }
}
