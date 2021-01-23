using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnDeath += Enemy_OnDeath;
    }

    private void Enemy_OnDeath(object sender, System.EventArgs e)
    {
        if (Enemy.Count == 0)
        {
            GameProgress.Wave++;
            UI.UpdateProgressState();

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                Destroy(enemy);

            EnemySpawner.EnemyLimit += 2;
            EnemySpawner.SpawnRate -= 0.25f;

            EnemyBuff.HitPointBuff += 5;
            EnemyBuff.SpeedBuff += 0.3f;
        }
    }
}
