using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    

   
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == ("Ground") && gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().playerOnGround == false)
        {
            Debug.Log("+++++++++++++++" + gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().playerOnGround);
            gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().playerOnGround = true;
        }

    }
}
