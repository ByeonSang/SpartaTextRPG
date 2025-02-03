using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaTextRPG.Interface;

namespace SpartaTextRPG
{
    public enum EntityType
    {
        None,
        Player,
        Monster,
    }
    internal abstract class Entity : ICharacter
    {
        public Entity(string _name, int _level, int _health, int _defence, int _attack) 
        {
            name = _name;
            level = _level;
            health = _health;
            defence = _defence;
            attack = _attack;
        }

        public abstract void TakeDamage(int _damage);

        private int level;
        public int Level { get => level; set => level = value; }

        private string name;
        public string Name { get => name; set => name = value; }

        private int health;
        public int Health { get => health; 
            set
            {
                health = value;

                if (health < 0)
                    health = 0;
                else if (health > 300)
                    health = 300;
            }
                
        }

        private int defence;
        public int Defence { get => defence; set => defence = value; }

        private int attack;
        public int Attack { get => attack; set => attack = value; }

        private EntityType type;
        public EntityType Type { get => type; set => type = value; }

    }
}
