using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    public void scenePause()
    {
        GameObject player = GameObject.Find("Player");
        bool pauseBool = player.GetComponent<Player>().pauseBool;
        if (pauseBool)//ポーズ中なら
        {
            player.GetComponent<Player>().pauseBool = false;
            player.GetComponent<EatPlayer>().eatBool = true;
            player.GetComponent<ChangeSpoonOrFork>().pauseNow = false;
        }
        else
        {
            player.GetComponent<Player>().pauseBool = true;
            player.GetComponent<EatPlayer>().eatBool = false;
            player.GetComponent<ChangeSpoonOrFork>().pauseNow = true;
        }

    }


}
