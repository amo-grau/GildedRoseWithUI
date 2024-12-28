using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.EndToEnd
{
    public interface ApplicationDriver
    {
        public void AddItem(string itemName);
        public void showIsAdded(string itemName);
        public void Close();
    }
}
