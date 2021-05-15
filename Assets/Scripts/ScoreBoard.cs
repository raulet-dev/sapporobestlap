using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreBoard : MonoBehaviour
{
    private string[] scoresRead;
    private Text scoreText;
    private string scores="";
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUpdate(); 
    }

    public void ScoreUpdate()
    {
        scoresRead = File.ReadAllLines("scores.sc");
        for (int a = 0; a < 5; a++)
        {
            scores += scoresRead[a] + "\n";
        }
        scoreText.text = scores; 
    }
}
