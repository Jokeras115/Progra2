using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    QueueTF queue = new QueueTF();
    public List<GameObject> rankingRowElements;

    void Start()
    {
        queue.InitiaiizeQueue();
        UpdateSceen();

        var list = Database.current.GetAllRankings();
        foreach (var playerName in list)
        {
            queue.Enqueue(playerName);
            UpdateSceen();
        }
    }

    public void AddPlayerOnRanking()
    {
        var playerName = new Player1();

        Database.current.InsertRanking(playerName);
        playerName = Database.current.GetLatestRanking();

        queue.Enqueue(playerName);
        UpdateSceen();
        
    }

    public void RemovePlayerFromRanking()
    {
        
        var playerName = queue.DequeueWithReturn();
        Database.current.DeleteRanking(playerName);

        UpdateSceen();
        
    }

    public void ResetRanking()
    {
        queue.InitiaiizeQueue();
        UpdateSceen();
        Database.current.DropTableRanking();
        Database.current.CreateTableRanking();
    }

    private void PrintQueue()
    {
        foreach( var playerName in queue.GetRanking() )
        {
            if(playerName != null)
            {
                Debug.Log(string.Format("PlayerName: {0} - Score: {1}", playerName.PlayerName, playerName.Score));
            }
        }
    }

    private void UpdateSceen()
    {
        var ranking = queue.GetRanking();

        for(int i=0; i< 5; i++)
        {
            rankingRowElements[i].GetComponent<RankingRowElement>().SetDefaultText();

            if(ranking[i] != null)
            {
                rankingRowElements[i].GetComponent<RankingRowElement>().SetInfo(
                    ranking[i].PlayerName,
                    ranking[i].Score
                );
            }
        }
    }
}