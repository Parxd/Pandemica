using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public float speed = 0.1f;
    // Attributes for changing particle speed
    private float timer = 0;
    // Attributes for wall collisions
    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    // Return random 2D vector
    private Vector2 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector2(x, y);
    }

    // Initiailize with random location & velocity
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float timeInterval = Random.Range(20, 60);
        if (timer < timeInterval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            GetComponent<Rigidbody2D>().velocity = RandomVector(-speed, speed);
        }
    }

    // Record last velocity for reflecting off walls
    private void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    // Reflect off walls
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized,
                                        collision.contacts[0].normal);
        Debug.Log(direction);
        rb.velocity = direction * Mathf.Max(speed, Random.Range(-speed, speed));
    }
}
