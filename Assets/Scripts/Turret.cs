using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    public enum Target
    {
        Near,
        Far
    }

    public List<Transform> EnemiesInRange = new List<Transform>();
    public int EnemyIndex = 0;

    [SerializeField] float Damage, MaxDamge, RateOfFire, MaxFireRate, Range, MaxRange;
    public int Limit, Price;

    int EnemiesKilled = 0;

    public bool EnableAttack = true;
    public bool IsFollowing;

    public Transform Rotator;
    public GameObject CurrentTarget;

    Vector3 Dir;

    public int kills
    {
        get => EnemiesKilled;
    }

    public float range
    {
        get => Range;
        set => Range = value > MaxRange ? Range = MaxRange : Range = value;
    }

    public float damage
    {
        get => Damage;
        set => Damage = value > MaxDamge ? Damage = MaxDamge : Damage = value;
    }

    public float fire_rate
    {
        get => RateOfFire;
        set => RateOfFire = value > MaxFireRate ? RateOfFire = MaxFireRate : RateOfFire = value;
    }

    public float limit
    {
        get => Limit;
    }

    protected void PointToTarget(Target Aim)
    {     
        
        if (Enemy.List.Count > 0)
        {
            switch (Aim)
            {
                case Target.Near:
                    if (Enemy.List != null)
                    {
                        for (int i = 0; i < Enemy.List.Count; i++)
                        {
                            for (int j = 0; j < Enemy.List.Count; j++)
                            {
                                TargetingCondition(i ,GetMagnitudeAtIndex(i) < GetMagnitudeAtIndex(j) || Enemy.List.Count == 1);
                            }
                        }
                    }
                    break; 
                case Target.Far:
                    if (Enemy.List != null)
                    {
                        for (int i = 0; i < Enemy.List.Count; i++)
                        {
                            for (int j = 0; j < Enemy.List.Count; j++)
                            {
                                TargetingCondition(i, GetMagnitudeAtIndex(i) > GetMagnitudeAtIndex(j) || Enemy.List.Count == 1);
                            }
                        }
                    }
                    break;
            }

            Quaternion LookDir = Quaternion.LookRotation(Dir);
            Vector3 Rotation = LookDir.eulerAngles;

            Rotator.rotation = Quaternion.Euler(0, Rotation.y, 0);          
        }
    }


    float GetMagnitudeAtIndex(int index) => (Enemy.List[index].transform.position - Rotator.position).magnitude;

    void TargetingCondition(int ComparasionIndex,bool Condition)
    {
        if (Condition)
        {
            if (GetMagnitudeAtIndex(ComparasionIndex) <= Range)
            {
                Dir = Enemy.List[ComparasionIndex].transform.position - Rotator.position;
                CurrentTarget = Enemy.List[ComparasionIndex];
            }
        }
    }

    public abstract void Shoot();

    public void SetRange(float Range)
    {
        range = Range;
    }

    bool InRange() => (CurrentTarget.transform.position - Rotator.position).magnitude <= Range;


    public IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(RateOfFire);

            if (CurrentTarget != null && InRange())
            {
                Shoot();
            }         
        }
    }
}
