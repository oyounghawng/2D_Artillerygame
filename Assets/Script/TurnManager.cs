using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public static TurnManager instance;
    public List<Player> players;
    int myNum;
    int curturn = 0;
    private void Awake()
    {
        instance = this;


    }
    private void Start()
    {
        SpawnPlayer();

        /*
        foreach (Transform child in this.transform)
        {
            Player player = child.GetComponent<Player>();
            player.ChangeIdle();
            players.Add(player);
        }
        */
        players[curturn].ChangeAction();
    }

    private void SpawnPlayer()
    {
        int idx = PhotonNetwork.LocalPlayer.ActorNumber;
        GameObject prefab = Managers.Resource.Load<GameObject>("Prefabs/Player");
        GameObject go;
        if (idx == 1)
        {
            go = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"), new Vector3(-3, 2, 0), Quaternion.identity);
        }
        else
        {
            go = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"), new Vector3(3, 2, 0), Quaternion.identity);
        }

        if (PhotonNetwork.PlayerList[idx] == PhotonNetwork.LocalPlayer)
        {
            myNum = idx;
        }

        /*
        Player player = go.GetComponent<Player>();
        player.ChangeIdle();
        players.Add(player);
        */
    }

    public void ChangeTurn()
    {
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
