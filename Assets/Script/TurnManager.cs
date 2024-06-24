using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public List<Player> players;

    public float windPower;
    public float windDirection;

    public TextMeshProUGUI windPowerUI;
    public Image windDirectionUI;

    int curturn = 0;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        WindDirectionChange();
        WindPowerChange();

        foreach (Transform child in this.transform)
        {
            Player player = child.GetComponent<Player>();
            player.ChangeIdle();
            players.Add(player);
        }

        players[curturn].ChangeAction();
    }

    public void ChangeTurn()
    {
        Debug.Log("Asd");
        players[curturn].ChangeIdle();
        if (curturn + 1 == players.Count)
        {
            curturn = 0;
        }
        else
        {
            curturn++;
        }
        players[curturn].ChangeAction();

        //갱신 시점? 갱신...이 조금 이상한?
        int rd = Random.Range(0, 2);
        if (rd != 1)
        {
            WindDirectionChange();
            WindPowerChange();
        }
    }

    private void WindPowerChange()
    {
        windPower = Random.Range(0, 4);
        windPowerUI.text = windPower.ToString();
    }

    private void WindDirectionChange()
    {
        windDirection = Random.Range(-20, 201);
        windDirectionUI.transform.rotation = Quaternion.Euler(0, 0, windDirection);
    }
}
