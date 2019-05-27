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

    void Backpack()
    {
        Debug.Log("Backpack");
    }

    void Botton5()
    {
        Debug.Log("Botton5");
    }

    void Action(string n)
    {
        switch (n)
        {
            case "Botton":
                Attact();
                break;
            case "Botton (1)":
                HAttact();
                break;
            case "Botton (2)":
                Skill();
                break;
            case "Botton (3)":
                Backpack();
                break;
            case "Botton (4)":
                Botton5();
                break;
            default:
                break;
        }
    }
}
