﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
//Sample 01: Required Namespace
using System.Threading;


namespace TaskParallelExamples
{
    class TaskProgram1
    {
      
       
            private static void TaskCallBack(Object ThreadNumber)
            {
                string ThreadName = "Thread " + ThreadNumber.ToString();
                for (int i = 1; i < 10; i++)
                {
                    Console.WriteLine(ThreadName + ": " + i.ToString());
                }
                Console.WriteLine(ThreadName + "Finished...");
            }

            static void Main(string[] args)
            {
                for (int task = 1; task < 26; task++)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(TaskCallBack), task);
                }
                Thread.Sleep(10000);
            }
        }
    }


