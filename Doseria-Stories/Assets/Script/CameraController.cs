using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;//Camera要面向的物件
    public GameObject battle_ring;
    public Vector3 cameraPosition;//相機的位置
    public Vector3 targetPosition;//相機要移動的位置
    public Vector3 offset;
    public float speed;//相機環繞移動的速度
    public float number;

    public float radius;//移動的半徑

    private void Start()
    {
        BattleInfo.camera_first_position = transform.position;
    }

    private void FixedUpdate()
    {
        //使用Time.deltaTime，使得移動時更加平滑
        //將速度進行一定比例縮放，方便控制速度(縮放多少都隨意，自己覺得數值修改方便就好)
        //number += 0.0002f * speed * Time.realtimeSinceStartup;

        //計算並設定新的y和z軸位置
        //負數是順時針旋轉，正數是逆時針旋轉
        //cameraPosition.y = radius * Mathf.Sin(number);
        //cameraPosition.z = radius * Mathf.Cos(-number);
        //transform.position = cameraPosition + offset;

        //使相機永遠面對著目標物件
        //transform.LookAt(target.transform.position);

        //transform.Rotate(new Vector3(0, 1, 0));
    }

    void Zoom()
    {
        target = BattleInfo.now_action_character.CharacterObj;
        Debug.Log(BattleInfo.now_action_character.CharacterObj);
        //由於我這個範例是y和z軸的移動，而x軸不會改變，所以要先設定好x軸的初始位置
        cameraPosition.x = transform.position.x;
        transform.position = cameraPosition;
        targetPosition = target.transform.position;
        targetPosition.y += 4;
        //計算當前攝影機和目標物件的半徑
        radius = Vector3.Distance(targetPosition, target.transform.position);
        InvokeRepeating("ZoomIn", 0f, 0.01f);
    }

    private void ZoomIn()
    {
        //使用Time.deltaTime，使得移動時更加平滑
        //將速度進行一定比例縮放，方便控制速度(縮放多少都隨意，自己覺得數值修改方便就好)
        number += 0.2f * speed * Time.deltaTime;

        //計算並設定新的x和y軸位置
        //負數是順時針旋轉，正數是逆時針旋轉
        cameraPosition.y = radius * Mathf.Sin(number);
        cameraPosition.z = radius * Mathf.Cos(-number);
        transform.position = cameraPosition + offset;

        //使相機永遠面對著目標物件
        transform.LookAt(target.transform.position);
        if (transform.position.y < 4f)
        {
            CancelInvoke("ZoomIn");
            BattleInfo.camera_target_distance = target.transform.position - transform.position;
            battle_ring.SetActive(true);
            Time.timeScale = 0;
            number = 1.84f;
        }
    }
}
