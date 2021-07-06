using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public interface ConjuntoTDA
{
    void InicializarConjunto();
    bool ConjuntoVacio();
    void Agregar(int x);
    int Elegir();
    void Sacar(int x);
    bool Pertenece(int x);
}