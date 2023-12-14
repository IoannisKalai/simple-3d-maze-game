using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHam : MonoBehaviour
{
    
    public int hammerTemp;

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
           

            hammerTemp = GameObject.Find("GameLoop").GetComponent<GameLoop>().currentHammers ;
            hammerTemp++;

            GameObject.Find("GameLoop").GetComponent<GameLoop>().currentHammers = hammerTemp;
            
            Destroy(this.gameObject);


        }
    }

   
}
