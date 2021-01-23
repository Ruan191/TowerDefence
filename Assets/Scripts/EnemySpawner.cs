using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int Wave;
    GameObject _Enemy;
    public static float SpawnRate = 2f;
    public static int EnemyLimit = 10;

    void Start()
    {
        UI.UpdateProgressState();
        Enemy.OnDeath += Enemy_OnDeath; ;
        _Enemy = Resources.Load<GameObject>("Enemy");
        StartCoroutine(Spawn());
    }

    private void Enemy_OnDeath(object sender, System.EventArgs e)
    {
        if (Enemy.Count == 0)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        int Spawned = 0;
        yield return new WaitForSeconds(5f);
        while (Spawned < EnemyLimit)
        {
            yield return new WaitForSeconds(SpawnRate = SpawnRate > 0.5f ? SpawnRate = SpawnRate : SpawnRate = 0.5f);
            Instantiate(_Enemy, transform.position, transform.rotation, transform);
            Spawned++;
        }
    }
}
