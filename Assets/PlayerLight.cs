using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        this.gameObject.transform.position = new Vector3(playerInfo.x, playerInfo.y +1, playerInfo.z);
    }
}
