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
    public int activeUnits = 0;
    private bool settingUpDay = false;
    public bool day = false;
    private float t = 0;

    // Start is called before the first frame update
    void Start()
    {
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
            settingUpDay = true;
            NewDay(DayNr);
        }
    }

    // Update is called once per frame
    void Update()
    {
        t = t + Time.deltaTime;
        if (t > 1)
        {
            foreach (GameObject Unit in unitsInGame)
            {
                if (Unit.GetComponent<UnitBehavour>().isActive == true)
                {
                    day = true;
                }
                else {
                    day = false;
                }
            }
            t = 0;
        }
        unitsInGame = GameObject.FindGameObjectsWithTag("Unit");
        if (day == false) {
            if(settingUpDay == false)
            {
                NewDay(DayNr);
                settingUpDay = true;
            }
        }
    }

    void NewDay(int CurrentDay) {
        day = true;
        activeUnits = unitsInGame.Length + 1;
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
            Instantiate(Food, new Vector3(Random.Range(-sizeOfMap+1, sizeOfMap-1), 0.5f, Random.Range(-sizeOfMap+1, sizeOfMap-1)), transform.rotation);
        }
    }
}
