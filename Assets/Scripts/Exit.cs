using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void OnExit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
