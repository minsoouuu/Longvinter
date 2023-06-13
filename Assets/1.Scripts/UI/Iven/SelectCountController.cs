using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectCountController : MonoBehaviour
{
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private Button okButton;
    [SerializeField] private TMP_Text countText;


    private int count = 0;
    public int Count
    {
        get { return count; }
        set 
        {
            count = value;
            countText.text = Count.ToString();
        }
    }
    private void Awake()
    {
        upButton.onClick.AddListener(() => OnButtonCountUp());
        downButton.onClick.AddListener(() => OnButtonCountDown());
        okButton.onClick.AddListener(() => OnButtonOK());
    }
    private void OnEnable()
    {
        Count = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
    void OnButtonCountUp()
    {
        if (Gamemanager.instance.player.im.Money <= Count)
            return;

        Count++;
    }
    void OnButtonCountDown()
    {
        if (Count <= 0)
            return;

        Count--;
    }
    void OnButtonOK()
    {
        Gamemanager.instance.player.im.Money -= Count;
        gameObject.SetActive(false);
    }
}
