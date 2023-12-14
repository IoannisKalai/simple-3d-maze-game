using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
  
    public float hitDamage;
    public float hitRange;
    public float hammerHealth;
    Renderer[] renderers;
    public int numberOfHammers;

    void Start()
    {
        GameObject StartObject = GameObject.Find("StartGame");
        StartScript cs = StartObject.GetComponent<StartScript>();
        numberOfHammers = cs.K;
       
        renderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.SetColor("_Color", Color.red);
        }
    }

    void Update()
    {
       if(hammerHealth <= 40)
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.SetColor("_Color", Color.black);
            }

        } 
    }

    public void TakeDamage(float amount)
    {
        
        if (hammerHealth == 0)
        {
            if(numberOfHammers > 0)
            {
                numberOfHammers -= 1;
                hammerHealth = 100;
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].material.SetColor("_Color", Color.red);
                }
            }

            
            print("hammer broke");
        }
        hammerHealth -= amount;

    }
}
