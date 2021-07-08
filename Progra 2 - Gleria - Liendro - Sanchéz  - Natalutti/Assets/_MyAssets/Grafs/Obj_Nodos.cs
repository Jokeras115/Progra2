using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Obj_Nodos
{
    // dato de identificación del nodo
    public int id;

    // datos y métodos del objeto nodo
    public GameObject gameObj;

    public object dato2;

    public string descripcion()
    {
        return "Nodo id: " + id.ToString();
    }
}
