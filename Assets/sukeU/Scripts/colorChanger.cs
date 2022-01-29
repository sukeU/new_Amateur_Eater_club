using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    public int setNum { get; set; }
    //RGBの値に代入
    Color32 skinColor;
    //0黒 1茶 2黄 3赤 4白 5緑
    Color32[] preset = { new Color32(0, 0, 0,255), new Color32(128, 0, 0,255), new Color32(255, 255, 0,255), new Color32(255, 0, 0,255), new Color32(255, 255, 255,255),
    new Color32(100, 255, 100,255),new Color32(0, 255, 0,255), };

    // Start is called before the first frame update
    void Start()
    {   
        ChangeColor(setNum);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeColor(1);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {

            ChangeColor(3);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

            ChangeColor(5);
        }
        // ChangeColor(skinColor);
        //PresetChange(1);
        */
    }


    public void ChangeColor(int set)
    {
        skinColor = preset[set];
        //パーティクルの色を変える
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color32(skinColor.r, skinColor.g, skinColor.b,1));
    }

}
