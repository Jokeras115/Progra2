using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface QueuePriorotyTDA 
{
 
    void InitiaiizeQueue();


    void Enqueue(Player1 playerName);

 
    void Dequeue();


    bool QueueEmpty();

    Player1 First();


    int Priority();
}
