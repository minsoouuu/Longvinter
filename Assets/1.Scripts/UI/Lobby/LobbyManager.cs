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
        connectionInfoText.text = "������ ������ ���� ��...";
    }

    public void SetNickName()
    {

        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "�¶��� : ������ ������ ����";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "�������� : ������ ������ ���� X \n���� ��õ� ��...";
        PhotonNetwork.ConnectUsingSettings();
    }
}
