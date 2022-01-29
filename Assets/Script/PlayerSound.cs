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
    AudioClip falseSweetsSE;
    AudioClip switchWeaponsSpoon;
    AudioClip switchWeaponsFolk;

    public float test1 = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameMas = GameObject.Find("GameMaster").gameObject;
        adjValScr = gameMas.GetComponent<AdjustmentValue>();    //設定値クラス読み込み

        //Audio設定
        audioSource = GetComponent<AudioSource>();
        trueSweetsSE = adjValScr.trueSweetsSE;
        falseSweetsSE = adjValScr.falseSweetsSE;
        switchWeaponsSpoon = adjValScr.switchWeaponsSpoon;
        switchWeaponsFolk = adjValScr.switchWeaponsFolk;
        test1 = switchWeaponsSpoon.length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EatRightSweetSE()
    {
        audioSource.PlayOneShot(switchWeaponsSpoon);
    }
    void EatWrongSweetSE()
    {
        audioSource.PlayOneShot(switchWeaponsFolk);
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
