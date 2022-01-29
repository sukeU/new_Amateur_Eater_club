using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpoonOrFork : MonoBehaviour
{
    public bool changeNow = false;
    string spoon = "Spoon";
    string fork = "Fork";
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //今トリガーが勝手に入って反転することがある。

        //チェンジアニメーション中なら入力無視
        if (changeNow) return;

        if (Input.GetMouseButtonDown(0))
        {
            if(this.gameObject.tag == spoon)
            {
                this.gameObject.tag = fork;
                anim.SetTrigger(fork);
                changeNow = true;
                return;
            }
            else if(this.gameObject.tag == fork)
            {
                this.gameObject.tag = spoon;
                anim.SetTrigger(spoon);
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
