using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = Solution.LengthOfLongestSubstring("dvdf");
            var s = Solution.convert("LEETCODEISHIRING",4);
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {

        /// <summary>
        /// 寻找最长子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            HashSet<char> set = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n)
            {
                // try to extend the range [i, j]
                if (!set.Contains(s.ToCharArray()[j]))
                {
                    set.Add(s.ToCharArray()[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s.ToCharArray()[i++]);
                }
            }
            return ans;

        }


        /// <summary>
        /// Z字形变换
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static string convert(String s, int numRows)
        {

            if (numRows == 1) return s;
            //行数
            List<StringBuilder> rows = new List<StringBuilder>();
            for (int i = 0; i < Math.Min(numRows, s.Length); i++)
                rows.Add(new StringBuilder());

            int curRow = 0;
            //往下一行插值
            bool goingDown = false;

            foreach (char c in s.ToCharArray())
            {
                rows[curRow].Append(c);
                if (curRow == 0 || curRow == numRows - 1)//第一行直接向下插值，最后一行要向右边的行插值
                {
                    goingDown = !goingDown;
                }
                curRow += goingDown ? 1 : -1;
            }

            StringBuilder ret = new StringBuilder();
            foreach (StringBuilder row in rows)
            {
                ret.Append(row);
            }  
            return ret.ToString();
        }
    }
}
