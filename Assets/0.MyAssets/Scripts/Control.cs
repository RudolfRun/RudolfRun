using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Animator animator;
    public bool LeftMove = false;
    public bool RightMove = false;
    Vector3 moveVelocity = Vector3.zero;
    public float moveSpeed = 3;
    // Start is called before the first frame update
    private Vector3 pos;
    private float maxYPosition;
    private float minYPosition;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftMove)
        {
            animator.SetBool("Direction",false);
            moveVelocity = new Vector3 (0,-1f, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        }   
        if (RightMove)
        {
            animator.SetBool("Direction",false);
            moveVelocity = new Vector3 (0, 1f, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        }

        if (transform.position.y > -2.5f)
        {
            transform.position = new Vector3(transform.position.x, -2.5f, transform.position.z);
        }

        if (transform.position.y < -6.0f)
        {
            transform.position = new Vector3(transform.position.x, -6.0f, transform.position.z);
        }
    }

    public void ClickUp(bool isUp)
    {
        if(isUp)
        {
            RightMove = false;
        }
        else
        {
            LeftMove = false;
        }

    }

    public void ClickDown(bool isUp)
    {
        if(isUp)
        {
            RightMove = true;
        }
        else
        {
            LeftMove = true;
        }
    }


}