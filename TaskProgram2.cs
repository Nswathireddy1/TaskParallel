﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace TaskParallelExamples
{
    class TaskProgram2
    {
    
            static void Main()
            {
                // Provides a set of static  methods for querying objects
                int[] nums = Enumerable.Range(0, 100000).ToArray();
                long total = 0;

                // Use type parameter to make subtotal a long, not an int
                Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
                {
                    subtotal += nums[j];
                    return subtotal;
                },
                    (x) => Interlocked.Add(ref total, x)
                );

                Console.WriteLine("The total is {0}", total);
            Console.Read();

            }
        }
    }



