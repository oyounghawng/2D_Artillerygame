using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public List<Player> players;

    int curturn = 0;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
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
    }
}
