using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InfectedScript : MonoBehaviour
{
    private float timer = 0;
    public float recoveryTime = 100;
    public float lowerBoundRadius = 1;
    public float upperBoundRadius = 3;

    // Largest radius size that infectious person can get
    public float maxRadius = 8;
    // Radius increases by this value every frame until maxRadius is reached
    public float radiusIncreaseRate = 0.0005f;
    // Radius decreases by this value every frame after maxRadius is reached
    public float radiusDecreaseRate = 0.001f;
    // Ranges from 0% - 100% of recovery time
    public float longestContagiousPeriod = 0.75f;
    // WHEN the largest radius will occur
    private float maxInfectiousTime;

    public CircleCollider2D circle;
    public GameObject infected;
    public GameObject recovered;

    // Start is called before the first frame update
    void Start()
    {
        // Randomize infection radius to model different infectious levels
        circle.radius = Random.Range(lowerBoundRadius, upperBoundRadius);
        maxInfectiousTime = Random.Range(0, recoveryTime * longestContagiousPeriod);
    }

    // Update is called once per frame
    void Update()
    {
        // Models rise and fall of infectiousness
        if (timer < maxInfectiousTime && circle.radius < maxRadius)
        {
            circle.radius += radiusIncreaseRate;
        }
        else
        {
            circle.radius -= radiusDecreaseRate;
        }

        if (timer < recoveryTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // destroy infected object
            Destroy(infected);
            // instantiate recovered object with same velocity & position
            GameObject spawn = Instantiate(recovered, new Vector3(infected.transform.position.x, infected.transform.position.y, 0),
                                                infected.transform.rotation);
            spawn.GetComponent<Rigidbody2D>().velocity = infected.GetComponent<Rigidbody2D>().velocity;
        }
    }
}
