using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._MyAssets.Characters.Player.Scritps.ColaTDA
{
    public class ColaTDA : IColaPrioridadTDA
    {
        #region Private Variables
        string[] elements; //arrangement where the information is stored
        int[] priorities; //integer variable where the amount of elements that have been saved is saved
        int index;
        #endregion

        public void InicializeCola()
        {
            elements = new string[100];
            priorities = new int[100];
            index = 0;
        }

        public void AcolarPriorities(string x, int priority)
        {
            int j;
            // al ingresar cada elemento se ingresa en el orden de acuerdo a su prioridad
            for (j = index; j > 0 && priorities[j - 1] >= priority; j--)
            {
                elements[j] = elements[j - 1];
                priorities[j] = priorities[j - 1];
            }
            elements[j] = x;
            priorities[j] = priority;

            index++;
        }

        public void Desacolar()
        {
            index--;
        }

        public bool EmptyCola()
        {
            return (index == 0);
        }

        public string FirstOne()
        {
            return elements[index - 1];
        }

        public int Priority()
        {
            return priorities[index - 1];
        }
    }
}
