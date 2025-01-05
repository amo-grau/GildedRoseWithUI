using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.EndToEnd
{
    public interface ApplicationDriver
    {
        public void AddItem(Item itemName);
        public void showIsListed(Item itemName);
        public void Close();
    }
}
