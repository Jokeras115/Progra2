using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._MyAssets.Characters.Player.Scritps.ColaTDA
{
    public interface IColaPrioridadTDA
    {
        //initialize the structure
        void InicializeCola();

        //enter an element into the structure, sorting it by priority
        void AcolarPriorities(string valor, int prioridad);

        //removes the "first" value from the structure (the next to exit, the one with the highest priority) 
        void Desacolar();

        //indicates if there are elements in the structure
        bool EmptyCola();

        //returns the "first" value of the structure (the next to exit, the one with the highest priority)
        string FirstOne();

        //returns the priority of the "first" value of the structure(the next to exit, the one with the highest priority)
        int Priority();
    }
}
