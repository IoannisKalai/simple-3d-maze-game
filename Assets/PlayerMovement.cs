using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float walk;
    public bool playerOnGround;

    Rigidbody rb;
    Vector3 moveDirection;

    public GameObject GameLoop;
    private GameLoop gl;

    public Text FinalScore;
    public Text scoreText;
    public int score;
    public int N;
    public int L;
    public Text WinText;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        gl = GameLoop.GetComponent<GameLoop>();
        FinalScore = gl.FinalScore;
        scoreText = gl.scoreText;
        score = gl.score;
        N = gl.Nnew;
        L = gl.Lnew;

        FinalScore.enabled = false;
        WinText.enabled = false;
        scoreText.enabled = true;


    }

    void Update()
    {
        gl = GameLoop.GetComponent<GameLoop>();
        FinalScore = gl.FinalScore;
        scoreText = gl.scoreText;
        score = gl.score;
        N = gl.Nnew;
        L = gl.Lnew;
        //For non physics steps
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        
        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && playerOnGround)
        {

            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            playerOnGround = false;
        }

        if(Input.GetKeyDown(KeyCode.E)&& playerOnGround && transform.position.y > L - 0.7)
        {
            print("NIKI");
            
            // QUIT GAME WITH X
            if (Input.GetKeyDown(KeyCode.E))
            {

                scoreText.enabled = false;

                if (L == 1)
                {

                    score = 0;
                    FinalScore.text = "Final Score: " + score.ToString();
                }
                else
                {
                    FinalScore.text = " Final Score: " + score.ToString();
                }
                WinText.text = "Congratulations. You Won";

                WinText.enabled = true;
                FinalScore.enabled = true;
                StartCoroutine("Quit");

            }

           
            
        }


    }
    IEnumerator Quit()
    {
        yield return new WaitForSeconds(7);
        print("Exit game");
        ///if UNITY_EDITOR
       // UnityEditor.EditorApplication.isPlaying = false;
        //#else
        Application.Quit();
        // #endif
    }



    void FixedUpdate()
    {
        //Physics related stuff
        Move();
        
    }

   void Move()
    {
        Vector3 fixyVel = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = moveDirection * walk * Time.deltaTime;
        rb.velocity += fixyVel;
    }

}
