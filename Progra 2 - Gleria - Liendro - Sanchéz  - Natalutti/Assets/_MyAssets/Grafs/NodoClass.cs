using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoClass : MonoBehaviour
{
    public int id;
    public bool selected;
    public SpriteRenderer sprite;
    GameManager gm;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MediPack tempPack = collision.gameObject.GetComponent<MediPack>();
        if (tempPack != null)
        {
            gm.medikitsID.Add(id);
        }
        PlayerController tempPlayer = collision.gameObject.GetComponent<PlayerController>();
        if (tempPlayer != null)
        {
            gm.node1ID = id;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        MediPack tempPack = collision.gameObject.GetComponent<MediPack>();
        if (tempPack != null)
        {
            gm.medikitsID.Remove(id);
        }
    }
}
