using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 lastVelocity;

    private Vector2 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector2(x, y);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = RandomVector(-0.75f, 0.75f);
        transform.position = new Vector2(transform.position.x + Random.Range(-8.3f, 8.3f), 
                                        transform.position.y + Random.Range(-4.6f, 4.6f));

        var particle = GetComponent<SpriteRenderer>();
        particle.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized,
                                        collision.contacts[0].normal);
        Debug.Log(direction);
        rb.velocity = direction * Mathf.Max(speed, Random.Range(-0.75f, 0.75f));
        // rb.velocity = direction * Mathf.Max(speed, speed + Random.Range(-0.5f, 0.5f));
    }
}
