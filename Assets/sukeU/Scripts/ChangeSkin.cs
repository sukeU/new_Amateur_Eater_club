using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField]
    Texture angry_skin;//35以下
    Texture normal_skin;
    Texture happy_skin;//80以上
    GameObject[] skin_obj;
    EatPlayer eatplay;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            skin_obj[i] = gameObject.transform.GetChild(i).gameObject;
        }
        
        eatplay = skin_obj[0].GetComponent<EatPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClearChange()
    {
        if (eatplay.nowPoint < 35) {
            SkinChange(angry_skin);
        }
        else if(eatplay.nowPoint >=80)
        {
            SkinChange(happy_skin);
        }
        else
        {
            SkinChange(normal_skin);
        }
        //SkinChange(normal_skin)
    }

    void SkinChange(Texture skin)
    {
        foreach (GameObject obj in  skin_obj) {
           obj.GetComponent<Renderer>().material.mainTexture = skin;
        }
    }
}
