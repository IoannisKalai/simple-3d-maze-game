using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHit : MonoBehaviour
{

    public Camera cam;
    public GameObject hand;
    public Hammer myHammer;
    private bool hammerInUse = false;
    // Start is called before the first frame update
    void Start()
    {

        myHammer = hand.GetComponentInChildren<Hammer>();
        hand.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.H))
            {
           
                if(hammerInUse  == false){
                hand.SetActive(true);
                hammerInUse = true;
                }
                else
                {
                    
                    Hit();
                }                

            }
        
    }

    void Hit()
    {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, myHammer.hitRange))
            {
                if(hit.collider.tag == "Ground")
                {
                Health health = hit.collider.GetComponent<Health>();
                health.TakeDamage(myHammer.hitDamage);
                if (myHammer.hammerHealth == 0)
                {
                    print("MLALALALAMLMALA0");
                    hand.SetActive(false);
                    hammerInUse = false;
                }
                myHammer.TakeDamage(10);
                print(myHammer.hammerHealth);
                    
                }
            }

            
    }

   
}

