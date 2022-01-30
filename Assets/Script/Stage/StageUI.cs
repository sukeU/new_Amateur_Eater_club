using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUI : MonoBehaviour
{
    public GameObject UIObj;

    public GameObject best_text;
    public GameObject gg_text;
    public GameObject w_text;
    public GameObject endMenuButton;
    public GameObject endRetryButton;

    private void Start()
    {
        best_text.SetActive(false);
        gg_text.SetActive(false);
        w_text.SetActive(false);
        endMenuButton.SetActive(false);
        endRetryButton.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            scenePause();
        }
    }


    void scenePause()
    {
        GameObject player = GameObject.Find("Player");
        bool pauseBool = player.GetComponent<Player>().pauseBool;
        //UIObj = GameObject.Find("Canvas/PauseUI").gameObject;
        if (pauseBool)//ポーズ中なら
        {
            ContinueStage();
        }
        else
        {
            player.GetComponent<Player>().pauseBool = true;
            player.GetComponent<EatPlayer>().eatBool = false;
            player.GetComponent<ChangeSpoonOrFork>().pauseNow = true;
            UIObj.SetActive(true);
        }
        

    }

    //ゲーム終了時に呼び出される関数
    public void StageGoalUI(int Satietyval)
    {
        
        if (Satietyval >= 100) best_text.SetActive(true);
        if ((Satietyval >= 35) && (Satietyval < 90)) gg_text.SetActive(true);
        if (Satietyval < 35) w_text.SetActive(true);
        
        endMenuButton.SetActive(true);
        endRetryButton.SetActive(true);


    }

    public void ContinueStage()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Player>().pauseBool = false;
        player.GetComponent<EatPlayer>().eatBool = true;
        player.GetComponent<ChangeSpoonOrFork>().pauseNow = false;
        UIObj.SetActive(false);
    }

    public void MoveSceneMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void MoveSceneRetry()
    {
        SceneManager.LoadScene("Stage1");
    }


}
