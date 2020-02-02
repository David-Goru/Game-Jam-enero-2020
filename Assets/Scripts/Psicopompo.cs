using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psicopompo : MonoBehaviour
{
    void OnMouseEnter()
    {
        transform.Find("Light").gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        transform.Find("Light").gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        GameObject.Find("UI").transform.Find("Upgrades").gameObject.SetActive(true);
    }
}