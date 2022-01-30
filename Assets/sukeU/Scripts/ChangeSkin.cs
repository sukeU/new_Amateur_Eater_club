using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    GameObject playerModel;
    [SerializeField]
    Texture angry_skin;//35以下
    [SerializeField]
    Texture normal_skin;
    [SerializeField]
    Texture happy_skin;//80以上
    GameObject[] skin_obj=new GameObject[3];
    EatPlayer eatplay;

    // Start is called before the first frame update
    void Start()
    {
        playerModel = gameObject.transform.GetChild(0).gameObject;
        for(int i = 0; i < playerModel.transform.childCount; i++)//playerの全ての子オブジェクトを取得する
        {
            skin_obj[i] = playerModel.transform.GetChild(i).gameObject;
        }
        
        eatplay = skin_obj[0].GetComponent<EatPlayer>();
    }

    void ClearChange(int point)
    {
        if (point < 35) {
            SkinChange(angry_skin);
        }
        else if(point >=80)
        {
            SkinChange(happy_skin);
        }
        else
        {
            SkinChange(normal_skin);
        }
    }

    void SkinChange(Texture skin)
    {
        foreach (GameObject obj in  skin_obj) {
           obj.GetComponent<MeshRenderer>().material.mainTexture = skin;
        }
    }
}
