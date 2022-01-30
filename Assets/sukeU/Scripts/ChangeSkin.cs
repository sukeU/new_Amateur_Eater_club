using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField]
    Texture angry_skin;//35以下
    Texture normal_skin;
    Texture happy_skin;//80以上
    GameObject skin_obj;
    EatPlayer eatplay;

    // Start is called before the first frame update
    void Start()
    {
        skin_obj = gameObject.transform.GetChild(0).gameObject;
        eatplay = skin_obj.GetComponent<EatPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClearChange()
    {
        //SkinChange(normal_skin)
    }

    void SkinChange(Texture skin)
    {
        skin_obj.GetComponent<Renderer>().material.mainTexture = skin; 
    }
}
