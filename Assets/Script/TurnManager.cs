using Photon.Pun;
using System.IO;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public static TurnManager instance;
    public Player player;
    int myNum;

    public float windPower;
    public float windDirection;

    public TextMeshProUGUI windPowerUI;
    public Image windDirectionUI;

    int curturn = 0;
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
        WindDirectionChange();
        WindPowerChange();

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
        
        players[curturn].ChangeAction();
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
        /*
        Player player = go.GetComponent<Player>();
        player.ChangeIdle();
        players.Add(player);
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
        /*
        players[curturn].ChangeIdle();
        if (curturn + 1 == players.Count)
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
        players[curturn].ChangeAction();
        */

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
        text.text = "���� ��: Player " + curturn;
        Debug.Log("���� ��: " + curturn);
    }
}
