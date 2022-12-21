using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusceptibleScript : MonoBehaviour
{
    public GameObject susceptible;
    public GameObject infected;
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
                // destroy susceptible object
                Destroy(susceptible);

                // instantiate infected object with same velocity & position
                GameObject spawn = Instantiate(infected, new Vector3(susceptible.transform.position.x, susceptible.transform.position.y, 0), 
                                                susceptible.transform.rotation);
                spawn.GetComponent<Rigidbody2D>().velocity = susceptible.GetComponent<Rigidbody2D>().velocity;
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
