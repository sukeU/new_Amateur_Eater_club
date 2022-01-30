using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    private Rigidbody Playerrb;
    

    void Start()
    {
        Playerrb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
     if (other.tag == ("Player"))
        {
            Debug.Log("hoge");
            //PlayerのRigidbodyを停止
            Playerrb.velocity = Vector3.zero;
        }
    }
}
