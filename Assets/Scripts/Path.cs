using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public static GameObject[] Points;
    void Awake()
    {
        
        Points = new GameObject[GameObject.FindGameObjectsWithTag("Point").Length];
        Points = GameObject.FindGameObjectsWithTag("Point");
    }
}
