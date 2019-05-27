using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//控制戰鬥環的旋轉
public class BattleRing : MonoBehaviour {

    public float speed = 0.01f;
    public float first_angle_x;
    public float first_angle_y;
    public float now_rotate;
    public float buffer;
    public float camera_rotat;
    public float pos;//生成的位置 百分比
    public GameObject button; //五個按鈕
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject now_camera;
    public static bool iscancel = false;
    public Vector3 offset;
    public Quaternion rotat;

    private float distance = 6;                                                            //滑鼠點擊距離
    private Vector3 firstPosition;
    private Vector3 dragPosition;
    //Character_Object character;

    void OnEnable()
    {
        //character = BattleInfo.attact_character.GetComponent<Character_Object>();
        //now_camera = character.character_camera;
        Vector3 position = now_camera.transform.position + BattleInfo.camera_target_distance * pos;
        Vector3 rotat = Vector3.zero;
        rotat.y = now_camera.transform.rotation.eulerAngles.y;
        position.y += offset.y;
        //position.z += offset.z;
        transform.position = position;
        button.transform.LookAt(now_camera.transform.position);
        transform.rotation = Quaternion.Euler(rotat);
        //transform.RotateAround(now_camera.transform.position, Vector3.up, rotat.y);
        first_angle_x = button.transform.rotation.eulerAngles.x;
        first_angle_y = transform.rotation.eulerAngles.y;
        SetButton();
        Zoom_In(button);
    }

    void OnDisable()
    {
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        button.transform.rotation = new Quaternion(0, 0, 0, 0);
        button1.transform.rotation = new Quaternion(0, 0, 0, 0);
        button2.transform.rotation = new Quaternion(0, 0, 0, 0);
        button3.transform.rotation = new Quaternion(0, 0, 0, 0);
        button4.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void OnMouseDown()                                                                      //滑鼠按下 設定初始位置
    {
        Vector3 mouse = Input.mousePosition;
        firstPosition = mouse;
    }

    void OnMouseDrag()                                                                      //根據拖曳距離方向 旋轉圓環
    {
        Zoom_Out();
        Vector3 mouse = Input.mousePosition;
        float angle = 0.0f;
        mouse.z = distance;
        dragPosition = mouse;
        angle = dragPosition.x - firstPosition.x;

        transform.Rotate(0, -angle * speed, 0);
        button.transform.Rotate(0, angle * speed, 0);//旋轉每個按鈕 持續正面朝向鏡頭
        button1.transform.Rotate(0, angle * speed, 0);
        button2.transform.Rotate(0, angle * speed, 0);
        button3.transform.Rotate(0, angle * speed, 0);
        button4.transform.Rotate(0, angle * speed, 0);
        SetButton();
    }

    void SetButton()
    {
        button.transform.LookAt(now_camera.transform.position);
        button1.transform.LookAt(now_camera.transform.position);
        button2.transform.LookAt(now_camera.transform.position);
        button3.transform.LookAt(now_camera.transform.position);
        button4.transform.LookAt(now_camera.transform.position);
    }

    void OnMouseUp()
    {
        //now_rotate = transform.rotation.eulerAngles.y;
        //if (now_rotate >= 180)
        //{
        //    now_rotate -= 360;
        //}
        //buffer = first_angle - now_rotate;
        //if (buffer > 360)
        //{
        //    buffer -= 360;
        //}
        //else if (buffer < 0)
        //{
        //    buffer += 360;
        //}
        //if (buffer > 0 && buffer < 72)
        //{
        //    Rotate();
        //}
        //else if (buffer > 72 && buffer < 144)
        //{
        //    buffer -= 72;
        //    Rotate();
        //}
        //else if (buffer > 144 && buffer < 216)
        //{
        //    buffer -= 144;
        //    Rotate();
        //}
        //else if (buffer > 216 && buffer < 288)
        //{
        //    buffer -= 216;
        //    Rotate();
        //}
        //else if (buffer > 288 && buffer < 360)
        //{
        //    buffer -= 288;
        //    Rotate();
        //}


        now_rotate = transform.rotation.eulerAngles.y;
        buffer = now_rotate - first_angle_y;
        if (buffer > 360)
        {
            buffer -= 360;
        }
        else if (buffer < 0)
        {
            buffer += 360;
        }
        if (buffer > 0 && buffer < 72)
        {
            if (buffer <= 36)
            {
                buffer = 0;
                Zoom_In(button);
            }
            else if (buffer > 36)
            {
                buffer = 72;
                Zoom_In(button4);
            }
        }
        else if (buffer > 72 && buffer < 144)
        {
            if (buffer <= 108)
            {
                buffer = 72;
                Zoom_In(button4);
            }
            else if (buffer > 108)
            {
                buffer = 144;
                Zoom_In(button3);
            }
        }
        else if (buffer > 144 && buffer < 216)
        {
            if (buffer <= 180)
            {
                buffer = 144;
                Zoom_In(button3);
            }
            else if (buffer > 180)
            {
                buffer = 216;
                Zoom_In(button2);
            }
        }
        else if (buffer > 216 && buffer < 288)
        {
            if (buffer <= 252)
            {
                buffer = 216;
                Zoom_In(button2);
            }
            else if (buffer > 252)
            {
                buffer = 288;
                Zoom_In(button1);
            }
        }
        else if (buffer > 288 && buffer < 360)
        {
            if (buffer <= 324)
            {
                buffer = 288;
                Zoom_In(button1);
            }
            else if (buffer > 324)
            {
                buffer = 360;
                Zoom_In(button);
            }
        }
        buffer += first_angle_y;
        rotat = Quaternion.Euler(0, buffer, 0);
        transform.rotation = rotat;
        button.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
        button1.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
        button2.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
        button3.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
        button4.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
    }

    void Zoom_Out()
    {
        button.transform.localScale = new Vector3(1, 1, 1);
        button1.transform.localScale = new Vector3(1, 1, 1);
        button2.transform.localScale = new Vector3(1, 1, 1);
        button3.transform.localScale = new Vector3(1, 1, 1);
        button4.transform.localScale = new Vector3(1, 1, 1);
    }

    void Zoom_In(GameObject a)//放大按鈕
    {
        a.transform.localScale = new Vector3(2, 2, 0);
    }

    //void Rotate()
    //{
    //    if (buffer < 36)
    //    {
    //        Min_Rotate();
    //    }
    //    else if (buffer > 36)
    //    {
    //        buffer = 72 - buffer;
    //        Max_Rotate();
    //    }
    //}

    //void Min_Rotate()
    //{
    //    transform.Rotate(0, buffer, 0);
    //    button.transform.Rotate(0, -buffer, 0);//旋轉每個按鈕 持續正面朝向鏡頭
    //    button1.transform.Rotate(0, -buffer, 0);
    //    button2.transform.Rotate(0, -buffer, 0);
    //    button3.transform.Rotate(0, -buffer, 0);
    //    button4.transform.Rotate(0, -buffer, 0);
    //}

    //void Max_Rotate()
    //{
    //    transform.Rotate(0, -buffer, 0);
    //    button.transform.Rotate(0, buffer, 0);//旋轉每個按鈕 持續正面朝向鏡頭
    //    button1.transform.Rotate(0, buffer, 0);
    //    button2.transform.Rotate(0, buffer, 0);
    //    button3.transform.Rotate(0, buffer, 0);
    //    button4.transform.Rotate(0, buffer, 0);
    //}

    public void InCancel()
    {
        iscancel = true;
    }
}
