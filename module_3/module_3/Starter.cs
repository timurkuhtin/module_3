using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_3
{
    internal class Starter
    {
        public async Task Go()
        {            
            Logger logger = new();
            LogsWriter logsWriter = new LogsWriter();
            logger.Checklogs += logger.Checklog();
            logger.DoCheck();
            await logsWriter.Write();
            Task.WaitAll(logsWriter.Write(), logsWriter.Write());
            logger.IsActive = false;
        }
    }
}
