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
        Dungeon GetRandomDungeon();
        List<Monster> GetMonsters();
        void SetFighter(string id, Fighter fighter);
    }
}
