using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustmentValue : MonoBehaviour
{
    public int maxSatiety = 50;
    public int startSatiety = 25;
    public float delayDecreaseSatietyTime = 2.0f;

    public AudioClip playNowBGM;
    public AudioClip gameClearBGM;
    public AudioClip gameOverBGM;

    //最終評価の効果音
    public AudioClip satisfactionRatingSE;
    public AudioClip normalRatingSE;
    public AudioClip dissatisfactionRatingSE;

    //スイーツの正誤判定の効果音
    public AudioClip trueSweetsSE;
    public AudioClip falseSweetsSpoonSE;
    public AudioClip falseSweetsForkSE;

    //スプーンの切り替え
    public AudioClip switchWeaponsSpoon;
    public AudioClip switchWeaponsFork;

    //その他SE
    public AudioClip clickSE;   //ボタンを押したときの音
    public AudioClip whistleSE; //ホイッスル
    public AudioClip goalWhistleSE; //ゴールした時のホイッスル

}
