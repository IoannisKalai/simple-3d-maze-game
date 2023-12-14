using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;

public class StartScript : MonoBehaviour {

    public GameObject obj;
    public int N, L, K;
    public Texture T1, T2, T3;
    public GameObject player;
    public List<Vector3> emptypositions = new List<Vector3>();
    int emptypositionsCounter = 0;
    public GameObject invisibleObj;
    public float timer;

    void ReadFromFile()
    {
        //int N = 0, L = 0, K = 0;
        int currentLevel = 0;

        using (StreamReader file = File.OpenText("file.maz"))
        {
            string line = "";
            char[] delimiterChars = { '=', ' ', '\t' };
            string[] words =null;
            int currentline = 0;


            while ((line = file.ReadLine()) != null)
            {
                line = Regex.Replace(line, " {2,}", " ");
                words = line.Split(delimiterChars);
                
            
                if (words[0].Equals("L"))
                {
                    L = Convert.ToInt32(words[1]);

                }
                else if (words[0].Equals("N"))
                {
                    N = Convert.ToInt32(words[1]);

                }
                else if (words[0].Equals("K"))
                {
                    K = Convert.ToInt32(words[1]);

                }
                else if (String.Equals(words[0], "LEVEL"))
                {
                    // ? ignore ? 
              
                    currentLevel = Convert.ToInt32(words[1]);
                    currentline = 0;

                }
                else if (String.Equals(words[0], "END"))
                {
                   
                }
                else
                {
                    
                    
                    for (int i = 0; i < N; i++)
                    {

                        //System.Console.WriteLine($"<{word}>");
                        if (words[i].Equals("E"))
                        {    
                            if(currentLevel == 1)
                            {
                                emptypositions.Add(new Vector3(i, 0,currentline));
                               
                            }
                            

                            emptypositionsCounter++;

                            
                        }
                        else
                        {
                            var cube = Instantiate(obj, new Vector3(i, currentLevel - 1, currentline), Quaternion.identity);
                            
                            if (words[i].Equals("R"))
                            {      // Red
                                cube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);

                            }
                            else if (words[i].Equals("G"))
                            {      // Green 
                                cube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);

                            }
                            else if (words[i].Equals("B"))
                            {      // Blue
                                cube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);

                            }
                            else if (words[i].Equals("T1"))
                            {     // Texture 1
                                cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", T1);
                            }
                            else if (words[i].Equals("T2"))
                            {     // Texture 2
                                cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", T2);

                            }
                            else if (words[i].Equals("T3"))
                            {     // Texture 3 */
                                cube.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", T3);

                            }
                        }
                        InvisibleWallsGenerate(currentline, currentLevel, i);
                    }

                    currentline++;
                 
                    
                }
               
            }
            file.Close();
        }
    }
    void InvisibleWallsGenerate(int currentline, int currentLevel, int i)
    {
        if (i == 0)
        {
            var cube1 = Instantiate(invisibleObj, new Vector3(i - 1, currentLevel - 1, currentline), Quaternion.identity);
           
        }
        else if (i == N - 1)
        {
            var cube1 = Instantiate(invisibleObj, new Vector3(i + 1, currentLevel - 1, currentline), Quaternion.identity);
        }
        if (currentline == 0)
        {
            var cube1 = Instantiate(invisibleObj, new Vector3(i, currentLevel - 1, currentline - 1), Quaternion.identity);
        }
        else if (currentline == N - 1)
        {
            var cube1 = Instantiate(invisibleObj, new Vector3(i, currentLevel - 1, currentline + 1), Quaternion.identity);
        }
        if (currentLevel == L)
        {
            if (i == 0)
            {
                var cube1 = Instantiate(invisibleObj, new Vector3(i - 1, currentLevel, currentline), Quaternion.identity);
            }
            else if (i == N - 1)
            {
                var cube1 = Instantiate(invisibleObj, new Vector3(i + 1, currentLevel, currentline), Quaternion.identity);
                
            }
            if (currentline == 0)
            {
                var cube1 = Instantiate(invisibleObj, new Vector3(i, currentLevel, currentline - 1), Quaternion.identity);
            }
            else if (currentline == N - 1)
            {
                var cube1 = Instantiate(invisibleObj, new Vector3(i, currentLevel, currentline + 1), Quaternion.identity);
            }
        }
    }

    void GridGenerate() {
        for (int i = 0; i < N ; i ++) {
            for (int j = 0; j < N ; j++)
            {
                
                Instantiate(obj, new Vector3(i, -1, j), Quaternion.identity);
               
            }
        }
    }

    void SpawnPlayer()
    {
        var random = new System.Random();
        int index = random.Next(emptypositions.Count);
        player.transform.position = emptypositions[index];
    }
    void TimerStart()
    {
        timer =0.0f;
    }
    // Start is called before the first frame update
    void Start(){
        ReadFromFile();
        GridGenerate();
        SpawnPlayer();
        TimerStart();
    }

    
}
