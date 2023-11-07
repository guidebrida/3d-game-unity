using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : ScriptableObject
{

    public float _score;
    public float _lifecounter;

    public float Value
    {
        get
        {
            return _score; }
        set { _score = value;
        }
    }

    public float Lifecounter {
        get { 
        return _lifecounter;}
        set { _lifecounter = value; }
    }
        
}
