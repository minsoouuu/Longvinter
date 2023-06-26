using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
{
    [SerializeField] private GameObject house_UI;
    [SerializeField] private 
    float dis;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(this.transform.position, Gamemanager.instance.player.transform.position);
        Debug.Log(dis);
        if(dis < 2f)
        {
            house_UI.SetActive(true);
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("House");
            }
        }
    }
}
