using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_ : MonoBehaviour
{
    GameObject Dolf;
    Control control;

    // Start is called before the first frame update
    void Start()
    {
        Dolf = GameObject.Find("dolf");
        control = Dolf.GetComponent<Control>();
    }

    // Update is called once per frame
    void Update()
    {

    }

        public void LeftBtnDown()
        {
            control.LeftMove=true;
        }
        public void LeftBtnUp()
        {
            control.LeftMove=false;
        }
        public void RightBtnUp()
        {
            control.RightMove=true;
        }
        public void RightBtnDown()
        {
            control.RightMove=false;
        }
}
