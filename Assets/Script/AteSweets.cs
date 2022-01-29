﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AteSweets : MonoBehaviour
{
    public enum SpoonFork
    {
        Spoon, Fork
    }
    [SerializeField] SpoonFork spoonOrFork;

    public int addValue;

    private void OnTriggerEnter(Collider other)
    {
        //合ってたら
        if(other.gameObject.tag == spoonOrFork.ToString())
        {
            other.SendMessage("EatRightSweet", addValue);
            Destroy(this.gameObject);
        }
        //間違ってたら
        else
        {
            other.SendMessage("EatWrongSweet", addValue);
        }
    }
}
