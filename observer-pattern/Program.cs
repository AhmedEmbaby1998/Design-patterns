using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace observer_pattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
                Console.WriteLine(workbook(5,3,new int[]{4,2,6,1,10}));
        }

        static int workbook(int n, int k, int[] arr)
        {
            var cnt = 0;
            var page = 1;
            for (var j = 0; j < arr.Length; j++)
            {
                var remain = arr[j];
                var end = 0;
                while (remain>0)
                {
                    var start =end + 1;
                    end = remain < k ? start + remain-1 : start + k-1;
                    if (page >= start && page <= end)
                        cnt++;
                    remain = remain < k ? 0 : remain - k;
                    page++;
                }
            }
            return cnt;
        }

        static string isValid(string s)
        {
            var freq = new int[26];//the frequency off the chars
            foreach (var c in s)
            {
                freq[c - 'a']++;
            }
            var map=new Dictionary<int,int>();
            for (int i = 0; i < freq.Length; i++)if(freq[i]!=0)
            {
                if (!map.ContainsKey(freq[i]))
                {
                    map.Add(freq[i], 1);
                }
                else map[freq[i]]++;
            }
            if (map.Count > 2) return "NO";
            int[] marrk = map.Keys.ToArray();
            int[] marrv = map.Values.ToArray();
            return map.Count==1||Math.Abs(marrk[0] - marrk[1]) == 1 && marrv[0]==1||marrv[1]==1 ? 
                "YES" : "NO";
        }
        static int stringConstruction(string s)
        {
            var cnt = 0;
            var set=new HashSet<char>(s);
            foreach (var c in s)
            {
                if (!set.Contains(c))
                {
                    cnt++;
                    set.Add(c);
                }
            }

            return cnt;
        }
    }
}