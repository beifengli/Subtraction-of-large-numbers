using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace string0813
{
   public class subAB
    {
        static string strIn = "";
        static string[] str = new string[3];
        //            str[0] = "57569546235692356235625677237086235";
        //            str[1] = "2678906787620876280672087628907620867289067289762076";
        //            long result = Convert.ToInt64(str[0]) - Convert.ToInt64(str[1]);
        static Queue<string> st1 = new Queue<string>();
        static Queue<string> st2 = new Queue<string>();
        static Queue<int> stIn = new Queue<int>();

        static string reString;
        static Queue<string> restring = new Queue<string>();

        static string right = "-2678906787620876223102541393215264631663390052675841";
        static public bool revert;

        static public string getRestring()
        {
            return reString;
        }
        static public void setSt1(string str1)
        {
            str[0] = str1;
        }

        static public void setSt2(string str2)
        {
            str[1] = str2;
        }
        static public void DataInit()
        {

            str[2] = "2678906787620876223102541393215264631663390052675841";
            //int[] re = new int[2];

            str[0] = "";
            str[1] = "";
          //  reString = "";
        }
        //只有数字
        public static bool IsOnlyNumber(string value)
        {
            Regex r = new Regex(@"^[0-9]+$");
            return r.Match(value).Success;
        }

        static public bool DataInput()
        {
            strIn = Console.ReadLine();
            str = strIn.Split('-');

            if ("" == str[0] || "" == str[1]||false == IsOnlyNumber(str[0])||false == IsOnlyNumber(str[1]))
            {
                Console.WriteLine("输入有误");
                return false;
            }

            return true;
            //#region 输出A B
            //foreach (string var in str)
            //{
            //    Console.WriteLine(var);
            //}
            //#endregion
        }

        static public void DataTide()
        {
            if(str[0].Length < str[1].Length)
            {
                string strT = str[0];
                str[0] = str[1];
                str[1] = strT;
                revert = true;
            }
            
            int index1 = str[0].Length / 18;
            int index2 = str[0].Length % 18;

            int index3 = str[1].Length / 18;
            int index4 = str[1].Length % 18;

            if (0 == index1)
            {
                st1.Enqueue(str[0]);
            }
            else
            {
                for (int i = 1; i <= index1; i++)
                {
                    //右边进行切割
                    st1.Enqueue(str[0].Substring(str[0].Length  - i * 18, 18));
                }
                st1.Enqueue(str[0].Substring(0, index2));
            }

            if (0 == index3)
            {
                st2.Enqueue(str[1]);
            }
            else
            {
                for (int i = 1; i <= index3; i++)
                {
                    //右边进行切割
                    st2.Enqueue(str[1].Substring(str[1].Length - i * 18, 18));
                }
                st2.Enqueue(str[1].Substring(0, index4));
            }
           // #region 输出
            //for (int i = 0; i <= index1; i++)
            //{
            //    string str = (string)st1.Pop();
            //    Console.WriteLine(str);
            //}
            //for (int i = 0; i <= index3; i++)
            //{
            //    string str = (string)st2.Pop();
            //    Console.WriteLine(str);
            //}
            //#endregion
        }
        static public void DataSub()
        {
            long number1; 
            long number2;
            long reNum;

            int length = (st1.Count <= st2.Count) ? st1.Count : st2.Count;
            for(int i = 0;i<length;i++)
            {
                number1 = long.Parse((string)st1.Dequeue()) ;
                number2 = long.Parse((string)st2.Dequeue());
                reNum = number1 - number2;
                if(reNum>=0)
                {
                    stIn.Enqueue(1);
                    restring.Enqueue(reNum.ToString());
                }
                else
                {
                    //借位
                    if (st1.Count >=0)
                    {
                        //借位
                        number1 += 1000000000000000000L;
                        long top = long.Parse((string)st1.Dequeue());
                        top = top - 1;
                        if( 0 != top )
                            st1.Enqueue(top.ToString());

                        //重新计算
                        reNum = number1 - number2;
                        stIn.Enqueue(0);
                        restring.Enqueue(reNum.ToString());
                    }
                }

            }
        }
         
        static public void ShowResult()
        {
            string str1 = "";
            while(restring.Count>0)
            {
                str1 = (string)restring.Dequeue() + str1;
            }
            while(st1.Count>0)
            {
                str1 = (string)st1.Dequeue() + str1;
            }
            if(true == revert)
            {
                str1 = "-" + str1;
            }
            
            reString = str1;
            Console.WriteLine(strIn +"="+str1);

            st1.Clear();
            st2.Clear();
            stIn.Clear();
            restring.Clear();
            revert = false;
        }

       static public void solve()
        {
            DataTide();
            DataSub();
            ShowResult();
        }
        static void Main(string[] args)
        {
            DataInit();

            while (true)
            {
                if (DataInput())
                {
                    solve();                }

            }

            Console.ReadKey();
        }
    }
}
