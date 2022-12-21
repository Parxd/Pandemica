using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveredScript : MonoBehaviour
{
    public int immunityChance = 85;
    public GameObject susceptible;
    // Start is called before the first frame update
    void Start()
    {
        int val = Random.Range(0, 100);
        if (val > immunityChance)
        {
            // instantiate susceptible object with same position & velocity
            GameObject spawn = Instantiate(susceptible, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            spawn.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            // destroy this recovered object
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
