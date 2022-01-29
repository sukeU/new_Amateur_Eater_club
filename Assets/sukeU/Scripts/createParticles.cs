using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createParticles : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
