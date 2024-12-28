using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRose.Model
{
    public record Item
    {
        public string Name { get; }

        public Item(string name)
        {
            Name = name;
        }
    }
}
