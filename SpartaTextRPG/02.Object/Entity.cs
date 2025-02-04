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
        public Entity(string _name, int _level, int _maxHealth, int _defence, float _attack) 
        {
            name = _name;
            level = _level;
            maxHealth = _maxHealth;
            health = _maxHealth;
            defence = _defence;
            attack = _attack;
        }

        public abstract void TakeDamage(int _damage);

        private int level;
        public int Level { get => level; set => level = value; }

        private string name;
        public string Name { get => name; set => name = value; }

        private int maxHealth;
        public int MaxHealth { get => maxHealth; }

        private int health;
        public int Health { get => health; 
            set
            {
                health = value;

                if (health < 0)
                    health = 0;
                else if (health > maxHealth)
                    health = maxHealth;
            }
                
        }

        private int defence;
        public int Defence { get => defence; set => defence = value; }

        private float attack;
        public float Attack { get => attack; set => attack = value; }

        private EntityType type;
        public EntityType Type { get => type; set => type = value; }

        

    }
}
