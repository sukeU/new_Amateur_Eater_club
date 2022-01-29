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
            gameObject.transform.parent = GameObject.Find("Player").gameObject.transform;
            gameObject.transform.position = new Vector3(gameObject.transform.parent.transform.position.x,
            gameObject.transform.parent.transform.position.y,
            gameObject.transform.parent.transform.position.z+1.0f);

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

    public void CallParticle(int num, AteSweets.SpoonFork SF)//eatのスクリプトに色を受け渡す //0黒 1茶 2黄 3赤 4白 5緑
    {
        if (SF == AteSweets.SpoonFork.Spoon)
        {
            switch (num)
            {
                case 2: eat(3, 4); break;
                case 3: eat(4); break;
                case 4: eat(5); break;
                case 5: eat(4); break;
                case 7: eat(2); break;
            }
        }
        else
        {
            switch (num)//eatのスクリプトに色を受け渡す //0黒 1茶 2黄 3赤 4白 5緑
            {
                case 2: eat(3); break;
                case 5: eat(2,3); break;
                case 6: eat(1,2); break;
                case 10: eat(1, 2); break;
            }
        }
    }
    public void eat(int c)//eatのスクリプトに色を受け渡す //0黒 1茶 2黄 3赤 4白 5緑
    {
        particle[0].GetComponent<colorChanger>().ChangeColor(c);
        particle[0].Play();
    }

    public void eat(int c,int c2)//eatのスクリプトに色を受け渡す //0黒 1茶 2黄 3赤 4白 5緑
    {
        particle[0].GetComponent<colorChanger>().ChangeColor(c); particle[0].Play();
        particle[1].GetComponent<colorChanger>().ChangeColor(c2); particle[1].Play();
    }
    public void clearParticle(int t)
    {

    }
}
