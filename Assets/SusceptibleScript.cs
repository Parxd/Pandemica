using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusceptibleScript : MonoBehaviour
{
    public GameObject susceptible;
    // Attributes for infection
    private bool start = false;
    private float timer = 0;
    // Higher means more time required to infect
    public float infectionRate = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (timer < infectionRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Debug.Log("Color changed.");
                susceptible.GetComponent<SpriteRenderer>().color = Color.red;
                timer = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            start = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            start = false;
            timer = 0;
        }
    }
}
