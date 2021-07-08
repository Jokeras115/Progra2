using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamesBaseCollection
{
    private List<string> NameCollection = new List<string>
    {
        "Jugador1",
        "Jugador2",
        "Jugador3",
        "Jugador4",
        "Jugador5",
    };

    public string GetRandomName()
    {
        return NameCollection[Random.Range(0, NameCollection.Count)];
    }
}
