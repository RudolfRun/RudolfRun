using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDie : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject, .1f);
    }
}
