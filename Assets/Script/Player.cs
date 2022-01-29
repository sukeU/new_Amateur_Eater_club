using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;

    Animator animator;

    public float Movespeed;

    GameObject myObj;

    AudioSource GoalSE;

    //ゲームが終わってるか終わってないか
    bool gameMasFinishBool;
    private Rigidbody rb;

    public int ItemCount;

    public GameObject best_text;
    public GameObject gg_text;
    public GameObject w_text;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
        gameMasFinishBool = GameObject.Find("GameMaster").GetComponent<GameMaster>().gameFinish;

        

        GoalSE = GameObject.Find("GameMaster").GetComponent<AdjustmentValue>().gameClearBGM;
        myObj = GameObject.Find("Player").gameObject;

        best_text.SetActive(false);
        gg_text.SetActive(false);
        w_text.SetActive(false);
    }

    void Update()
    {
        
        //ゲームが終わったら動かなくなる。
        gameMasFinishBool = GameObject.Find("GameMaster").GetComponent<GameMaster>().gameFinish;
        if (gameMasFinishBool) return;

        //マウスのデルタ値を取得
        Vector3 mouseDelta = Mouse.current.delta.ReadValue();
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;     //rbを初期化（無いと飛んでいく）
        float xSpeed = mouseDelta.x ;
        

        //指定したスピードから現在の速度を引いて加速力を求める
        float currentSpeed = speed - rb.velocity.magnitude;
        //調整された加速力で力を加える
        rb.AddForce(new Vector3(xSpeed, 0, currentSpeed));
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Goal"))
        {
            //Result画像表示
            if (ItemCount >= 21) best_text.SetActive(true);
            if ((ItemCount >= 12) && (ItemCount < 21)) gg_text.SetActive(true);
            if ((ItemCount >= 0) && (ItemCount < 12)) w_text.SetActive(true);

            //PlayerのRigidbodyを停止
            rb.constraints = RigidbodyConstraints.FreezePositionX |
                             RigidbodyConstraints.FreezePositionZ |
                             RigidbodyConstraints.FreezeRotationY |
                             RigidbodyConstraints.FreezeRotationZ;
            
            //ゴールアニメーション再生
            animator.SetTrigger("Goal");

            GoalSE.Play();
            myObj.SendMessage("SW_Weapons_Spoon");

        }

        if (other.tag == ("Item"))
        {
            ItemCount++;
        }
       
    }
   
}
