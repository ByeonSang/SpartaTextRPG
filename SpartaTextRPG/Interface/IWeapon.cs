using SpartaTextRPG._02.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG.Interface
{
    internal interface IWeapon
    {
        public WeaponType wpType { get; set; }
    }
}
