﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;


namespace TaskParallelExamples
{
    class TaskCancelation
        { 
        

            static void Main()
            {
                var tokenSource2 = new CancellationTokenSource();
                CancellationToken ct = tokenSource2.Token;

                var task = Task.Factory.StartNew(() =>
                {
                    ct.ThrowIfCancellationRequested();
                    bool moreToDo = true;
                    while (moreToDo)
                    {
                        if (ct.IsCancellationRequested)
                        {
                            ct.ThrowIfCancellationRequested();
                        }
                    }
                }, tokenSource2.Token);
                tokenSource2.Cancel();
                try
                {
                    task.Wait();
                }
                catch (AggregateException e)
                {
                    foreach (var v in e.InnerExceptions)
                        Console.WriteLine(e.Message + " " + v.Message);
                }
                finally
                {
                    tokenSource2.Dispose();
                }
            Console.Read();
            }
        }
    }



