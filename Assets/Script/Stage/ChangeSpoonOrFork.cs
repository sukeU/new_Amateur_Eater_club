using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpoonOrFork : MonoBehaviour
{
    public bool pauseNow = false;
    public bool changeNow = false;
    public bool gameFinish = false;
    string spoon = "Spoon";
    string fork = "Fork";
    Animator anim;
    GameObject myObj;

    void Start()
    {
        anim = GetComponent<Animator>();
        myObj = GameObject.Find("Player").gameObject;
    }

    void Update()
    {
        //チェンジアニメーション中なら入力無視
        if (changeNow || pauseNow || gameFinish) return;

        if (Input.GetMouseButtonDown(0))
        {
            if(this.gameObject.tag == spoon)    //スプーンのときの処理
            {
                this.gameObject.tag = fork;
                anim.SetTrigger(fork);
                myObj.SendMessage("SW_Weapons_Spoon");
                changeNow = true;
                return;
            }
            else if(this.gameObject.tag == fork)    //フォークのときの処理
            {
                this.gameObject.tag = spoon;
                anim.SetTrigger(spoon);
                myObj.SendMessage("SW_Weapons_Fork");
                changeNow = true;
                return;
            }
        } 
    }

    //アニメーション側でfalseにする。
    public void DonotChange()
    {
        changeNow = false;
    }
}
