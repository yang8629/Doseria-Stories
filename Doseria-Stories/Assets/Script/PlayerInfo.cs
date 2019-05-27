using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo {

    #region
    [System.Serializable]
    public class HPstaff
    {
        public float Hp;
        public float MaxHp;
        public float PerLVHp;
        public void Set(float i)
        {
            Debug.Log("Set Hp" + i);
            this.Hp = i;
        }
    }
    [System.Serializable]
    public class MPstaff
    {
        public float Mp;
        public float MaxMp;
        public float PerLVMp;
    }
    [System.Serializable]
    public class ATstaff
    {
        public float At;
        public float MaxAt;
        public float PerLVAt;
    }
    [System.Serializable]
    public class Agile
    {
        public float Ag;
    }
    [System.Serializable]
    public class Character
    {
        public string Name;
        public GameObject characterObj;
        public HPstaff HP;
        public MPstaff MP;
        public ATstaff AT;
        public Agile AG;
    }
    #endregion

    public static List<Character> characters =new List<Character>();

    public static void SetCharacter(string name, float hp, float at)
    {
        Character character = new Character();
        character.Name = name;
        character.HP.MaxHp = hp;
        character.HP.Hp = hp;
        //character.MP.MaxMp = mp;
        character.AT.At = at;
        //character.AG.Ag = ag;
        characters.Add(character);
    }

    public static void PrintCharacters()
    {
        int length = characters.Count;
        for (int i = 0; i < length; i++)
        {
            Debug.Log("Name:" + characters[i].Name);
            Debug.Log("Hp:" + characters[i].HP.Hp);
        }
    }
}
