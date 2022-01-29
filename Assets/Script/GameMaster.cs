using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public bool gameFinish = false;

    void NonSatietyGameOver()
    {
        gameFinish = true;
    }
}
