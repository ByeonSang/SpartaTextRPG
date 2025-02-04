using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._02.Object
{
    public enum ItemType
    {
        None,
        Equipment,
        Consumption,
        ETC,

    }

    public enum WeaponType
    {
        SWORD,
        SPEAR,
        STAFF,
        WAND,
    }

    internal class Item
    {
        public Item() 
        {
            name = "";
            information = "";
            jobType = JobType.None;
            itemType = ItemType.None;
        }

        public void SetInfoWrite(string str)
        {
            information = str;
        }

        private string name;
        public string Name { get => name; protected set => name = value; }

        private string information;
        public string Information { get => information; }


        private int gold;
        public int Gold { get => gold; protected set => gold = value; }

        private JobType jobType;
        public JobType Job { get => jobType; set => jobType = value; } // 직업에 따라서 장착 여부

        private ItemType itemType;
        public ItemType Type { get => itemType; set => itemType = value; }
    }
}
