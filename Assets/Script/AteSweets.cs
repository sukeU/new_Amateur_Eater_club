using System.Collections;
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
            other.gameObject.transform.Find("ParticlesMaster").GetComponent<ParticlesManager>().CallParticle(addValue, spoonOrFork);//パーティクル用の受け渡し
            other.SendMessage("EatRightSweet", addValue);
            Destroy(this.gameObject);
        }
        //間違ってたら
        else
        {
            if("Fork" == spoonOrFork.ToString())
            {
                other.SendMessage("EatWrongSweetFork", addValue);
            }
            else
            {
                other.SendMessage("EatWrongSweetSpoon", addValue);
            }
            
        }
    }
}
