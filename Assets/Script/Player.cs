using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
<<<<<<< HEAD


    Animator animator;
=======
    public float Movespeed;

    GameObject myObj;

>>>>>>> 9229e58736f5444579eb46c85c0df0d4f5a1ce52

    //ゲームが終わってるか終わってないか
    bool gameMasFinishBool;
    private Rigidbody rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameMasFinishBool = GameObject.Find("GameMaster").GetComponent<GameMaster>().gameFinish;
<<<<<<< HEAD
        animator = GetComponent<Animator>();
        
=======
        myObj = GameObject.Find("Player").gameObject;
>>>>>>> 9229e58736f5444579eb46c85c0df0d4f5a1ce52
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
            //PlayerのRigidbodyを停止
<<<<<<< HEAD
            
            rb.constraints = RigidbodyConstraints.FreezePosition;
            

            animator.Play("");
=======
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            myObj.SendMessage("SW_Weapons_Spoon");
>>>>>>> 9229e58736f5444579eb46c85c0df0d4f5a1ce52
        }
    }
}