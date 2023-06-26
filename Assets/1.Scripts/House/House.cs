using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
{
    //private SceneChangeController sc;
    float dis;
    bool ison;
    private void Start()
    {
        //sc = FindObjectOfType<SceneChangeController>();
        ison = false;
    }
    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(this.transform.position, Gamemanager.instance.player.transform.position);
        if(BuildingSystem.b_instance.selectedObject.Placed == true)
        {
            if (dis < 4f)
            {
                if (ison == false)
                {
                    ison = true;
                    Gamemanager.instance.interUI.IsOn = true;
                    Gamemanager.instance.interUI.SetUi("P", "들어가기");
                }
                if (Input.GetKey(KeyCode.P))
                {
                    SceneManager.LoadScene("House");
                }
            }
            else
            {
                if (ison == true)
                {
                    ison = false;
                    Gamemanager.instance.interUI.DeleteUI();
                    Gamemanager.instance.interUI.IsOn = false;
                }
            }
        }
        
    }
}
