using UnityEngine;

public class Fuel : Observer
{
    public override void Notify(Subject subject)
    {
        Player.instance.CarFuel -= Time.deltaTime;
    }
}
