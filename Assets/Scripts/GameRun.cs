using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRun : MonoBehaviour
{
    private int checkpointNumber = 1;
    public Canvas menuCan;
    private bool esc = true;
    private bool setScoreOne;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("TextTime").GetComponent<ControlTime>().TimeStart();
        menuCan.enabled = false;
        setScoreOne = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointNumber > 8)
        {
            if (setScoreOne)
            {
                GameObject.Find("TextTime").GetComponent<ControlTime>().setScore();
                setScoreOne = false;
            }
            GameObject.Find("TextTime").GetComponent<ControlTime>().TimeStop();
            GameObject.Find("Car").GetComponent<CarControllerFree>().Stopped(GameObject.Find("Car").transform.position);
            menuCan.enabled = true;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (esc)
            {
                menuCan.enabled = true;
                esc = false;
                GameObject.Find("TextTime").GetComponent<ControlTime>().TimePause(false);
                GameObject.Find("Car").GetComponent<CarControllerFree>().Stopped(GameObject.Find("Car").transform.position);
            } else
            {
                menuCan.enabled = false;
                esc = true;
                GameObject.Find("TextTime").GetComponent<ControlTime>().TimePause(true);
                if (GameObject.Find("TextTime").GetComponent<ControlTime>().timer < 0)
                {
                    GameObject.Find("Car").GetComponent<CarControllerFree>().Started();
                }
                
            }
        }
    }

    public int getCheckPoint()
    {
        return this.checkpointNumber;
    }

    public void nextCheckpoint()
    {
        this.checkpointNumber++;
    }
}
