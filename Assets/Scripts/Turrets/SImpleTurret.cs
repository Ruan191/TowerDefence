using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SImpleTurret : Turret
{
   // Transform _Target;

    void Start()
    {
        StartCoroutine(Fire());
        IsFollowing = true;
    }

    void Update()
    {
        if (IsFollowing == true)
        {
            PointToTarget(Target.Near);
        }
    }

    public override void Shoot()
    {
        if (CurrentTarget != null)
            CurrentTarget.GetComponent<Enemy>().TakeDamage(damage);

        SoundEffectManager.PlaySound("Shoot");
    }
}
