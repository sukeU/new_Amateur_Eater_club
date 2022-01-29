using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    GameObject gameMas;
    AdjustmentValue adjValScr;

    //Audioの設定値
    AudioSource audioSource;
    AudioClip playNowBGM;
    AudioClip gameClearBGM;
    AudioClip gameOverBGM;

    public bool gameFinish = false;


    // Start is called before the first frame update
    void Start()
    {
        gameMas = this.gameObject;
        adjValScr = gameMas.GetComponent<AdjustmentValue>();    //設定値クラス読み込み

        //Audio設定
        audioSource = GetComponent<AudioSource>();
        playNowBGM = adjValScr.playNowBGM;
        gameClearBGM = adjValScr.gameClearBGM;
        gameOverBGM = adjValScr.gameOverBGM;
        audioSource.PlayOneShot(playNowBGM);
        
    }

    void NonSatietyGameOver()
    {
        gameFinish = true;
    }
}
