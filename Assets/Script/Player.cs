using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public float x_input = 1.0f;


    Animator animator;

    public float Movespeed;

    GameObject myObj;



    //ゲームが終わってるか終わってないか
    bool gameMasFinishBool;
    private Rigidbody rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameMasFinishBool = GameObject.Find("GameMaster").GetComponent<GameMaster>().gameFinish;

        animator = this.gameObject.GetComponent<Animator>();


        myObj = GameObject.Find("Player").gameObject;

    }

    void Update()
    {
        
        //ゲームが終わったら動かなくなる。
        gameMasFinishBool = GameObject.Find("GameMaster").GetComponent<GameMaster>().gameFinish;
        if (gameMasFinishBool) return;

        //自身のrigidbodyを取得
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;     //rbを初期化（無いと飛んでいく）
        float x_pos = Input.mousePosition.x;
        float xVec = 0.0f;
        
        if (x_pos <= Screen.width / 5 * 2) 
        {
            float pom = x_pos / (Screen.width / 5*2) - 1; //X領域の割合を計算、100％で掛ける
            if (pom <= -1.0f) pom = -1.0f;    //100%を超えたら1に固定
            xVec = x_input * pom;           //入力するベクトルに割合をかける
            Debug.Log("←←←←←←←"+(x_pos/(Screen.width / 3)-1)+"  xVec:"+xVec);
        }
        else if(x_pos >= Screen.width / 5 * 3)
        {
            float pom = (x_pos - Screen.width / 5*3) / Screen.width / 5 * 10 - 0.1f;
            if (pom >= 1.0f) pom = 1.0f;//100%を超えたら
            xVec = x_input * pom;
            Debug.Log("→→→→→→→→→→" + ((x_pos - Screen.width / 3 * 2) / Screen.width / 3*10) + " xVec:" + xVec);
        }



        //指定したスピードから現在の速度を引いて加速力を求める
        float currentSpeed = speed - rb.velocity.magnitude;
        //調整された加速力で力を加える
        //rb.AddForce(new Vector3(xVec*Time.deltaTime, 0, currentSpeed*Time.deltaTime));    //rigidbodyで加算処理
        this.gameObject.transform.position += (new Vector3(xVec * Time.deltaTime, 0, currentSpeed * Time.deltaTime));   //transformで加算処理

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Goal"))
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            
            //ゴールアニメーション再生
            animator.SetTrigger("Goal");
            myObj.SendMessage("SW_Weapons_Spoon");

        }
    }
}