using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_3
{
    internal class LogsWriter
    {
        public async Task Write()
        {
            Logger logger = new();
            for (int i = 0; i<= 50; i++)
            {
               await logger.DoLog($"This is a {i} log");
            }
        }
    }
}
