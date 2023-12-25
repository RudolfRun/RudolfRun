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
    public GameObject EnterCanvas;
    public GameObject LobbyCanvas;
    public GameObject GameOverCanvas;
    public GameObject GameWinCanvas;
    public GameObject Trackbg;
    public GameObject Dolf;
    public GameObject Spawner;

    bool isWin;
    bool isLose;

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
        StartCoroutine(BlackPannel.instance.FadeOut());

        EnterCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        LobbyCanvas.SetActive(false);
        GameWinCanvas.SetActive(false);
        Trackbg.SetActive(false);
        Dolf.SetActive(false);
        Spawner.SetActive(false);

        isWin = false;
        isLose = false;

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
    }

    private void FixedUpdate()
    {
        if (LobbyCanvas.activeSelf) {
            playTime -= Time.deltaTime;
            if (Level >= 0) SetLobbyObject(Level);
            if (playTime <= 0 && !isLose) {
                isLose = true;
                StartCoroutine(EndGame());
            }

        }
    }

    public void SetLobbyObject(int level)
    {
        if (level == 12 && !isWin) {
            Debug.Log("Win");
            StartCoroutine(WinGame());
            isWin = true;
            return;
        }
        if (level < 12)
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
    }

    //씬 이동 함수
    public void OnClickStartGame() {
        StartCoroutine(StartGame());
    }

    public IEnumerator StartGame() {
        yield return StartCoroutine(BlackPannel.instance.FadeIn());
        EnterCanvas.SetActive(false);
        LobbyCanvas.SetActive(true);
        Trackbg.SetActive(true);
        Dolf.SetActive(true);
        Spawner.SetActive(true);
        yield return StartCoroutine(BlackPannel.instance.FadeOut());
    }

    public IEnumerator EndGame() {
        yield return StartCoroutine(BlackPannel.instance.FadeIn());
        LobbyCanvas.SetActive(false);
        Trackbg.SetActive(false);
        Dolf.SetActive(false);
        Spawner.SetActive(false);
        GameOverCanvas.SetActive(true);
        yield return StartCoroutine(BlackPannel.instance.FadeOut());
    }

    public IEnumerator WinGame() {
        yield return StartCoroutine(BlackPannel.instance.FadeIn());
        Debug.Log("WinGame");
        LobbyCanvas.SetActive(false);
        Dolf.SetActive(false);
        Spawner.SetActive(false);
        GameWinCanvas.SetActive(true);
        yield return StartCoroutine(BlackPannel.instance.FadeOut());
    }

    public IEnumerator ReStart() {
        yield return StartCoroutine(BlackPannel.instance.FadeIn());
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
