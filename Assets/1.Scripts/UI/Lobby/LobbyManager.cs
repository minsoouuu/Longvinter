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
        connectionInfoText.text = "������ ������ ���� ��...";
    }

    public void SetNickName()
    {
        PhotonNetwork.LocalPlayer.NickName = nameField.text;
        connectionInfoText.text = nameField.text + " �����մϴ�.";
        UpdatePlayer();
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "�¶��� : ������ ������ ����";
        UpdatePlayer();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "�������� : ������ ������ ���� X \n���� ��õ� ��...";
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
