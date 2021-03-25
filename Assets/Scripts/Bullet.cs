using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ParticleSystem tracer;
    public GameObject explosion;

    Rigidbody rb;

    public float explosion_force;
    public float explosion_range;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        tracer = GetComponent<ParticleSystem>();
    }

    public void Init(Vector2 v_i)
    {
        rb.AddForce(v_i);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Level" || collision.gameObject.tag == "Mob")
        {
            rb.velocity = Vector3.zero;
            Instantiate<GameObject>(explosion, transform.position, Quaternion.identity).GetComponent<Explosion>().Init(explosion_force, explosion_range);
        }
    }

    private void CheckForDeath()
    {
        if (tracer.isStopped)
        {
            Destroy(this.gameObject);
        }
    }

    public void Update()
    {
        CheckForDeath();
    }
}
