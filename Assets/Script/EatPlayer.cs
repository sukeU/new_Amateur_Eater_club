﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatPlayer : MonoBehaviour
{
    //満腹値
    int satietyVal;
    float delayDecreaseSatietyTime;     //体力自然減少初期値
    float nowTime = 100.0f;             //最後に食べてからの時間
    float decreaseSatietyTimeVal = 0.0f;//減少の時間をカウント
    public int decreaseSatiety = 1;     //体力減少値
    GameObject gameMas;

    //仮のスライダー
    Slider slider;
    AdjustmentValue adjValScr;

    //Audioの設定値
    AudioSource audioSource;
    AudioClip trueSweetsSE;
    AudioClip falseSweetsSE;
    AudioClip switchWeaponsSpoon;
    AudioClip switchWeaponsFolk;

    void Start()
    {
        gameMas = GameObject.Find("GameMaster").gameObject;
        adjValScr = gameMas.GetComponent<AdjustmentValue>();    //設定値クラス読み込み
        //初期値
        satietyVal = adjValScr.startSatiety;
        delayDecreaseSatietyTime = adjValScr.delayDecreaseSatietyTime;

        slider = GameObject.Find("Canvas/SatietySlider").GetComponent<Slider>();    //スライダーを取得
        slider.maxValue = adjValScr.maxSatiety; //スライダーの初期値設定

        //Audio設定
        audioSource = GetComponent<AudioSource>();
        trueSweetsSE = adjValScr.trueSweetsSE;
        falseSweetsSE = adjValScr.falseSweetsSE;
        switchWeaponsSpoon = adjValScr.switchWeaponsSpoon;
        switchWeaponsFolk = adjValScr.switchWeaponsFolk;
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
        nowTime -= Time.deltaTime;
        //食べてから指定時間がたった時
        if (nowTime < 0)
        {
            if (decreaseSatietyTimeVal >= 1.0)
            {
                satietyVal -= decreaseSatiety;  //体力を減少
                decreaseSatietyTimeVal = 0.0f;  //秒換算をリセット
            }
            else
            {
                decreaseSatietyTimeVal += Time.deltaTime;   //秒を加算
            }
        }
    }

    //きちんと食べれたときに呼ばれる
    void EatRightSweet(int fibSatiety)
    {
        satietyVal += fibSatiety;
        nowTime = delayDecreaseSatietyTime; //食べてからの時間をリセット
        audioSource.PlayOneShot(trueSweetsSE);
        
    }

    //間違えたもので食べた時に呼ばれる
    void EatWrongSweet(int fibSatiety)
    {
        //仮で減らしてる。
        satietyVal -= fibSatiety;
        audioSource.PlayOneShot(falseSweetsSE);

    }

    void SW_Weapons_Spoon()
    {
        audioSource.PlayOneShot(switchWeaponsSpoon);
    }

    void SW_Weapons_Folk()
    {
        audioSource.PlayOneShot(switchWeaponsFolk);
    }
}
