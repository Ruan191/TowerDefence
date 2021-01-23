using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            GameProgress.Credits = 0;
            GameProgress.EnemiesKilled = 0;
            GameProgress.Wave = 0;

            EnemyBuff.HitPointBuff = 0;
            EnemyBuff.SpeedBuff = 0f;

            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
