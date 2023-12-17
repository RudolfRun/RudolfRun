using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float speed = 10.0f;
    private Animator animator;
    [SerializeField] int jumpTime;
    void Awake() {
        instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other) {
    // 트리거 이벤트 로직
        // Debug.Log("트리거 이벤트 발생");
        if (other.tag == "LittleStar") {
            print("별먹어!");
            GameManager.instance.UpdateExp(0.2f);
            Destroy(other.gameObject, .1f);
        } else if (other.tag == "MiddleStar") {
            print("중간별먹어!");
            GameManager.instance.UpdateExp(0.5f);
            Destroy(other.gameObject, .1f);  
        } else if (other.tag == "BigStar") {
            print("큰별먹어!");
            GameManager.instance.UpdateExp(0.8f);
            Destroy(other.gameObject, .1f);  
        } else if (other.tag == "TriJelly") {
            print("아파!");
            GameManager.instance.UpdateTime(-jumpTime);
            Destroy(other.gameObject, .1f);
        } else if (other.tag == "Thorn") {
            print("아파!");
            GameManager.instance.UpdateTime(-jumpTime);
            Destroy(other.gameObject, .1f);
        } else if (other.tag == "SnowBall") {
            print("아파!");
            GameManager.instance.UpdateTime(-jumpTime);
            Destroy(other.gameObject, .1f);
        } else if (other.tag == "HourGlass") {
            print("아파!");
            GameManager.instance.UpdateTime(jumpTime);
            Destroy(other.gameObject, .1f);
        }
    }

}
