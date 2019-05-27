﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{
    protected Joystick joystick;                                                //宣告虛擬搖桿
    public float speed;
    public Animator animator;
    public GameObject player_pointer;

    float volume = 0;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        joystick = FindObjectOfType<Joystick>();//綁定虛擬搖桿  rb
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Time.timeScale = 1;
        //InvokeRepeating("VolumeUp", 0.1f, 0.1f);
    }

    void FixedUpdate()
    {
        float moveHorizontal = joystick.Horizontal;                             //移動角色
        float moveVertical = joystick.Vertical;
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            animator.Play("Angelu2DIdle");
            animator.SetBool("isIdle", true);
            //animator.SetBool("isForward", false);
            //animator.SetBool("isBack", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
        }
        else if (moveHorizontal >= 0 && moveVertical > 0)//第一象限
        {
            if (moveHorizontal < moveVertical)
            {
                ExploreRight();
            }
            else
            {
                ExploreRight();
            }
        }
        else if (moveHorizontal < 0 && moveVertical >= 0)//第二象限
        {
            if (-moveHorizontal > moveVertical)
            {
                ExploreLeft();
            }
            else
            {
                ExploreLeft();
            }

        }
        else if (moveVertical < 0 && moveHorizontal <= 0)//第三象限
        {
            if (-moveHorizontal < -moveVertical)
            {
                ExploreLeft();
            }
            else
            {
                ExploreLeft();
            }
        }
        else if (moveVertical <= 0 && moveHorizontal > 0)//第四象限
        {
            if (moveHorizontal > -moveVertical)
            {
                ExploreRight();
            }
            else
            {
                ExploreRight();
            }
        }
        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);
        transform.position += (movement * speed);
    }

    void ExploreLeft()
    {
        animator.Play("Angelu2DLeft");
        animator.SetBool("isIdle", false);
        //    animator.SetBool("isForward", false);
        //    animator.SetBool("isBack", false);
        animator.SetBool("isLeft", true);
        animator.SetBool("isRight", false);
        //    player_pointer.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    void ExploreRight()
    {
        animator.Play("Angelu2DRight");
        animator.SetBool("isIdle", false);
        //animator.SetBool("isForward", false);
        //animator.SetBool("isBack", false);
        animator.SetBool("isLeft", false);
        animator.SetBool("isRight", true);
        //player_pointer.transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    void ExploreForward()
    {
        //animator.Play("ExploreForward");
        //animator.SetBool("isIdle", false);
        //animator.SetBool("isForward", true);
        //animator.SetBool("isBack", false);
        //animator.SetBool("isLeft", false);
        //animator.SetBool("isRight", false);
        //player_pointer.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void ExploreBack()
    {
        //animator.Play("ExploreBack");
        //animator.SetBool("isIdle", false);
        //animator.SetBool("isForward", false);
        //animator.SetBool("isBack", true);
        //animator.SetBool("isLeft", false);
        //animator.SetBool("isRight", false);
        //player_pointer.transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    //void OnTriggerEnter(Collider other)                                         //接觸到怪物時進入戰鬥場景
    //{
    //    if (other.gameObject.CompareTag("Monster"))
    //    {
    //        enemyname = other.name;
    //        Destroy(other.gameObject);
    //        SceneManager.LoadScene(gototheScene);
    //    }
    //}

    private void OnDestroy()
    {
    }

    void Start_Music()
    {
    }

    void VolumeUp()
    {
        //volume += Time.deltaTime;
        //audioSource.volume = volume;
        //if (volume > 0.5)
        //{
        //    CancelInvoke("VolumeUp");
        //}
    }
}

