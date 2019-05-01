using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    public GameObject Unit;
    public GameObject Food;
    public int UnitCount;
    public int FoodPerDay;
    public int FoodChange;
    private int FoodToday;
    private int randomNumber = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < UnitCount; i++)
        {
            randomNumber = Random.Range(1, 5);
            if (randomNumber == 1)
            {
                var newUnit = Instantiate(Unit, new Vector3(-5, 1, Random.Range(-5, 5)), transform.rotation);
                newUnit.transform.parent = gameObject.transform;
            }
            if (randomNumber == 2)
            {
                var newUnit = Instantiate(Unit, new Vector3(Random.Range(-5, 5), 1, -5), transform.rotation);
                newUnit.transform.parent = gameObject.transform;
            }
            if (randomNumber == 3)
            {
                var newUnit = Instantiate(Unit, new Vector3(5, 1, Random.Range(-5, 5)), transform.rotation);
                newUnit.transform.parent = gameObject.transform;
            }
            if (randomNumber == 4)
            {
                var newUnit = Instantiate(Unit, new Vector3(Random.Range(-5, 5), 1, 5), transform.rotation);
                newUnit.transform.parent = gameObject.transform;
            }
        }
        SpawnFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFood() {
        FoodToday = FoodPerDay + Random.RandomRange(-FoodChange, FoodChange);
        for (int y = 0; y < FoodToday; y++)
        {
            Instantiate(Food, new Vector3(Random.RandomRange(-4, 4), 0.5f, Random.RandomRange(-4, 4)), transform.rotation);
        }
    }
}
