using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._MyAssets.Characters.Player.Scritps.ColaTDA
{
    public struct LifeStruct
    {
        public LifeStruct(int intValue, string strValue)
        {
            Life = intValue;
            Name = strValue;
        }

        public int Life { get; private set; }
        public string Name { get; private set; }
    }
}
