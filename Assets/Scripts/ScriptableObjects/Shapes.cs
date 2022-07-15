using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shapes : ScriptableObject
{
    [SerializeField] protected int _countLives;
    [SerializeField] protected string _type;

    public int CountLives => _countLives;    
    public string Type => _type;    
}
 