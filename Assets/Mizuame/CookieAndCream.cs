using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieAndCream : MonoBehaviour
{
    GameObject prefab;
    public float kankaku = 2.1f;
    public int num = 2;

    void Start()
    {
        prefab = transform.Find("CookieAndCream").gameObject;
        for (int i = 1; i < num + 1; i++)
        {
            Instantiate(prefab, new Vector3(prefab.transform.position.x, prefab.transform.position.y, prefab.transform.position.z + kankaku * (float)i), Quaternion.identity, this.transform);
        }
        Destroy(this);
    }
}
