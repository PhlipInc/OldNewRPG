using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace DataAccess
{
    public class FighterManagerJSON : IDataManager
    {
        //private Random random;
        public const string FighterPathStart = "rpg//OldNewRPG//";
        public const string FighterPathEnd = "-Fighter.json";
        public FighterManagerJSON(Random random)
        {
            //this.random = random;
        }
        public Fighter GetFighter(string id)
        {
            Fighter fighter;
            if(!File.Exists(FighterPathStart + id + FighterPathEnd))
            {
                fighter = Fighter.NewFighterInstance();
                SetFighter(id, fighter);
            }
            else
            {
                using (StreamReader sr =  new  StreamReader(FighterPathStart + id + FighterPathEnd))
                {
                    fighter = JsonSerializer.Deserialize<Fighter>(sr.ReadToEnd());
                }
            }
            return fighter;
        }

        public async void SetFighter(string id, Fighter fighter)
        {
            try
            {
                using (FileStream fs = File.Create(FighterPathStart + id + FighterPathEnd))
                {
                    await JsonSerializer.SerializeAsync(fs, fighter);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}