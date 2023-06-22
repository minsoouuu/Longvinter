using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class GameGuide_UI : MonoBehaviour
{
    [SerializeField] private HorizontalScrollSnap hs;
    [SerializeField] private Toggle[] toggles;
    Toggle curToggle;
    int curPageNum;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeToggle(0);
    }

    // Update is called once per frame
    void Update()
    {
        curPageNum = hs._currentPage;
        ChangeToggle(curPageNum);
    }

    void ChangeToggle(int a)
    {
        curToggle = toggles[a];
        curToggle.isOn = true;  
        curToggle.Select();
    }
}
