using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";
    public Text connectionInfoText;
    public Button joinButton;
    public GameObject setNick;

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

        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "온라인 : 마스터 서버와 연결";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "오프라인 : 마스터 서버와 연결 X \n접속 재시도 중...";
        PhotonNetwork.ConnectUsingSettings();
    }
}
