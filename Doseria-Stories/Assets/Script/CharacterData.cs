using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character",menuName = "Characters/Character")]
public class CharacterData : ScriptableObject
{
    public new string name;
    public GameObject characterObj;
    public float Hp;
    public float Def;
    public float Ag;
    public float At;
}
