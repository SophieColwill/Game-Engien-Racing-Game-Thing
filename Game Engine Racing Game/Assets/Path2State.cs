using UnityEngine;

public class Path2State : MonoBehaviour, PlayerPositionState
{
    private Player _player;

    public void Handle(Player localPlayer)
    {
        if (_player == null)
        {
            _player = localPlayer;
        }

        _player.transform.position = new Vector3(0, -3.43f, 0);
    }
}
