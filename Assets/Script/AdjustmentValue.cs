using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustmentValue : MonoBehaviour
{
    public int maxSatiety = 50;
    public int startSatiety = 25;
    public float delayDecreaseSatietyTime = 2.0f;

    public AudioSource playNowBGM;
    public AudioSource gameClearBGM;
    public AudioSource gameOverBGM;

    //最終評価の効果音
    public AudioClip satisfactionRatingSE;
    public AudioClip NormalRatingSE;
    public AudioClip dissatisfactionRatingSE;

    //スイーツの正誤判定の効果音
    public AudioClip trueSweetsSE;
    public AudioClip falseSweetsSE;

    //スプーンの切り替え
    public AudioClip switchWeaponsSpoon;
    public AudioClip switchWeaponsFolk;

}
