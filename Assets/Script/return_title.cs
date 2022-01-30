using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//シーンをロードする場合に必要

public class return_title : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnRetry()
    {
        SceneManager.LoadScene("title");
    }
}
