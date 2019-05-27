using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttactSelect : MonoBehaviour {
    public GameObject battle_ring;
    public GameObject cancel_button;
    public GameObject zoomin_camera;

    void Select()
    {
        BattleInfo.now_action_character.TimerReset();
        BattleInfo.inbattle = true;
        zoomin_camera.transform.position = BattleInfo.camera_first_position;
        zoomin_camera.transform.rotation = Quaternion.identity;
        Time.timeScale = 1;
    }

    void CancelButoon()
    {
        battle_ring.SetActive(true);
        cancel_button.SetActive(false);
    }
}
