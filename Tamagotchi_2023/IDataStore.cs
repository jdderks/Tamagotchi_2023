using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_2023
{
    interface IDataStore<T>
    {
        //CRUD
        bool CreateItem(T item);
        T ReadItem();
        bool UpdateItem(T item);
        bool DeleteItem(T item);
    }
}
