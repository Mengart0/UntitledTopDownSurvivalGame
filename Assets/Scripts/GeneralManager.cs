using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneralManager : MonoBehaviour
{
    private bool debugginToolState = false;
    public GameObject debuggingScreen;
    public int killCount = 0;

    public TMP_Text KillCountText;

    public void IncKillCount()
    {
        killCount++;
    }

    void Update()
    {
        KillCountText.text = "Fallen Enemies - " + killCount.ToString();

        debuggingScreen.gameObject.SetActive(debugginToolState);

        if (Input.GetKeyDown(KeyCode.P))
        {
            //activating Debugging Tool
            if (!debugginToolState) { debugginToolState = true; }
            else if (debugginToolState) { debugginToolState=false; }
            Debug.Log("Debugging Activated");
        }
    }
}
