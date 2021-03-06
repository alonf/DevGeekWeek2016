﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static async Task<int> Foo()
        {
            int result = await await Task.Factory.StartNew(async delegate
            {
                await Task.Delay(1000);
                return 42;
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
            return result;
        }

        static async Task<int> Bar()
        {
            int result = await Task.Factory.StartNew(async delegate
            {
                await Task.Delay(1000);
                return 42;
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default).Unwrap();
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Foo().Result);
            Console.WriteLine(Bar().Result);
        }
    }
}
