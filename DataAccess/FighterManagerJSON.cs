using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FighterManagerJSON
    {
        private Random random = new Random();
        JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };
        public const string FighterPathStart = "rpg/OldNewRPG/";
        public const string FighterPathEnd = "-Fighter.json";
        public FighterManagerJSON(Random random)
        {
            //this.random = random;
        }

        public async Task<Fighter> GetFighter(string id, Fighter fighter)
        {
            if(!File.Exists(FighterPathStart + id + FighterPathEnd))
            {
                fighter = Fighter.NewFighterInstance();
                await SetFighter(id, fighter);
            }
            else
            {
                using (FileStream fs =  File.OpenRead(FighterPathStart + id + FighterPathEnd))
                {
                    fighter = await JsonSerializer.DeserializeAsync<Fighter>(fs);
                }
            }
            return fighter;
        }
        public async Task SetFighter(string id, Fighter fighter)
        {
            try
            {
                using (FileStream fs = File.Create(FighterPathStart + id + FighterPathEnd))
                {
                    await JsonSerializer.SerializeAsync(fs, fighter, jso);
                    fs.Dispose();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}