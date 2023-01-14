// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



public static long getWays(int n, List<long> c)
{
    long[] v = c.ToArray();
    int s = n + 1;
    long[,] table = new long[v.Length + 1, n - 1];


    for (int i = 0; i < v.Length; i++)
    {
        table[i, 0] = 1;
    }
    for (int j = 1; j <= n; j++)
    {
        table[0, j] = 1;
    }
    
        return table[v.Length, n];
        }
    }
        //find total sum of all values in list of coins 
        //long answer = 0;




        //             if(n%coinValue == 0)
        //             {
        //                answer ++; 
        //             }
        //             if(coinValue%n ==0)
        //             {
        //                 answer++;
        //             }

        //             listSum +=coinValue;

        //             if (listSum % n == 0)
        //             {
        //                 answer ++;
        //             }
        //             if(n % listSum ==0)
        //             {
        //                 answer++;
        //             }




    }