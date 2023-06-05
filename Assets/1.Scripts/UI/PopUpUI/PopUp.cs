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
    protected abstract void Initailize();
    public abstract void SetComment(string comment);
    protected virtual void GetObject()
    {
        Gamemanager.instance.objectPool.GetObjectOfObjectPooling(mypopType);
    }
    protected virtual void ReturnObject()
    {
        Gamemanager.instance.objectPool.ReturnObject(mypopType, this);
    }

}
