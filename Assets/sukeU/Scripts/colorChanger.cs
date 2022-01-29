using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{

    //RGBの値に代入
    Color32 skinColor;
    //0黒 1茶 2黄 3赤 4白 5緑
    Color32[] preset = { new Color32(0, 0, 0,255), new Color32(128, 0, 0,255), new Color32(255, 255, 0,255), new Color32(255, 0, 0,255), new Color32(255, 255, 255,255),
    new Color32(100, 255, 100,255),new Color32(0, 255, 0,255), };

   
    public void ChangeColor(int setNum)
    {
        skinColor = preset[setNum];
        //パーティクルの色を変える
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color32(skinColor.r, skinColor.g, skinColor.b,1));
    }

}
