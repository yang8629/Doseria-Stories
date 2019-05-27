using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPress : MonoBehaviour {
    public ActionSelect ActionSelect;

    void OnMouseDown()
    {
        ActionSelect.SendMessage("Action", gameObject.name);
    }
}
