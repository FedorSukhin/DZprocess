using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZprocess.Models
{
    internal class ProcessRead
    {
        List<ProcessItem> processesList;
        public List<ProcessItem> getCurentProcesses()
        {
            processesList = new List<ProcessItem>();
            Process[]  processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                //string startTime, lifeTime;
                //try
                //{
                //    startTime = p.StartTime.ToString();
                //}
                //catch
                //{
                //    startTime = "unavailable";
                //}
                //try
                //{
                //    lifeTime = (DateTime.Now - p.StartTime).TotalSeconds.ToString();
                //}
                //catch
                //{
                //    lifeTime = "unavailable";
                //}
                processesList.Add(new ProcessItem(p.Id, p.ProcessName,p.BasePriority));
            }
            return processesList;
        }
       public ProcessItem getProcessByName(string name) 
        {            
            return processesList.Single(s=>s.GetName(name) ==name);
        }
        public ProcessItem getProcessById(int id)
        {            
            return processesList.Single(s => s.GetPid(id) == id);
        }
    }
}
