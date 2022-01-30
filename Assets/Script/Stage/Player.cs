using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;

    public float x_input = 1.0f;
    public bool pauseBool = false;


    Animator animator;
    GameObject myObj;


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
        if (pauseBool) return; //ポーズ中ならリターン
        Move();
        

    }

    void Move()
    {
        //自身のrigidbodyを取得
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;     //rbを初期化（無いと飛んでいく）
        float x_pos = Input.mousePosition.x;
        float xVec = 0.0f;

        if (x_pos <= Screen.width / 5 * 2)
        {
            float pom = x_pos / (Screen.width / 5 * 2) - 1; //X領域の割合を計算、100％で掛ける
            if (pom <= -1.0f) pom = -1.0f;    //100%を超えたら1に固定
            xVec = x_input * pom;           //入力するベクトルに割合をかける
            Debug.Log("←←←←←←←" + (x_pos / (Screen.width / 3) - 1) + "  xVec:" + xVec);
        }
        else if (x_pos >= Screen.width / 5 * 3)
        {
            float pom = (x_pos - Screen.width / 5 * 3) / Screen.width / 5 * 10 - 0.1f;
            if (pom >= 1.0f) pom = 1.0f;//100%を超えたら
            xVec = x_input * pom;
            Debug.Log("→→→→→→→→→→" + ((x_pos - Screen.width / 3 * 2) / Screen.width / 3 * 10) + " xVec:" + xVec);
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

            //Result画像表示
            if (ItemCount >= 21) best_text.SetActive(true);
            if ((ItemCount >= 12) && (ItemCount < 21)) gg_text.SetActive(true);
            if ((ItemCount >= 0) && (ItemCount < 12)) w_text.SetActive(true);
            GameObject.Find("GameMaster").GetComponent<GameMaster>().gameFinish = true;


            myObj.SendMessage("GoalWhistleSE");
            //ゴールアニメーション再生
            animator.SetTrigger("Goal");


            rb.constraints = RigidbodyConstraints.FreezePosition;
            
        }

        if (other.tag == ("Item"))
        {
            ItemCount++;
        }
       
    }
   
}
