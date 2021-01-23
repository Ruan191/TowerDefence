using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event EventHandler OnDeath;

    public float HitPoint;
    public float MaxHitPoint;
    public float Deffence;
    public float MaxDeffence;
    public float Speed;
    public bool IsDead;
    public int Value;
    Vector3 Dir;

    public static int SpawnNumber;
    public static List<GameObject> List = new List<GameObject>();
    public static int Count;
    ParticleSystem Particle;

    public float hitpoint
    {
        get => HitPoint;
        set => HitPoint = value > MaxHitPoint ? HitPoint = MaxHitPoint : HitPoint = value;
    }
    
    public float deffence
    {
        get => Deffence;
        set => Deffence = value > MaxDeffence ? Deffence = MaxDeffence : Deffence = value;
    }
    
    public void TakeDamage(float Damage)
    {
        float ReducedDamage = Damage * (Deffence / 100);
        HitPoint -= Damage - ReducedDamage;

        if (HitPoint <= 0 && !IsDead)
        {
            IsDead = true;
            Count--;
            GameProgress.Credits += Value;
            GameProgress.EnemiesKilled++;
            UI.UpdateProgressState();
            Particle.Play();
            GetComponent<MeshFilter>().mesh = null;
            List.Remove(gameObject);
            OnDeath(this, EventArgs.Empty);           
        }
            
    }

    public void Start()
    {
        List.Add(gameObject);
        Count++;
        SpawnNumber++;
        name += SpawnNumber;

        HitPoint += EnemyBuff.HitPointBuff;
        Speed += EnemyBuff.SpeedBuff;
    }

    public void Awake()
    {
        Particle = GetComponent<ParticleSystem>();
        Particle.Stop();
    }

    // Update is called once per frame

    int PointIndex = 0;
    void Update()
    {
        if (IsDead)
            return;

        Dir = transform.position - Path.Points[PointIndex].transform.position;
        if (Dir.magnitude < 0.2f && PointIndex != Path.Points.Length - 1)
            PointIndex++;

        transform.Translate(-Dir.normalized * Speed * Time.deltaTime, Space.World);
    }
}
