using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : Subject
{
    public static Player instance;

    public Path1State Path1;
    public Path2State Path2;
    public Path3State Path3;
    [HideInInspector] public int currentPath = 2;

    private Command closeGame, move_left, move_right;

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

        closeGame = new CloseGameCommand();
        move_left = new MoveLeftr();
        move_right = new MoveRight();
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
            move_right.Execute(this);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            move_left.Execute(this);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move_right.Execute(this);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move_left.Execute(this);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeGame.Execute(this);
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
