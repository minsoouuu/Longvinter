using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroButton : MonoBehaviour
{
    public GameObject SettingPanel;
    
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Setting()
    {
        SettingPanel.SetActive(true);
    }
}
