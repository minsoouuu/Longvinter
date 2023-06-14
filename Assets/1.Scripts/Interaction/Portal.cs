using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject intertaction_img;
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<User>())
        {
            intertaction_img.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<User>())
        {
            intertaction_img.SetActive(false);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<User>())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
