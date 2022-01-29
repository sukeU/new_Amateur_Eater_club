using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    GameObject gameMas;
    AdjustmentValue adjValScr;

    //Audioの設定値
    AudioSource audioSource;
    AudioClip trueSweetsSE;
    AudioClip falseSweetsForkSE;
    AudioClip falseSweetsSpoonSE;
    AudioClip switchWeaponsSpoon;
    AudioClip switchWeaponsFork;

    public float test1 = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameMas = GameObject.Find("GameMaster").gameObject;
        adjValScr = gameMas.GetComponent<AdjustmentValue>();    //設定値クラス読み込み

        //Audio設定
        audioSource = GetComponent<AudioSource>();
        trueSweetsSE = adjValScr.trueSweetsSE;
        falseSweetsForkSE = adjValScr.falseSweetsForkSE;
        falseSweetsSpoonSE = adjValScr.falseSweetsSpoonSE;
        switchWeaponsSpoon = adjValScr.switchWeaponsSpoon;
        switchWeaponsFork = adjValScr.switchWeaponsFork;
        test1 = switchWeaponsSpoon.length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //スイーツを正しく食べた時
    void EatRightSweetSE()
    {
        audioSource.PlayOneShot(trueSweetsSE);
    }
    void EatWrongSweetForkSE()//間違えてForkでとってしまったとき
    {
        audioSource.PlayOneShot(falseSweetsForkSE);
    }
    void EatWrongSweetSpoonSE()//間違えてSpoonでとってしまったとき
    {
        audioSource.PlayOneShot(falseSweetsSpoonSE);
    }
    void SW_Weapons_Spoon()//Spoonへ切り替え
    {
        audioSource.PlayOneShot(switchWeaponsSpoon);
    }

    void SW_Weapons_Fork()//Forkへ切り替え
    {
        audioSource.PlayOneShot(switchWeaponsFork);
    }
    
}
