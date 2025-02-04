using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpartaTextRPG._03.Dungeon
{
    internal abstract class Dungeon
    {
        public Dungeon(Player _player)
        {
            player = _player;
            name = "";
            level = 0;
            recommendDefence = new int[3]; // Easy, Normal, Hard
            clearGold = new int[3];
            clearExp = new int[3];
            amountDamage = new KeyValuePair<int, int>[3]; // Key: 최소 대미지, Value : 최대 대미지
            
        }

        /// <summary>
        /// 모든 초기화 부분이 포함시키고 생성자에 삽입
        /// InitDefence(), InitDamage(), InitClearGold(), InitClearExp()
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// int[] 타입인 recommendDefence 초기화하는 부분 ( 길이 3 )
        /// </summary>
        public void InitDefence(int easy, int normal, int hard)
        {
            recommendDefence[0] = easy;
            recommendDefence[1] = normal;
            recommendDefence[2] = hard;
        }

        /// <summary>
        /// KeyValuePair타입인 amountDamage 초기화하는 부분 ( 길이 3 )
        /// </summary>
        public void InitDamage(KeyValuePair<int,int>easy, KeyValuePair<int, int> normal, KeyValuePair<int, int> hard)
        {
            amountDamage[0] = easy;
            amountDamage[1] = normal;
            amountDamage[2] = hard;
        }

        /// <summary>
        /// int[] 타입인 clearGold 초기화하는 부분 ( 길이 3 )
        /// </summary>
        public void InitClearGold(int easy, int normal, int hard)
        {
            clearGold[0] = easy;
            clearGold[1] = normal;
            clearGold[2] = hard;
        }

        /// <summary>
        /// int[] 타입인 clearExp 초기화하는 부분 ( 길이 3 )
        /// </summary>
        public void InitClearExp(int easy, int normal, int hard)
        {
            clearExp[0] = easy;
            clearExp[1] = normal;
            clearExp[2] = hard;
        }


        protected Player player;

        protected string name;
        public string Name { get => name; }

        protected int level;
        public int Level { get => level; }

        protected int[] recommendDefence; // 권장 방어력
        public int[] RecommendDefence { get => recommendDefence; }


        protected int[] clearGold; // 클리어시 보상
        public int[] ClearGold { get => clearGold; }

        protected int[] clearExp; // 클리어시 경험치
        public int[] ClearExp { get => clearExp; }

        protected KeyValuePair<int, int>[] amountDamage; // DIctionary보단 정해져있는 공간이고 읽기만 할거라면 keyValuePair사용한다.
        public KeyValuePair<int, int>[] AmountDamage { get => amountDamage; }
    }
}
