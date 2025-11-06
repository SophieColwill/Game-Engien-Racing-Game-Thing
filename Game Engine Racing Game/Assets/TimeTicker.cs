using UnityEngine;

public class TimeTicker : Observer
{
    public override void Notify(Subject subject)
    {
        Player.instance.Seconds += Time.deltaTime;

        if (Player.instance.Seconds >= 60)
        {
            Player.instance.Seconds -= 60;
            Player.instance.Minutes++;
        }
    }
}
