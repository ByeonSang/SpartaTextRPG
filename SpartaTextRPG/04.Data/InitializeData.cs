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
            else
            {
                ReadJson();
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

        private void ReadJson()
        {
            try
            {
                // Json 파일 읽기
                using (StreamReader file = File.OpenText(Path))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    int playerType = 0;
                    JObject json = (JObject)JToken.ReadFrom(reader);

                    var playerInfo = json.SelectToken("PLAYER");
                    var cnt = playerInfo.Count();

                    player.Name = (string)playerInfo["NAME"];
                    player.Level = (int)playerInfo["LEVEL"];
                    player.Health = (int)playerInfo["HEALTH"];
                    player.Defence = (int)playerInfo["DEFENCE"];
                    player.Attack = (float)playerInfo["ATTACK"];
                    player.Gold = (int)playerInfo["GOLD"];
                    playerType = (int)playerInfo["JOBTYPE"];
                    player.Exp = (int)playerInfo["EXP"];

                    player.Type = (EntityType)playerType;
                }
            }
            catch (Exception)
            {
                File.Delete(Path);
                CreateFile();
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
