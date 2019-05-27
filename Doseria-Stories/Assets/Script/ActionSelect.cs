using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelect : MonoBehaviour {
    public GameObject battle_ring;
    public GameObject cancel_button;

    void Attact()
    {
        cancel_button.SetActive(true);
        battle_ring.SetActive(false);
        Debug.Log("Attact");
    }

    void HAttact()
    {
        Debug.Log("HAttact");
    }

    void Skill()
    {
        Debug.Log("Skill");
    }

    void Defence()
    {
        Debug.Log("Defence");
    }

    void Backpack()
    {
        Debug.Log("Backpack");
    }

    void Move()
    {
        Debug.Log("Move");
    } 

    void Action(string n)
    {
        switch (n)
        {
            case "Attact":
                Attact();
                break;
            case "HAttact":
                HAttact();
                break;
            case "Skill":
                Skill();
                break;
            case "Defence":
                Defence();
                break;
            case "Backpack":
                Backpack();
                break;
            case "Move":
                Move();
                break;
            default:
                break;
        }
    }
}
