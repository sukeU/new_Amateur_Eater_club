using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatPlayer : MonoBehaviour
{
    //満腹値
    int satietyVal;
    public int nowPoint { get { return satietyVal; } }
    float delayDecreaseSatietyTime;     //体力自然減少初期値
    float nowTime = 100.0f;             //最後に食べてからの時間
    float decreaseSatietyTimeVal = 0.0f;//減少の時間をカウント
    public int decreaseSatiety = 1;     //体力減少値
    GameObject gameMas;
    GameObject myObj;   //自身のオブジェクト

    //間違えて食べた時にどのくらいの割合で減るか
    public float discreRatio = 0.5f;

    //仮のスライダー
    Slider slider;
    AdjustmentValue adjValScr;
    PlayerSound plSound;



    void Start()
    {
        gameMas = GameObject.Find("GameMaster").gameObject;
        adjValScr = gameMas.GetComponent<AdjustmentValue>();    //設定値クラス読み込み
        myObj = GameObject.Find("Player").gameObject;
        plSound = gameMas.GetComponent<PlayerSound>();    //設定値クラス読み込み

        //初期値
        satietyVal = adjValScr.startSatiety;
        delayDecreaseSatietyTime = adjValScr.delayDecreaseSatietyTime;

        slider = GameObject.Find("Canvas/SatietySlider").GetComponent<Slider>();    //スライダーを取得
        slider.maxValue = adjValScr.maxSatiety; //スライダーの初期値設定

        
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
        myObj.SendMessage("EatRightSweetSE");

    }

    //間違えたもので食べた時に呼ばれる
    void EatWrongSweetFork(int fibSatiety)
    {

        //Inspectorで指定された割合の満腹度を減らしてる。
        satietyVal -= (int)((float)(fibSatiety) * discreRatio);
        myObj.SendMessage("EatWrongSweetForkSE");

    }
    void EatWrongSweetSpoon(int fibSatiety)
    {

        //Inspectorで指定された割合の満腹度を減らしてる。
        satietyVal -= (int)((float)(fibSatiety) * discreRatio);
        myObj.SendMessage("EatWrongSweetSpoonSE");

    }

}
