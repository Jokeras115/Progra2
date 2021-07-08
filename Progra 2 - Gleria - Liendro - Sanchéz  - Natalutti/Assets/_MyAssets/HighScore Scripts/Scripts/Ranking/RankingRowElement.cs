using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingRowElement : MonoBehaviour
{
    public Text PlayerName;
    public Text Score;

    public void SetDefaultText()
    {
        this.PlayerName.text = "---";
        this.Score.text = "---";
    }

    public void SetInfo(string playerName, int score)
    {
        this.PlayerName.text = playerName;
        this.Score.text = score.ToString();
    }
}

