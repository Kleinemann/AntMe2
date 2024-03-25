using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntMeLib
{
    public static class GameOptions
    {
        public static int Seed = 12345;

        public static Random Random = Seed > 0 ? new Random(Seed) : new Random();
    }
}
