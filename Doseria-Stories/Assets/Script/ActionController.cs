using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//角色行動的計算
//紀錄攻擊的方式與當前行動者
public class ActionController : MonoBehaviour {
    public int player_count;
    public GameObject battle_ring;
    public GameObject zoomin_camera;

    void Awake()
    {

    }

    void Start()
    {
        player_count = BattleInfo.characterInbattle.Count;
    }

    private void FixedUpdate()
    {
        Timer();
    }

    void Timer()//行動值計算 根據角色靈敏值
    {
        if (BattleInfo.inbattle)//戰鬥中
        {
            for (int i = 0; i < player_count; i++)
            {
                if (BattleInfo.characterInbattle[i].Moving == false && BattleInfo.characterInbattle[i].Dead == false)
                {
                    BattleInfo.characterInbattle[i].Timer += Time.deltaTime * BattleInfo.characterInbattle[i].Ag;
                    Debug.Log(BattleInfo.characterInbattle[i].Name + ": Timer= " + BattleInfo.characterInbattle[i].Timer);
                    if (BattleInfo.characterInbattle[i].Timer > 10)
                    {
                        BattleInfo.now_action_character.NowAction(BattleInfo.characterInbattle[i]);
                        BattleInfo.inbattle = false;
                        zoomin_camera.SendMessage("Zoom");
                    }
                }
            }
        }
    }
}
