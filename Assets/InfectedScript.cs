using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InfectedScript : MonoBehaviour
{
    public CircleCollider2D circle;

    // Start is called before the first frame update
    void Start()
    {
        // Randomize infection radius to model different infectious levels
        circle.radius = Random.Range(3, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
