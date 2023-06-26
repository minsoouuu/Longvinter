using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    [SerializeField] private Image energy;
    [SerializeField] private User user;

    float energy_fillamount;
    float hp_delaytime;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(user.HP);
        Debug.Log(user.maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        EnergyFill();
        LostHP();
    }

    // energy Image fillamount값 계산
    void EnergyFill()
    {
        energy_fillamount = user.HP / user.maxHp;
        energy.GetComponent<Image>().fillAmount = energy_fillamount;
    }
    
    // 1초마다 hp 1씩 감소
    void LostHP()
    {
        hp_delaytime += Time.deltaTime;
        if(hp_delaytime > 1f)
        {
            if(user.HP > 0)
            {
                user.HP -= 1f;
                hp_delaytime = 0f;
                //Debug.Log(user.HP);
            }
            else
            {

            }
        }
    }
}
