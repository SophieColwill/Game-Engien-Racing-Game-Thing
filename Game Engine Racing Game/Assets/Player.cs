using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : Subject
{
    public Path1State Path1;
    public Path2State Path2;
    public Path3State Path3;
    int currentPath = 2;

    public static float CarFuel, Seconds;
    public static int Minutes;

    public Slider Fuel;
    public TMP_Text TimeCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CarFuel = 50;
        Attach(gameObject.AddComponent<Fuel>());
        Attach(gameObject.AddComponent <TimeTicker>());
        Fuel.maxValue = 50;
    }

    // Update is called once per frame
    void Update()
    {
        NotifyObservers();

        if (Input.GetKeyDown(KeyCode.D))
        {
            currentPath++;
            if (currentPath == 4)
            {
                currentPath = 3;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentPath--;
            if (currentPath == 0)
            {
                currentPath = 1;
            }
        }


        if (currentPath == 1)
        {
            Path1.Handle(this);
        }
        else if (currentPath == 2)
        {
            Path2.Handle(this);
        }
        else if (currentPath == 3)
        {
            Path3.Handle(this);
        }

        TimeCounter.text = Minutes.ToString() + ":" + Mathf.RoundToInt(Seconds).ToString();
        Fuel.value = CarFuel;
        if (CarFuel <= 0)
        {
            Application.Quit();
        }
    }
}
