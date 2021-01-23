using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Damage;
    public float Range;
    ParticleSystem EPartical;

    public void Start()
    {
        EPartical = GetComponent<ParticleSystem>();
        GetComponent<CapsuleCollider>().radius = Range;
    }

    public void Update()
    {
        if (!EPartical.isEmitting)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
            other.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
    }
}
