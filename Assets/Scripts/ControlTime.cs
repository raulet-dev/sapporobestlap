using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ControlTime : MonoBehaviour
{
    private bool start = false;
    private Text chrono;
    public int timer = 100;
    private float timing = 0f;
    private float timeScore = 0f;
    private bool firstTime = true;
    private int maxTimer = 5;
    private bool pause = false;
    private string[] scoresRead;
    private float[] scores = new float[5];

    // Start is called before the first frame update
    void Start()
    {
        chrono = GetComponent<Text>();
        if (File.Exists("scores.sc")){

        } else
        {
            ResetScore();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (timer > 0)
            {
                timing += 1 * Time.deltaTime;
                timer = maxTimer - (int)timing;
                chrono.alignment = TextAnchor.LowerRight;
                chrono.text = timer.ToString();
            } else
            {
                timeScore += 1 * Time.deltaTime;
                chrono.text = "Time:\n" + timeScore.ToString();
                chrono.alignment = TextAnchor.UpperLeft;
                if (firstTime)
                {
                    GameObject.Find("Car").GetComponent<CarControllerFree>().Started();
                }
            }
        } else
        {
            if (timer > 0)
            {
                chrono.alignment = TextAnchor.LowerRight;
            } else
            {
                chrono.alignment = TextAnchor.MiddleCenter;
            }
        }
    }

    public void TimeStart()
    {
        this.start = true;
        this.timing = 0f;
        this.firstTime = true;
        this.timeScore = 0f;
        this.timer = 100;
        this.pause = false;

    }

    public void TimeStop()
    {
        this.start = false;
    }

    public void TimePause(bool a)
    {
        this.start = a;
    }

    public void setScore()
    {
        int tmp = -1;
        scoresRead = File.ReadAllLines("scores.sc");
        for (int a = 0; a < 5; a++)
        {
            scores[a] = float.Parse(scoresRead[a]);
        }

        for (int a = 0; a < 5; a++)
        {
            if(timeScore < scores[a])
            {
                tmp = a;
                break;
            }
        }
        if (tmp != -1)
        {
           
            if(tmp < 4)
            {
                for(int a = 3; a >= tmp; a--)
                {
                    scores[a+1] = scores[a];
                }
            }
            scores[tmp] = timeScore;
            for (int a = 0; a < 5; a++)
            {
                scoresRead[a] = scores[a].ToString();
            }
            File.WriteAllLines("scores.sc", scoresRead);
            GameObject.Find("ScoresText").GetComponent<ScoreBoard>().ScoreUpdate();
        }



    }

    public void ResetScore()
    {
        string[] newFile = new string[5];
        for (int a = 0; a < 5; a++)
        {
            newFile[a] = "999999";
        }
        File.WriteAllLines("scores.sc", newFile);
    }

}
