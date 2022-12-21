using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public int susceptiblePopulation = 500;
    public int infectedPopulation = 1;
    public GameObject susceptible;
    public GameObject infected;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < susceptiblePopulation; ++i)
        {
            GameObject spawn = Instantiate(susceptible, new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.6f, 4.6f), 0), 
                                            transform.rotation);
            spawn.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-0.15f, 0.15f), Random.Range(-0.15f, 0.15f));
        }
        for (int i = 0; i < infectedPopulation; ++i)
        {
            GameObject spawn = Instantiate(infected, new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.6f, 4.6f), 0), 
                                            transform.rotation);
            spawn.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-0.15f, 0.15f), Random.Range(-0.15f, 0.15f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
