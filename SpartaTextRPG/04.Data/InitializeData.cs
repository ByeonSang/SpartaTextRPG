using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._04.Data
{
    internal class InitializeData
    {
        public InitializeData(Player _player) 
        {
            player = _player;
            // 파일을 생성할 위치 설정
            path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.IndexOf("\\bin"));
            path += "\\config.json";
            CreateFile();
        }

        private void CreateFile()
        {
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                    Console.WriteLine("세이브 파일 생성");
                }
            }
        }

        public void WriteJson()
        {
            // 파일이 존재하면 쓰기
            if (File.Exists(path))
            {
                InputPlayer();
            }
        }

        private void InputPlayer()
        {
            var json = new JObject();
            json.Add("NAME", player.Name);
            json.Add("LEVEL", player.Level);
            json.Add("HEALTH", player.Health);
            json.Add("DEFENCE", player.Defence);
            json.Add("ATTACK", player.Attack);
            json.Add("GOLD", player.Gold);
            json.Add("JOBTYPE", (int)player.Type);
            json.Add("EXP", (int)player.Exp);

            JObject playerInfo = new JObject();
            playerInfo.Add("PLAYER", json);
            File.WriteAllText(path, playerInfo.ToString());
        }

        private string path;
        public string Path { get => path; }

        private Player player;

    }
}
