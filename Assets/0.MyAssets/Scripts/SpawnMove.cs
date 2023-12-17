using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMove : MonoBehaviour
{
    float speed;
    public SpawnInfo spawnInfo;
    void Start()
    {   
        speed = spawnInfo.speed;
        // Debug.Log(speed);
    }


    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
