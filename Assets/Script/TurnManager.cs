using Photon.Pun;
using System.IO;
using TMPro;
using UnityEditor.Tilemaps;
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
    public TextMeshProUGUI turnText;
    public Image windDirectionUI;


    int curturn = 1;

    public Hashtable initialDie = new Hashtable() { { "isDie", true } };

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
        PhotonNetwork.LocalPlayer.SetCustomProperties(initialDie);
        Photon.Realtime.Player[] playerList = PhotonNetwork.PlayerList;
        player = go.GetComponent<Player>();
        go.GetComponent<Fuel>().slider = (Managers.UI.SceneUI as UI_GameScene).fuel.GetComponent<Slider>();
        go.GetComponent<PlayerAttack>().forceUI = (Managers.UI.SceneUI as UI_GameScene).gazer.GetComponent<Slider>();

        player.ChangeIdle();
    }

    public void ChangeTurn()
    {
        photonView.RPC("RPC_ChangeTurn", RpcTarget.All);
    }

    [PunRPC]
    public void RPC_ChangeTurn()
    {
        
        //�̹� ��������̸� �ѹ� �� ����
        if (curturn == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            player.ChangeIdle();
        }
        curturn = (curturn % PhotonNetwork.CurrentRoom.PlayerCount) + 1;
        if (curturn == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            player.ChangeAction();
        }

        //����
        turnText.text = "�̹����� : Player " + curturn;
        int rd = Random.Range(0, 2);
        if (rd != 1)
        {
            WindDirectionChange();
            WindPowerChange();
        }

        //������
        LoadPrefab();
    }

    public void GameOver()
    {
        initialDie["isDie"] = false;
        photonView.RPC("RPC_GameOver", RpcTarget.All);
    }

    [PunRPC]
    private void RPC_GameOver()
    {
        //���� �ѱ������ �÷��̾ �Ѹ� ���Ҵ��� üũ
        int aliveCount = 0;
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            Debug.Log(player.CustomProperties["isDie"]);
            if (player.CustomProperties.ContainsKey("isDie") && !(bool)player.CustomProperties["isDie"])
            {
                aliveCount++;
            }
        }
        Debug.Log(aliveCount);
        // ������ �÷��̾ �� ������ üũ
        if (aliveCount == 0)
        {
            Debug.Log("�� ���� �÷��̾ �����߽��ϴ�.");
            PhotonNetwork.LeaveRoom();
            OnLeftRoom();
        }

    }

    public override void OnLeftRoom()
    {
        Managers.Scene.LoadScene(Define.SceneType.LobbyScene);
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

    private void LoadPrefab()
    {
        float spawnXPos = Random.Range(-8f, 8f);

        int itemIdx = Random.Range(0, 4);

        Vector2 spawnPosition = new Vector2(spawnXPos, 5);


        PhotonNetwork.Instantiate(Path.Combine(Managers.Data.items[itemIdx].prefabPath), new Vector3(spawnXPos, 6, 0), Quaternion.identity);
    }

}
