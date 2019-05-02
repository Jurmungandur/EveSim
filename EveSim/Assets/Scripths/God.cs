using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public GameObject Unit;
    public GameObject Food;
    public float sizeOfMap;
    public int DayNr = -2;
    public int UnitCount;
    public int FoodPerDay;
    public int FoodChange;
    public GameObject[] unitsInGame;
    private int FoodToday;
    private int randomNumber = 0;
    public int activeUnits;
    private bool settingUpDay = false;

    // Start is called before the first frame update
    void Start()
    {
        activeUnits = 1;
        for (int i = 0; i < UnitCount; i++)
        {
            randomNumber = Random.Range(1, 5);
            if (randomNumber == 1)
            {
                var newUnit = Instantiate(Unit, new Vector3(-sizeOfMap, 1.1f, Random.Range(-sizeOfMap, sizeOfMap)), transform.rotation);
                newUnit.GetComponent<UnitBehavour>().speed = 1;
                newUnit.GetComponent<UnitBehavour>().enegy = 200;
            }
            if (randomNumber == 2)
            {
                var newUnit = Instantiate(Unit, new Vector3(Random.Range(-sizeOfMap, sizeOfMap), 1.1f, -sizeOfMap), transform.rotation);
                newUnit.GetComponent<UnitBehavour>().speed = 1;
                newUnit.GetComponent<UnitBehavour>().enegy = 200;
            }
            if (randomNumber == 3)
            {
                var newUnit = Instantiate(Unit, new Vector3(sizeOfMap, 1.1f, Random.Range(-sizeOfMap, sizeOfMap)), transform.rotation);
                newUnit.GetComponent<UnitBehavour>().speed = 1;
                newUnit.GetComponent<UnitBehavour>().enegy = 200;
            }
            if (randomNumber == 4)
            {
                var newUnit = Instantiate(Unit, new Vector3(Random.Range(-sizeOfMap, sizeOfMap), 1.1f, sizeOfMap), transform.rotation);
                newUnit.GetComponent<UnitBehavour>().speed = 1;
                newUnit.GetComponent<UnitBehavour>().enegy = 200;
            }
            NewDay(DayNr);
            settingUpDay = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        unitsInGame = GameObject.FindGameObjectsWithTag("Unit");
        activeUnits = unitsInGame.Length;
        if (activeUnits <= 0) {
            if(settingUpDay == false)
            {
                NewDay(DayNr);
                settingUpDay = true;
            }
        }
    }

    void NewDay(int CurrentDay) {

        float totalspeedtoday = 0;
        float avragespeedtoday = 0;
        SpawnFood();
        unitsInGame = GameObject.FindGameObjectsWithTag("Unit");
        print("Day " + CurrentDay);
        foreach (GameObject Unit in unitsInGame)
        {
            totalspeedtoday += Unit.GetComponent<UnitBehavour>().speed;
        }
        avragespeedtoday = totalspeedtoday / unitsInGame.Length;
        print("Avrage speed: " + avragespeedtoday);
        foreach (GameObject Unit in unitsInGame)
        {
            Unit.GetComponent<UnitBehavour>().Active();
        }
        settingUpDay = false;
        DayNr++;
    }

    void SpawnFood() {
        FoodToday = FoodPerDay + Random.Range(-FoodChange, FoodChange);
        for (int y = 0; y < FoodToday; y++)
        {
            Instantiate(Food, new Vector3(Random.Range(-sizeOfMap, sizeOfMap), 0.5f, Random.Range(-sizeOfMap, sizeOfMap)), transform.rotation);
        }
    }
}
