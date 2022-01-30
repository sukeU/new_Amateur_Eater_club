using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itibyoutoha : MonoBehaviour
{
    float flowTime = 0.0f;
    bool start = false;
    Vector3 vec;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            start = true;
            vec = this.transform.position;
            Debug.Log($"Start! {flowTime}, {vec}");
        }
        if(start)
        {
            flowTime += Time.deltaTime;
            if (flowTime >= 1.0f)
            {
                vec = this.transform.position;
                Debug.Log($"Finish! {flowTime}, {vec}");
                start = false;
            }
        }
    }
}
