using UnityEngine;

public class Path1State : MonoBehaviour, PlayerPositionState
{
    private Player _player;

    public void Handle(Player localPlayer)
    {
        if (_player == null)
        {
            _player = localPlayer;
        }

        _player.transform.position = new Vector3(-1.98f, -3.43f, 0);
    }
}
