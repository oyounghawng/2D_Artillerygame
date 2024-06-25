using Photon.Pun;
using System.IO;
using TMPro;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public static TurnManager instance;
    public Player player;
    int myNum;
    int curturn = 1;

    Hashtable initialPorpsTurn = new Hashtable() { { "isMyTurn", false } };

    public TextMeshProUGUI text;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SpawnPlayer();

        if (curturn == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            player.ChangeAction();
        }

        /*
        foreach (Transform child in this.transform)
        {
            Player player = child.GetComponent<Player>();
            player.ChangeIdle();
            players.Add(player);
        }
        */
    }

    private void SpawnPlayer()
    {
        int idx = PhotonNetwork.LocalPlayer.ActorNumber;
        GameObject go;
        if (idx == 1)
        {
            go = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"), new Vector3(-3, 2, 0), Quaternion.identity);
        }
        else
        {
            go = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"), new Vector3(3, 2, 0), Quaternion.identity);
        }
        PhotonNetwork.LocalPlayer.SetCustomProperties(initialPorpsTurn);
        /*
        if (PhotonNetwork.PlayerList[idx] == PhotonNetwork.LocalPlayer)
        {
            myNum = idx;
        }
        */
        // PhotonNetwork.PlayerList�� ����Ͽ� ��� �÷��̾��� ������ �����ɴϴ�.
        Photon.Realtime.Player[] playerList = PhotonNetwork.PlayerList;

        Debug.Log("Current Players in Room:");
        foreach (Photon.Realtime.Player player in playerList)
        {
            Debug.Log("Player ID: " + player.ActorNumber + ", Player Name: " + player.NickName);
        }
        player = go.GetComponent<Player>();
        player.ChangeIdle();
    }

    public void ChangeTurn()
    {
        photonView.RPC("RPC_ChangeTurn", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_ChangeTurn()
    {
        Debug.Log("���� �ٲ�����ϴ�.");

        if (curturn == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            player.ChangeIdle();
        }
        // ���� ���� �÷��̾� ActorNumber ���� �� ��ȯ
        curturn = (curturn % PhotonNetwork.CurrentRoom.PlayerCount) + 1;
        // ����� ���� ��� Action ���·� ����
        if (curturn == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            player.ChangeAction();
        }
        text.text = "���� ��: Player " + curturn;
        Debug.Log("���� ��: " + curturn);
    }
}
