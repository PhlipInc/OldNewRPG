using Domain;
using System;

namespace DataAccess
{
    public interface IDataManager
    {
        Fighter GetFighter(string id);
        void SetFighter(string id, Fighter fighter);
    }
}
