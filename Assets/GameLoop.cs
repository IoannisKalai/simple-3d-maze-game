using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public int score;
    public int Nnew;
    public int startNumberofHammers;
    public int numberOfHammersleft;
    public int currentHammers;
    private float currentTimer;
    public Text scoreText;
    public Text FinalScore;
    public GameObject StartGame;
    private StartScript s;
    public GameObject HammerObject;
    private Hammer ham;
    public int Lnew;
 
    // Start is called before the first frame update
    void Start()
    {
        //TO find N



        s = StartGame.GetComponent<StartScript>();
        Nnew = s.N;
        Lnew = s.L;
        print(" TO N EINAI " + Nnew);
        //timer
        currentTimer = s.timer;

        // To find number of hammers used;
        startNumberofHammers = s.K;

        ham = HammerObject.GetComponent<Hammer>();

        FinalScore.enabled = false;
        scoreText.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //SCORE DISPLAY
        currentTimer += Time.deltaTime;
        int seconds = Convert.ToInt32(currentTimer % 60);
        currentHammers = ham.numberOfHammers;
        int hammersUsed = startNumberofHammers - currentHammers;

        score = (Nnew * Nnew) - seconds - hammersUsed * 50;
        if(score <= 0)
        {
            score = 0;
        }
        scoreText.text ="Score: " + score.ToString();


        //Exit Game 
        exitGame();

          
        
    }
    void exitGame()
    {
        // QUIT GAME WITH X
        if (Input.GetKeyDown(KeyCode.X))
        {
           
            scoreText.enabled = false;
            
            if (Lnew == 1)
            {
                
                score = 0;
                FinalScore.text = "Final Score: " + score.ToString() ;
            }
            else
            {
                FinalScore.text = " Final Score: " + score.ToString();
            }
            
            
            FinalScore.enabled = true;
            StartCoroutine("Quit");          

        }
       
    }
    IEnumerator Quit()
    {
        yield return new WaitForSeconds(7);
        print("Exit game");
        ///if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;
        //#else
        Application.Quit();
        // #endif
    }
}
