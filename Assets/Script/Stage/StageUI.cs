using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUI : MonoBehaviour
{
    public GameObject UIObj;

    private void Start()
    {
        
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


}
