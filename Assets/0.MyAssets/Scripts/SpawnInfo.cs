using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnInfo 
{
    public GameObject prefab;
    public float minSpawnTime;
    public float maxSpawnTime;
    public string tag;
    public float speed;
}
