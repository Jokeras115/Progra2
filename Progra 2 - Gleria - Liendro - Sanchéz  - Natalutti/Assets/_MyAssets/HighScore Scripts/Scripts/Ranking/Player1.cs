using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1
{
    public int Id { get; set; }
    public string PlayerName { get; set; }
    public int Score { get; set; }

    public Player1()
    {
        var nameCollection = new NamesBaseCollection();

        this.PlayerName = nameCollection.GetRandomName();
        this.Score = Random.Range(0, 10000);
    }
}
