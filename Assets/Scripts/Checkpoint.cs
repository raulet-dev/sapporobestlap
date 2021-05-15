using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Material Green;
    public Material Red;
    public Material Yellow;
    public int checkpointNumber = 0;
    private Component[] checkMats;
    GameObject checks;
    private bool notTriggered = true;
    private Transform next;


    // Start is called before the first frame update
    void Start()
    {
        checkMats = this.gameObject.GetComponentsInChildren<Renderer>();
        ChangeColor(0);
        checks = GameObject.Find("GameControl");
        next = transform.GetChild(3);

    }

    // Update is called once per frame
    void Update()
    {

        if (checks.GetComponent<GameRun>().getCheckPoint() == this.checkpointNumber)
        {
            ChangeColor(1);
            next.gameObject.SetActive(true);
            
        } else if (checks.GetComponent<GameRun>().getCheckPoint() < this.checkpointNumber)
        {
            ChangeColor(0);
            next.gameObject.SetActive(false);
        } else
        {
            ChangeColor(2);
            next.gameObject.SetActive(false);
        }



    }

    void ChangeColor(int a)
    {
        switch (a)
        {
            case 1:
                foreach (Renderer mats in checkMats)
                {
                    mats.material = Yellow;
                }
                break;
            case 2:
                foreach (Renderer mats in checkMats)
                {
                    mats.material = Green;
                }
                break;
            default:
                foreach (Renderer mats in checkMats)
                {
                    mats.material = Red;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (notTriggered)
        {
            checks.GetComponent<GameRun>().nextCheckpoint();
            this.notTriggered = false;
        }
        
    }

}
