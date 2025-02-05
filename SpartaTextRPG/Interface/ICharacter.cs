using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG.Interface
{
    internal interface ICharacter
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Defence { get; set; }
        public float Attack { get; set; }

        public bool IsDead { get; }
    }
}
