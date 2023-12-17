using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] tracks; //트랙위치
    public SpawnInfo[] spawners; //장애물 프리팹들

    private float timer;

    void Start()
    {
        foreach(var spawn in spawners) {
            StartCoroutine(SpawnRoutine(spawn));
        }
    }

    IEnumerator SpawnRoutine(SpawnInfo spawnInfo) {
        while(true) {
            float spawnTime = Random.Range(spawnInfo.minSpawnTime, spawnInfo.maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            
        int trackIndex = Random.Range(0, tracks.Length);
        Vector3 spawnPos = tracks[trackIndex].position;
        spawnPos.x = GetRightEdgeScreen();
        Instantiate(spawnInfo.prefab, spawnPos, Quaternion.identity);
        }
    }

    float GetRightEdgeScreen()
    {
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        return rightTop.x;
    }

}
