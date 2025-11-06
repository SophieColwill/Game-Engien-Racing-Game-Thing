using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : Subject
{
    public static Player instance;

    public Path1State Path1;
    public Path2State Path2;
    public Path3State Path3;
    int currentPath = 2;

    public float CarFuel
    {
        get { return _carFuel; }
        set
        {
            if (_carFuel != value)
            {
                _carFuel = value;
                _isDirty = true;
            }
        }
    }
    float _carFuel;
    public float Seconds;
    public int Minutes;

    public Slider Fuel;
    public TMP_Text TimeCounter;

    public GameObject EnemyCar;

    bool _isDirty = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        CarFuel = 50;
        Attach(gameObject.AddComponent<Fuel>());
        Attach(gameObject.AddComponent <TimeTicker>());
        Fuel.maxValue = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDirty)
        {
            Fuel.value = CarFuel;
        }

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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
        if (CarFuel <= 0)
        {
            Application.Quit();
        }
    }
}
