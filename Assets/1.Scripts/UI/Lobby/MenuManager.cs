using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject quitPopup;
    public GameObject settingUI;
    public GameObject guideUI;
    
    public void OnClickSettingUI()
    {
        settingUI.SetActive(true);
    }

    public void OnClickBackToLobby()
    {
        settingUI.SetActive(false);
    }

    public void OnClickGuideUI()
    {
        guideUI.SetActive(true);
    }

    public void OnClickBackToSetting()
    {
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
        quitPopup.SetActive(false);
    }
}
