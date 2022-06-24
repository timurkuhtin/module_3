using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_3
{
    internal class Logger
    {
        public DateTime _logTime;
        public string LogType = "Info";
        public string _message;
        public delegate void ForBackup();
        public event ForBackup Checklogs;
        public bool IsActive = true;
        public readonly object _lock = new();
        public async Task DoLog(string msg)
        {            
            _logTime = DateTime.Now;
            _message = msg;
            TextWriter writer = new StreamWriter(@"C:\Users\Timur\Desktop\A-lavel\module\3\module_3\module_3\logs\logs.txt");
            await
            using (writer)
            {
                File.AppendText($"{DateTime.Now} {this._logTime} {this.LogType} {this._message}\n");
            }            
        }
        public void DoBackup()
        {
            int count = System.IO.File.ReadAllLines(@"C:\Users\Timur\Desktop\A-lavel\module\3\module_3\module_3\logs\logs.txt").Length;
            lock (this._lock)
            {
                var time = DateTime.Now.TimeOfDay.Ticks;
                using TextWriter writer = new StreamWriter($@"C:\Users\Timur\Desktop\A-lavel\module\3\module_3\module_3\logs\backups\{time}.txt");
                File.Create($@"C:\Users\Timur\Desktop\A-lavel\module\3\module_3\module_3\logs\backups\{time}.txt");
                File.AppendAllText($"{time}.txt", @"C:\Users\Timur\Desktop\A-lavel\module\3\module_3\module_3\logs\logs.txt");
            }
        }
        public ForBackup Checklog()
        {
            //place for json
            int n = 5;


            ForBackup result = DoBackup;
            int count = System.IO.File.ReadAllLines(@"C:\Users\Timur\Desktop\A-lavel\module\3\module_3\module_3\logs\logs.txt").Length;
            if (count % n == 0)
            {
                this.DoBackup();
            }
            return result;
        }
        public async void DoCheck()
        {            
            while (IsActive)
            {
                await Task.Delay(0);
                Checklogs?.Invoke();                                
            }
        }
    }
}
