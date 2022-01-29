using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    //ゲームが終わってるか終わってないか
    bool gameMasFinishBool;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameMasFinishBool = GameObject.Find("GameMaster").GetComponent<GameMaster>().gameFinish;
    }

    void Update()
    {
        //ゲームが終わったら動かなくなる。
        gameMasFinishBool = GameObject.Find("GameMaster").GetComponent<GameMaster>().gameFinish;
        if (gameMasFinishBool) return;

        //指定したスピードから現在の速度を引いて加速力を求める
        float currentSpeed = speed - rb.velocity.magnitude;
        //調整された加速力で力を加える
        rb.AddForce(new Vector3(0, 0, currentSpeed));
    }
}