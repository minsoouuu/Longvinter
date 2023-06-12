using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public abstract class PopUp : MonoBehaviour
{
    public PopType mypopType = new PopType();
    private string comment;

    public string Comment
    {
        get { return comment; }
        set
        {
            comment = value;
        }
    }
    private void Awake()
    {
        Initailize();
    }
    protected abstract void Initailize();
    public abstract void SetComment(string comment);
    public virtual void ReturnObject()
    {
        Gamemanager.instance.objectPool.ReturnObject(mypopType, this);
    }
}
