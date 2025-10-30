using UnityEngine;

public class TimeTicker : Observer
{
    public override void Notify(Subject subject)
    {
        Player.Seconds += Time.deltaTime;

        if (Player.Seconds >= 60)
        {
            Player.Seconds -= 60;
            Player.Minutes++;
        }
    }
}
