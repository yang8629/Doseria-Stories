using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//紀錄戰鬥畫面中的資訊
//紀錄血量
public class BattleInfo {
    public static bool inbattle = true;
    public static List<EnemyInbattle> enemyInbattle = new List<EnemyInbattle>();//敵人資料
    public static List<CharacterInbattle> characterInbattle = new List<CharacterInbattle>();//角色資料

    public static CharacterInbattle now_action_character=new CharacterInbattle();

    public class CharacterInbattle
    {
        string name;
        GameObject characterPrefab;
        GameObject characterObj;
        float timer;
        float hp;
        float ag;
        float at;
        bool moving;
        bool dead;
        public void Set(string Name, GameObject characterPrefab, float Hp, float Ag, float At)
        {
            this.name = Name;
            this.characterPrefab = characterPrefab;
            this.TimerReset();
            this.Hp = Hp;
            this.ag = Ag;
            this.At = At;
            this.moving = false;
            this.dead = false;
        }
        public string Name
        {
            get { return name; }
        }
        public void SetCharacterObj(GameObject characterObj)
        {
            this.characterObj = characterObj;
            Debug.Log(this.CharacterObj);
        }
        public GameObject CharacterPrefab
        {
            get { return characterPrefab; }
        }
        public GameObject CharacterObj
        {
            get { return characterObj; }
        }
        public float Timer
        {
            set { timer = value; }
            get { return timer; }
        }
        public void TimerReset()
        {
            timer = 0;
        }
        public float Hp
        {
            set { hp = value; }
            get { return hp; }
        }
        public float Ag
        {
            get { return ag; }
        }
        public float At
        {
            set { at = value; }
            get { return at; }
        }
        public bool Moving
        {
            get { return moving; }
        }
        public bool Dead
        {
            get { return dead; }
        }
        public void NowAction(CharacterInbattle buffer)
        {
            this.name = buffer.Name;
            this.characterObj = buffer.CharacterObj;
        }
    }

    public static void SetCharacterInbattle(string Name, GameObject characterPrefab, float Hp, float Ag, float At)
    {
        CharacterInbattle buffer = new CharacterInbattle();
        buffer.Set(Name, characterPrefab, Hp, Ag, At);
        characterInbattle.Add(buffer);
    }

    public class EnemyInbattle
    {
        public GameObject enemyObj;
        public float Timer = 0;
        public float Hp;
        public float Ag;
        public float At;
        public bool Dead = false;
    }

    public static void Reset()//Reset BattleInfo
    {
        enemyInbattle.Clear();
        characterInbattle.Clear();
    }

    public static Vector3 camera_target_distance;//紀錄從相機到目標的向量
    public static Vector3 camera_first_position;//記錄相機最開始的位置
}
