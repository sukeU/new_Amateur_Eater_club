using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatPlayer : MonoBehaviour
{
    //満腹値
    int satietyVal;
    GameObject gameMas;

    //仮のスライダー
    Slider slider;
    AdjustmentValue adjValScr;

    void Start()
    {
        gameMas = GameObject.Find("GameMaster").gameObject;
        adjValScr = gameMas.GetComponent<AdjustmentValue>();
        //初期値
        satietyVal = adjValScr.startSatiety;

        slider = GameObject.Find("Canvas/SatietySlider").GetComponent<Slider>();
        slider.maxValue = adjValScr.maxSatiety;
    }

    void Update()
    {
        //空腹になったらゲームオーバー
        if (satietyVal < 0)
        {
            gameMas.SendMessage("NonSatietyGameOver");
        }
        //値越え防止
        if (satietyVal > adjValScr.maxSatiety) satietyVal = adjValScr.maxSatiety;

        slider.value = satietyVal;
    }

    //きちんと食べれたときに呼ばれる
    void EatRightSweet(int fibSatiety)
    {
        satietyVal += fibSatiety;
    }

    //間違えたもので食べた時に呼ばれる
    void EatWrongSweet(int fibSatiety)
    {
        //仮で減らしてる。
        satietyVal -= fibSatiety;
    }
}
