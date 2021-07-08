using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTF : QueuePriorotyTDA
{
    private int index;
    public Player1[] Ranking;

    public void InitiaiizeQueue()
    {
        Ranking = new Player1[5];
        index = 0;
    }

    public void Enqueue(Player1 playerName)
    {
        if(QueueEmpty())
        {
            Ranking[0] = playerName;
            index++;
        }
        else if (index < Ranking.Length)
        {
            Ranking[index] = playerName;
            index++;
        }
    }

    public void Dequeue()
    {
        Ranking[index-1] = null;
        index--;
    }

    public Player1 DequeueWithReturn()
    {
        var playerName = Ranking[index - 1];
        Ranking[index - 1] = null;
        index--;

        return playerName;
    }

    public Player1 First() => Ranking[index-1];  

    public int Priority() => Ranking[index-1].Score;

    public bool QueueEmpty() => (index == 0);

    public Player1[] GetRanking()
    {
        quickSort(Ranking, 0, index > 0 ? index -1 : 0);

        return Ranking;
    }

    public int Partition(Player1[] arr, int left, int right)
    {
        int pivot;
        int aux = (left + right) / 2;   
        pivot = arr[aux].Score;

        Debug.Log(string.Format("left: {0}, right: {1}", left, right));
        
        while (true)
        {
            
            while (arr[left].Score > pivot)
            {
                Debug.Log("Left");
                left++;
            }
            while (arr[right].Score < pivot)
            {
                Debug.Log("Right");
                right--;
            }
            if (left < right)
            {
                Player1 temp = arr[right];
                arr[right] = arr[left];
                arr[left] = temp;
            }
            else
            {
                return right;
            }
        }
    }

    public void quickSort(Player1[] arr, int left, int right)
    {
        int pivot;
        if (left < right)
        {
            pivot = Partition(arr, left, right);
            if (pivot > 1)
            {
                
                quickSort(arr, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                
                quickSort(arr, pivot + 1, right);
            }
        }
    }
}