using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Obj_Aristas
{
    // datos de identificación y definición de la arista
    public int id;

    public int idOrig;
    public int idDest;
    public int peso;

    // datos y métodos del objeto arista

    public object dato2;

    public string descripcion()
    {
        return "Arista id: " + id.ToString() + ", Nodo Origen: " + idOrig.ToString() + ", Nodo Destino: " + idDest.ToString() + ", Peso: " + peso.ToString();
    }
}
