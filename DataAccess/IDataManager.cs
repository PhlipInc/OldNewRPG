using Domain;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IDataManager
    {
        Fighter GetFighter(string id);
        List<Item> GetItems();
        List<Dungeon> GetDungeons();
        List<Monster> GetMonsters();
        //Dungeon GetRandomDungeon(Fighter fighter);
        void SetFighter(string id, Fighter fighter);
    }
}
