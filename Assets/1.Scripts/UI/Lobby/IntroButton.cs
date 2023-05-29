using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroButton : MonoBehaviour
{
    public GameObject escPanel;
    

    public void Setting()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escPanel.SetActive(true);
        }
    }
}
