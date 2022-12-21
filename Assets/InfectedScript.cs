using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InfectedScript : MonoBehaviour
{
    private float timer = 0;
    public int recoveryTime = 2;
    public int lowerBoundRadius = 2;
    public int upperBoundRadius = 4;
    public CircleCollider2D circle;
    public GameObject infected;
    public GameObject recovered;

    // Start is called before the first frame update
    void Start()
    {
        // Randomize infection radius to model different infectious levels
        circle.radius = Random.Range(lowerBoundRadius, upperBoundRadius);
    }

    // Update is called once per frame
    void Update()
    {
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
