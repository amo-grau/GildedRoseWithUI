using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRose.Model
{
    public interface UserRequestListener
    {
        public void AddItemToInventory(string item);
    }
}
