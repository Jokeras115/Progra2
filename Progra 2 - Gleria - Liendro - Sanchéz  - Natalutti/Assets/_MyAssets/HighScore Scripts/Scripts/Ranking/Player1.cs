using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1
{
    public int Id { get; set; }
    public string PlayerName { get; set; }
    public int Score { get; set; }

    public Player1(string name = "Lazy", int pscore = -1)
    {
        PlayerName = name;
        if (pscore < 0)
            Score = Random.Range(0, 9999);
        else
            Score = pscore;
    }
}
