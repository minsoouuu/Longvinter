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
    public GameObject quitPopup;
    public GameObject settingUI;
    public GameObject guideUI;
    public InputField nameField;
    public AudioSource closeSound;

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
        closeSound.Play();
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

    public void OnClickSettingUI()
    {
        settingUI.SetActive(true);
    }

    public void OnClickBackToLobby()
    {
        closeSound.Play();
        settingUI.SetActive(false);
    }

    public void OnClickGuideUI()
    {
        guideUI.SetActive(true);
    }

    public void OnClickBackToSetting()
    {
        closeSound.Play();
        guideUI.SetActive(false);
    }
    
    public void OnClickQuit()
    {
        quitPopup.SetActive(true);
    }

    public void YesQuit()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }

    public void NoQuit()
    {
        closeSound.Play();
        quitPopup.SetActive(false);
    }


}
