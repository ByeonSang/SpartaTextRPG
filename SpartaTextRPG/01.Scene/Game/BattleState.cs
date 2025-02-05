using SpartaTextRPG._03.Dungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._01.Scene.Game
{
    internal class BattleState : State
    {
        public BattleState(StateMachine _stateMachine, Player _player) : base(_stateMachine)
        {
            player = _player;
        }

        public override void Enter(object? Object = null)
        {
            try
            {
                if (Object == null || Object.GetType() != typeof(KeyValuePair<Dungeon, int>))
                {
                    stateMachine.GameInfo.GameExit("현재 BattleState.Enter(object? Object)부분에서 Null값을 받아왔습니다.");
                }

                KeyValuePair<Dungeon, int> pair = (KeyValuePair<Dungeon, int>)Object;
                dungeon = pair.Key;
                idx = pair.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Exit()
        {
            Console.Clear();
        }

        public override void ShowTitle()
        {
            Render.ColorText("[던전 소탕중]\n", ConsoleColor.Green);
            Console.WriteLine("던전 소탕중입니다...");
        }

        public override void Update()
        {
            ShowTitle();

            Thread.Sleep(1000);

            if(!CheckDefence())
                CheckClear();

            while(!ExitDungeon());
            stateMachine.ChangeScene(stateMachine.MainScene);
        }

        bool CheckDefence()
        {
            int dungeonDef = dungeon.RecommendDefence[idx];

            if(player.Defence < dungeonDef)
            {
                int rand = new Random().Next(1, 11);
                
                // 소탕실패
                if(rand < 4)
                {
                    player.TakeDamage(player.Health / 2);

                    // 플레이어가 사망할시 저장되었던 데이터들은 날라가고, 게임종료
                    if (!CheckPlayerDead()) // 사망이 아닐때
                        Render.ColorText("소탕실패!!!\n", ConsoleColor.Red);
                    return true;
                }
            }

            return false;
        }
        void CheckClear()
        {
            // 받는 데미지 계산
            int plusDef = dungeon.RecommendDefence[idx] - player.Defence;
            int minDamage = dungeon.AmountDamage[idx].Key + plusDef;
            int maxDamage = dungeon.AmountDamage[idx].Value + plusDef;

            int damage = new Random().Next(minDamage, maxDamage + 1);

            // 클리어시 받는 골드 보상 계산
            int minPercentage = (int)player.Attack;
            float rand = ((float)new Random().Next(minPercentage, minPercentage * 2 + 1) / 100.0f);
            int baseGold = dungeon.ClearGold[idx];
            int plusGold = (int)(baseGold * rand);

            // 우선 클리어하기 전에 체력확인
            player.TakeDamage(damage);
            CheckPlayerDead();            
            Console.WriteLine($"{damage} 만큼 피해를 입었습니다.\n");


            Render.ColorText("던전 클리어!!!\n", ConsoleColor.Yellow);
            Console.Write("기본 보상 : "); Render.ColorText($"{baseGold} G\n", ConsoleColor.Yellow);
            Console.Write("추가 보상 : "); Render.ColorText($"{plusGold} G\n", ConsoleColor.Yellow);
            player.Gold += baseGold + plusGold;

            //클리어시 받는 경험치량
            int clearExp = dungeon.ClearExp[idx];
            Console.Write("클리어 경험치 : "); Render.ColorText($"{clearExp}\n", ConsoleColor.Yellow);
            player.Exp += clearExp;
            player.CheckLevelUp();
        }

        bool ExitDungeon()
        {
            Console.WriteLine("마을로 돌아가기 [Enter Press]");
            ConsoleKeyInfo info = Console.ReadKey(true);
            if (info.Key == ConsoleKey.Enter)
                return true;

            return false;
        }

        bool CheckPlayerDead()
        {
            if (player.IsDead)
            {
                Render.ColorText("소탕실패!!!\n", ConsoleColor.Red);
                File.Delete(stateMachine.GameInfo.Data.Path);
                stateMachine.GameInfo.GameExit($"HP : {player.Health} _ _ _ 세이브 파일은 삭제됩니다...");
                return true;
            }

            return false;
        }

        private Player player;
        private Dungeon dungeon;
        private int idx; // 인덱스
    }
}
