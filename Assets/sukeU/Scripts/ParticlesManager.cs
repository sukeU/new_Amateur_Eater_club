using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    private ParticleSystem[] particle=new ParticleSystem[5];

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            this.gameObject.transform.parent = GameObject.Find("Player").gameObject.transform;
        }
        catch (System.Exception)
        {

        }

        for (int i = 0; i < gameObject.transform.childCount; i++)//gameObjectの子を取得
        {
            particle[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
            particle[i].Stop();
        }

    }
   

    // Update is called once per frame
    void Update()
    {
    }

    public void CallParticle(int num)
    {
        particle[num].Play();
    }
  

}
