using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RsetButton : MonoBehaviour
{
    // Start is called before the first frame update
public void ResetScore()
    {
        GameObject.Find("TextTime").GetComponent<ControlTime>().ResetScore();
    }
}
