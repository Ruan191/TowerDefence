using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTurret : Turret
{
    GameObject Projectile;

    void Start()
    {
        Projectile = Resources.Load<GameObject>("Explosion");
        StartCoroutine(Fire());
        SetRange(range);
        IsFollowing = true;
    }

    // Update is called once per frame
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
        {
            Instantiate(Projectile, CurrentTarget.transform.position, Projectile.transform.rotation, null);
            SoundEffectManager.PlaySound("Explosion");
        }
    }
}
