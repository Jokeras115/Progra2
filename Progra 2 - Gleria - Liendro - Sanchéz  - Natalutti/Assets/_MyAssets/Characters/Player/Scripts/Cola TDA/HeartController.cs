using System.Collections;
using System.Collections.Generic;
using Assets._MyAssets.Characters.Player.Scritps.ColaTDA;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    #region Private Variables
    private ColaTDA cola;
    private List<LifeStruct> heartList;
    #endregion

    #region Public Variables
    public GameObject[] heartIMG = new GameObject[5];
    #endregion

    #region Unity Methods
    
    void Start()
    {
        cola = new ColaTDA();
        cola.InicializeCola();
    }

    void Update()
    {
        
    }
    #endregion

    #region Public Functions
    public void CreateHeart()
    {
        heartList = new List<LifeStruct>();
        heartList.Add(new LifeStruct(Random.Range(0, 6000), "One"));
        heartList.Add(new LifeStruct(Random.Range(0, 6000), "Two"));
        heartList.Add(new LifeStruct(Random.Range(0, 6000), "Three"));
        heartList.Add(new LifeStruct(Random.Range(0, 6000), "Four"));
        heartList.Add(new LifeStruct(Random.Range(0, 6000), "Five"));

        for (int i = 0; i < heartList.Count; i++)
        {
            cola.AcolarPriorities(heartList[i].Name, heartList[i].Life);
        }
    }

    public void DelateHeart()
    {
        for (int i = 0; i < heartIMG.Length; i++)
        {
            cola.Desacolar();
        }
    }
    #endregion
}
