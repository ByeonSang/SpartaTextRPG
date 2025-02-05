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
            isDead = false;
        }

        public abstract void TakeDamage(int _damage);

        protected int level;
        public int Level { get => level; set => level = value; }

        protected string name;
        public string Name { get => name; set => name = value; }

        protected int maxHealth;
        public int MaxHealth { get => maxHealth; }

        protected int health;
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

        protected int defence;
        public int Defence { get => defence; set => defence = value; }

        protected float attack;
        public float Attack { get => attack; set => attack = value; }

        protected EntityType type;
        public EntityType Type { get => type; set => type = value; }

        protected bool isDead;
        public bool IsDead { get => isDead;}
    }
}
