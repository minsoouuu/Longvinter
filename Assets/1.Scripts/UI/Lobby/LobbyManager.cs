using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";
    public Text connectionInfoText;
    public Text playerList;
    public Button joinButton;
    public GameObject setNick;
    public InputField nameField;
    

    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
    }

    public void GameStart()
    {
        setNick.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
        joinButton.interactable = false;
        connectionInfoText.text = "마스터 서버에 접속 중...";
    }

    public void SetNickName()
    {
        PhotonNetwork.LocalPlayer.NickName = nameField.text;
        connectionInfoText.text = nameField.text + " 입장합니다.";
        UpdatePlayer();
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "온라인 : 마스터 서버와 연결";
        UpdatePlayer();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "오프라인 : 마스터 서버와 연결 X \n접속 재시도 중...";
        PhotonNetwork.ConnectUsingSettings();
    }

    void UpdatePlayer()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            playerList.text = "\n" + PhotonNetwork.PlayerList[i].NickName;
        }
    }
}
