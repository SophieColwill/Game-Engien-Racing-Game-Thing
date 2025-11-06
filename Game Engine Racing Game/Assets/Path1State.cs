using System.Collections.Generic;
using UnityEngine;

public class Path1State : MonoBehaviour, PlayerPositionState
{
    private Player _player;
    List<GameObject> carsInLane = new List<GameObject>();
    float TimeUntilCarSpawn = 0;
    public GameObject EnemyCar;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            carsInLane.Add(Instantiate(EnemyCar));
            carsInLane[i].SetActive(false);
        }
        TimeUntilCarSpawn = Random.Range(1f, 7f);
    }

    public void Handle(Player localPlayer)
    {
        if (_player == null)
        {
            _player = localPlayer;
        }

        _player.transform.position = new Vector3(-1.98f, -3.43f, 0);


        foreach (GameObject car in carsInLane)
        {
            if (car.activeSelf)
            {
                if ((car.transform.position.y <= -2.58f) && (car.transform.position.y >= -4.08f))
                {
                    car.SetActive(false);
                    Player.instance.CarFuel -= 5;
                }
            }
        }
    }

    private void Update()
    {
        HandleEnemyCarMovement();
    }

    void HandleEnemyCarMovement()
    {
        TimeUntilCarSpawn -= Time.deltaTime;

        if (TimeUntilCarSpawn <= 0)
        {
            TimeUntilCarSpawn = Random.Range(1f, 7f);

            foreach (GameObject car in carsInLane)
            {
                if (car.activeSelf == false)
                {
                    car.SetActive(true);
                    car.transform.position = new Vector3(-1.98f, 5.6f, 0);
                    break;
                }
            }
        }

        foreach (GameObject car in carsInLane)
        {
            if (car.activeSelf)
            {
                car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y - (Time.deltaTime * 2.3f), car.transform.position.z);

                if (car.transform.position.y <= -5.6f)
                {
                    car.SetActive(false);
                }
            }
        }
    }
}
