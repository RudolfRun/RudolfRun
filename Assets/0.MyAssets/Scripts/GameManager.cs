using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] lobbyObject; 
    public int Money { set; get; }
    // public int Level { set; get; }
    public int Level;
    public GameObject lobbyObjects;
    GameObject[] lobbyObjectArr; 
    float playTime;

    void Start()
    {
        Money = 0;
        Level = 0;
        playTime = 60f;
        int lobbyLength = lobbyObjects.transform.childCount;
        for (int i=0; i < lobbyLength; i++)
        {
            lobbyObjectArr[i] = lobbyObjects.transform.GetChild(i).gameObject;
            lobbyObjectArr[i].SetActive(false);
        }
    }


    void Update()
    {
        SetLobbyObject(Level);
    }

    private void FixedUpdate()
    {
        playTime -= Time.deltaTime;
    }

    public void SetLobbyObject(int level)
    {
        lobbyObjectArr[level].SetActive(true);
    }

}
