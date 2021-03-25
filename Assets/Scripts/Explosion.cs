using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public LayerMask collision_mask;

    public void Init(float force, float range)
    {
        var sz = GetComponent<ParticleSystem>().sizeOverLifetime;
        sz.sizeMultiplier = range;

        ApplyExplosion(force, range);
    }

    private void ApplyExplosion(float force, float range) {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, collision_mask);

        foreach (Collider col in hitColliders)
        {
            col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, range);
        }
    }

    private void Update()
    {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(gameObject);
        }
    }


}
