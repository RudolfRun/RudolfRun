using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    GameObject[] lobbyObject; 
    public float Exp { set; get; }
    public int Level { set; get; }

    // public int Level;
    public GameObject lobbyObjects;
    GameObject[] lobbyObjectArr; 
    public float playTime { set; get; }

    public Image expBarImage;
    public float testExp;

    public GameObject GameOverCanvas;

    private void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;

    }

    void Start()
    {
        GameOverCanvas.SetActive(false);

        Exp = 0;
        Level = -1;
        playTime = 60f;
        int lobbyLength = lobbyObjects.transform.childCount;
        lobbyObjectArr = new GameObject[lobbyLength];
        expBarImage.fillAmount = 0f;

        for (int i=0; i < lobbyLength; i++)
        {
            lobbyObjectArr[i] = lobbyObjects.transform.GetChild(i).gameObject;
            lobbyObjectArr[i].SetActive(false);
        }
    }

    void Update()
    {
        if (testExp > 0) {
            UpdateExp(testExp);
            testExp = 0;
        }

        if (Level >= 0) SetLobbyObject(Level);
        
    }

    private void FixedUpdate()
    {
        playTime -= Time.deltaTime;
        if (playTime <= 0) EndGame();
    }

    public void SetLobbyObject(int level)
    {
        if (level == 12) {
            WinGame();
            return;
        }
        lobbyObjectArr[level].SetActive(true);
    }

    public void SetExp(float exp)
    {
        Exp = exp;
    }

    //exp에 0.25씩 넣기
    public void UpdateExp(float exp)
    {
        Exp += exp;
        expBarImage.fillAmount = Exp;
        Debug.Log(expBarImage.fillAmount);

        if (Exp >= 1)
        {
            Level++;
            SetExp(0);
            UIManager.instance.levelText.text = "0/100";
            expBarImage.fillAmount = 0f;
        }
    }

    public void UpdateTime(float time)
    {
        playTime += time;
        if (playTime < 0) {
            EndGame();
        }
    }

    public void EndGame() {
        Debug.Log("게임오버");
        // Application.Quit();
        GameOverCanvas.SetActive(true);
        // SceneManager.LoadScene("GameOverScene");
    }

    public void WinGame() {
        SceneManager.LoadScene("2.Win");
    }

}
