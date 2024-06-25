using Photon.Pun;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
        Photon.Realtime.Player[] playerList = PhotonNetwork.PlayerList;
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
        if (curturn == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            player.ChangeIdle();
        }
        curturn = (curturn % PhotonNetwork.CurrentRoom.PlayerCount) + 1;
        if (curturn == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            player.ChangeAction();
        }


        text.text = "이번턴은 : Player " + curturn;
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
