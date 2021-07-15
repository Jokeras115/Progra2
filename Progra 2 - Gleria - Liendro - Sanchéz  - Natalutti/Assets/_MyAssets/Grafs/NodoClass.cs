using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoClass : MonoBehaviour
{
    public int id;
    public bool selected;
    public SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MediPack tempPack = collision.gameObject.GetComponent<MediPack>();
        if (tempPack != null)
        {
            GameManager.managerInstance.medikitsID.Add(id);
        }
        PlayerController tempPlayer = collision.gameObject.GetComponent<PlayerController>();
        if (tempPlayer != null)
        {
            GameManager.managerInstance.node1ID = id;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        MediPack tempPack = collision.gameObject.GetComponent<MediPack>();
        if (tempPack != null)
        {
            GameManager.managerInstance.medikitsID.Remove(id);
        }
    }
}
