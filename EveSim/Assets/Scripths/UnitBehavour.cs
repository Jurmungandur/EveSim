using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehavour : MonoBehaviour
{
    public float speed;
    public GameObject god;
    public float enegy = 200;
    public Rigidbody rb;
    private float rotateBy = 0;
    private float t = 0.0f;
    public bool isActive = false;
    public int CurrentFood = 0;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform.LookAt(new Vector3(0, 1, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive == true) {
            if (enegy > 0)
            {
                t = t + Time.deltaTime;
                if (t > 0.75f)
                {
                    rotateBy = Random.Range(-5, 5);
                    t = 0;
                }
                transform.Rotate(new Vector3(0, rotateBy, 0), Space.Self);
                rb.velocity = transform.forward * speed * 2;
                enegy -= speed;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void Active() {
        transform.LookAt(new Vector3(0, 1, 0));
        enegy = 300;
        isActive = true;
    }

    private void OnTriggerEnter(Collider col2)
    {
        if (col2.gameObject.tag == "Food")
        {
            CurrentFood += 1;
            Destroy(col2.gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            if (CurrentFood >= 1) {
                isActive = false;
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
