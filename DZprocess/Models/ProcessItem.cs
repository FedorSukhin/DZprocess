using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZprocess.Models
{
    public class ProcessItem
    {
        int PID { get; set; }
        string Name { get; set; }
        int Priority { get; set; }
        string StartTime { get; set; }
        string LifeTime { get; set; }
        public ProcessItem(int pid, string name, int priority, string startTime, string lifeTime)
        {
            PID = pid;
            Name = name;
            Priority = priority;
            StartTime=startTime;
            LifeTime = lifeTime;
            

        }
        public ProcessItem(int pid, string name)
        {
            PID = pid;
            Name = name;
        }
        public ProcessItem(int pid, string name, int priority)
        {
            PID = pid;
            Name = name;
            Priority = priority;
        }
        public string GetName(string name)
        {
            return Name;
        }
        public int GetPid(int name)
        {
            return PID;
        }
        public string ProcessInfo()
        {
            return $"PID: {PID}\nName: {Name}\nBasePriority: {Priority}\nStart itme: {StartTime}\nLife time: {LifeTime}";
        }
        public override string ToString()
        {
            return $"{PID} - {Name}";
        }

    }
}
