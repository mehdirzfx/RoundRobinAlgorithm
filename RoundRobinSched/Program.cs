using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*********************************************************************************************************************************
 * الگوریتم زمانبندی راند رابین
 * یک کوانتوم زمانی معمولا بین 10 تا 100 میلی ثانیه است.
 * Author : Mehdi Rezaei Far
 * *******************************************************************************************************************************/

namespace RoundRobinSched
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 i;
            Int32 j;
            Int32 k;
            Int32 q;
            Int32 Sum = 0; // برای اضافه کردن زمان انفجار و زمان انتظار و زمان چرخش استفاده میشود

            Console.Write("Enter Number of Process: ");
            Int32 n = Convert.ToInt32(Console.ReadLine()); // دریافت تعداد فرآیند از کاربر

            Int32[] bt = new Int32[n];  // آرایه زمان انفجار
            Int32[] wt = new Int32[n]; // آرایه زمان انتظار
            Int32[] tat = new Int32[n];// آرایه برای زمان چرخش
            Int32[] a = new Int32[n];  // این متغییر جهت حفظ زمان انفجار قبل از محاسبات استفاده میشود
            
            Console.Write("\n");
            for (i = 0; i < n; i++)
            {
                Console.Write("Enter Burst Time for " + (i + 1) + " : ");
                bt[i] = Convert.ToInt32(Console.ReadLine()); // زمان انفجار از کاربر گرفته میشود
            }
            Console.Write("\n");
            Console.Write("Enter Quantum Time: ");
            q = Convert.ToInt32(Console.ReadLine()); // زمان کوانتوم از کاربر گرفته میشود.
            Console.Write("\n");
            for (i = 0; i < n; i++)
                a[i] = bt[i];
            for (i = 0; i < n; i++)
            {
                wt[i] = 0;
            }
            do
            {
                for (i = 0; i < n; i++)
                {
                    if (bt[i] > q)
                    {
                        bt[i] -= q;
                        for (j = 0; j < n; j++)
                        {
                            if ((j != i) && (bt[j] != 0))
                                wt[j] += q;
                        }
                    }
                    else
                    {
                        for (j = 0; j < n; j++)
                        {
                            if ((j != i) && (bt[j] != 0))
                                wt[j] += bt[i];
                        }
                        bt[i] = 0;
                    }
                }
                Sum = 0;
                for (k = 0; k < n; k++)
                    Sum = Sum + bt[k];
            }
            while (Sum != 0);

            for (i = 0; i < n; i++)
            {
                tat[i] = wt[i] + a[i];
            }
            Console.WriteLine("Process\t\tBurst Time\tWaiting Time\tTurn Arount Time\n");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("  p" + (i + 1) + "\t\t    " + a[i] + "\t\t    " + wt[i] + "\t\t    " + tat[i]);
            }
            Console.Write("\n");

            // (RR) خروجی الگوریتم زمانبندی راند رابین

            Double AvgWt = 0; // میانگین زمان انفجار
            Double AvgTat = 0;// میانگین زمان چرخش
            for (j = 0; j < n; j++)
            {
                AvgWt += wt[j];
            }
            for (j = 0; j < n; j++)
            {
                AvgTat += tat[j];
            }
            Console.WriteLine("Average Waiting Time: " + (AvgWt / n) + "\nAverage Turn Around Time: " + (AvgTat / n));
            Console.ReadLine();
        }
    }
}