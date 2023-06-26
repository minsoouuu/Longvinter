using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject quitPopup;
    public GameObject settingUI;
    public GameObject guideUI;
    public AudioSource closeSound;

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
        Debug.Log("게임 종료");
        Application.Quit();
    }

    public void NoQuit()
    {
        closeSound.Play();
        quitPopup.SetActive(false);
    }
}
