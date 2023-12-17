using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timeText;
    public static UIManager instance;
    float exp;
    int level;
    float time;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        expText.text = "0/100";
    }

//Exp float
    void Update()
    {
        //레벨(레벨은 -1부터 시작)
        if (level != GameManager.instance.Level) {
            level = (GameManager.instance.Level) + 2;
            levelText.text = level.ToString();
        }
        //경험치
        if (exp != GameManager.instance.Exp) {
            exp = GameManager.instance.Exp;
            expText.text = ((int)(exp*100)).ToString() + "/100";
        }
        if (time != GameManager.instance.playTime) {
            time = GameManager.instance.playTime;
            if (time <= 0) {
                timeText.text = "0";
                GameManager.instance.EndGame();
            }
            timeText.text = ((int)(time)).ToString();
        }
    }

    public void OnClickRetryButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
