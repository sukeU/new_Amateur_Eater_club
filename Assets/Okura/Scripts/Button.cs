using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button: MonoBehaviour
{
    public void OnClick(string objectname)
    {
        // ボタンごとに分岐
        if ("Play".Equals(objectname)) this.PlayClick();
        else if ("Option".Equals(objectname)) this.OptionClick();
        else if ("credit".Equals(objectname)) this.creditClick();
        else if ("Exit".Equals(objectname)) this.ExitClick();
        else if ("Return".Equals(objectname)) this.ReturnClick();
    }

    void PlayClick()
    {
        //Stage1に遷移
        SceneManager.LoadScene("Stage1");
    }

    void OptionClick()
    {
        //Optionに遷移
        SceneManager.LoadScene("Option");
    }

    void creditClick()
    {
        //Creditに遷移
        SceneManager.LoadScene("credit");
    }

    void ExitClick()
    {
        //ゲームをやめる
        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }

    void ReturnClick()
    {
        //Titleに遷移
        SceneManager.LoadScene("Title");
    }
}
