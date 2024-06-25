using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerStatsUI : MonoBehaviour
{
    public TMP_Text playerTransStatsTxt;
    public GameObject playerTransStats;


    public void PrintTransStats(string transStats)
    {
        playerTransStatsTxt.text = transStats;
        playerTransStats.SetActive(true);
        Invoke("ExitTransStats", 1f);
    }
    public void ExitTransStats()
    {
        string nullTxt = " ";
        playerTransStatsTxt.text = nullTxt;
        playerTransStats.SetActive(false);
    }
}
