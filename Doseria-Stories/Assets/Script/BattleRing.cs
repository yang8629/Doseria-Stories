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
    public GameObject Attact; //五個按鈕
    public GameObject HAttact;
    public GameObject Skill;
    public GameObject Defence;
    public GameObject Backpack;
    public GameObject Move;
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
        Attact.transform.LookAt(now_camera.transform.position);
        transform.rotation = Quaternion.Euler(rotat);
        //transform.RotateAround(now_camera.transform.position, Vector3.up, rotat.y);
        first_angle_x = Attact.transform.rotation.eulerAngles.x;
        first_angle_y = transform.rotation.eulerAngles.y;
        SetButton();
        Zoom_In(Attact);
        GetComponent<SphereCollider>().enabled = true;
        Attact.GetComponent<SphereCollider>().enabled = true;
        HAttact.GetComponent<SphereCollider>().enabled = true;
        Skill.GetComponent<SphereCollider>().enabled = true;
        Defence.GetComponent<SphereCollider>().enabled = true;
        Backpack.GetComponent<SphereCollider>().enabled = true;
        Move.GetComponent<SphereCollider>().enabled = true;
    }

    void OnDisable()
    {
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        Attact.transform.rotation = new Quaternion(0, 0, 0, 0);
        HAttact.transform.rotation = new Quaternion(0, 0, 0, 0);
        Skill.transform.rotation = new Quaternion(0, 0, 0, 0);
        Defence.transform.rotation = new Quaternion(0, 0, 0, 0);
        Backpack.transform.rotation = new Quaternion(0, 0, 0, 0);
        Move.transform.rotation = new Quaternion(0, 0, 0, 0);
        GetComponent<SphereCollider>().enabled = false;
        Attact.GetComponent<SphereCollider>().enabled = false;
        HAttact.GetComponent<SphereCollider>().enabled = false;
        Skill.GetComponent<SphereCollider>().enabled = false;
        Defence.GetComponent<SphereCollider>().enabled = false;
        Backpack.GetComponent<SphereCollider>().enabled = false;
        Move.GetComponent<SphereCollider>().enabled = false;
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
        Attact.transform.Rotate(0, angle * speed, 0);//旋轉每個按鈕 持續正面朝向鏡頭
        HAttact.transform.Rotate(0, angle * speed, 0);
        Skill.transform.Rotate(0, angle * speed, 0);
        Defence.transform.Rotate(0, angle * speed, 0);
        Backpack.transform.Rotate(0, angle * speed, 0);
        Move.transform.Rotate(0, angle * speed, 0);
        SetButton();
    }

    void SetButton()
    {
        Attact.transform.LookAt(now_camera.transform.position);
        HAttact.transform.LookAt(now_camera.transform.position);
        Skill.transform.LookAt(now_camera.transform.position);
        Defence.transform.LookAt(now_camera.transform.position);
        Backpack.transform.LookAt(now_camera.transform.position);
        Move.transform.LookAt(now_camera.transform.position);
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
        if (buffer > 0 && buffer < 60)
        {
            if (buffer <= 30)
            {
                buffer = 0;
                Zoom_In(Attact);
            }
            else if (buffer > 30)
            {
                buffer = 60;
                Zoom_In(Move);
            }
        }
        else if (buffer > 60 && buffer < 120)
        {
            if (buffer <= 90)
            {
                buffer = 60;
                Zoom_In(Move);
            }
            else if (buffer > 90)
            {
                buffer = 120;
                Zoom_In(Backpack);
            }
        }
        else if (buffer > 120 && buffer < 180)
        {
            if (buffer <= 150)
            {
                buffer = 120;
                Zoom_In(Backpack);
            }
            else if (buffer > 150)
            {
                buffer = 180;
                Zoom_In(Defence);
            }
        }
        else if (buffer > 180 && buffer < 240)
        {
            if (buffer <= 210)
            {
                buffer = 180;
                Zoom_In(Defence);
            }
            else if (buffer > 210)
            {
                buffer = 240;
                Zoom_In(Skill);
            }
        }
        else if (buffer > 240 && buffer < 300)
        {
            if (buffer <= 270)
            {
                buffer = 240;
                Zoom_In(Skill);
            }
            else if (buffer > 270)
            {
                buffer = 300;
                Zoom_In(HAttact);
            }
        }
        else if (buffer > 300 && buffer < 360)
        {
            if (buffer <= 330)
            {
                buffer = 300;
                Zoom_In(HAttact);
            }
            else if (buffer > 330)
            {
                buffer = 360;
                Zoom_In(Attact);
            }
        }
        buffer += first_angle_y;
        rotat = Quaternion.Euler(0, buffer, 0);
        transform.rotation = rotat;
        Attact.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
        HAttact.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
        Skill.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
        Defence.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
        Backpack.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
        Move.transform.rotation = Quaternion.Euler(first_angle_x, 180 + first_angle_y, 0);
    }

    void Zoom_Out()
    {
        Attact.transform.localScale = new Vector3(1, 1, 1);
        HAttact.transform.localScale = new Vector3(1, 1, 1);
        Skill.transform.localScale = new Vector3(1, 1, 1);
        Defence.transform.localScale = new Vector3(1, 1, 1);
        Backpack.transform.localScale = new Vector3(1, 1, 1);
        Move.transform.localScale = new Vector3(1, 1, 1);
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
    //    Attact.transform.Rotate(0, -buffer, 0);//旋轉每個按鈕 持續正面朝向鏡頭
    //    HAttact.transform.Rotate(0, -buffer, 0);
    //    Skill.transform.Rotate(0, -buffer, 0);
    //    Defence.transform.Rotate(0, -buffer, 0);
    //    Backpack.transform.Rotate(0, -buffer, 0);
    //}

    //void Max_Rotate()
    //{
    //    transform.Rotate(0, -buffer, 0);
    //    Attact.transform.Rotate(0, buffer, 0);//旋轉每個按鈕 持續正面朝向鏡頭
    //    HAttact.transform.Rotate(0, buffer, 0);
    //    Skill.transform.Rotate(0, buffer, 0);
    //    Defence.transform.Rotate(0, buffer, 0);
    //    Backpack.transform.Rotate(0, buffer, 0);
    //}

    public void InCancel()
    {
        iscancel = true;
    }
}
