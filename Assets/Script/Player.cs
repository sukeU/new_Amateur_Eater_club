using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public float Movespeed;

    GameObject myObj;


    //ゲームが終わってるか終わってないか
    bool gameMasFinishBool;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameMasFinishBool = GameObject.Find("GameMaster").GetComponent<GameMaster>().gameFinish;
        myObj = GameObject.Find("Player").gameObject;
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
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            myObj.SendMessage("SW_Weapons_Spoon");
        }
    }
}