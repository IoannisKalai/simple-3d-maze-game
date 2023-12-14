using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 150f;
    public Color objectColor;
    public Vector3 position;
    public GameObject frags;
    public Texture objectTexture;
    public GameObject smallHammerToPickUp;
    int randNum;
    void Start()
    {

        randNum = Random.Range(4, 8);
        position = transform.position;
        objectColor =  this.gameObject.GetComponent<Renderer>().material.color;
        objectTexture = this.gameObject.GetComponent<Renderer>().material.mainTexture;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            int spawnHammer = Random.Range(1, 3);
            Destroy(this.gameObject);
            for (int i = 0; i < randNum; i++)
            {

                var cube = Instantiate(frags, new Vector3(position.x + i * 0.05f, position.y + i * 0.05f, position.z + i * 0.05f), Quaternion.identity);
                cube.GetComponent<Renderer>().material.color = objectColor;
                cube.GetComponent<Renderer>().material.mainTexture = objectTexture;
                Destroy(cube, 3);


            }
            if (spawnHammer == 1)
            {
                SpawnRandomHammer();
            }

        }
    }

    void SpawnRandomHammer()
    {
        Instantiate(smallHammerToPickUp, new Vector3(position.x , position.y , position.z ), Quaternion.identity);
    }
}
