using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace 拉格朗日插值
{
    class Program
    {
        static Dictionary<string, double> functionvalue = new Dictionary<string, double> { };
        static double result1, result2;
        static string points;
        static string[] point = null;
        //a2,b2,c2保存用户所选的三个输入变量的函数值
        static double a2 = 0, b2 = 0, c2 = 0, a1 = 0, b1 = 0, c1 = 0;
        static double h = 0, i = 0, j = 0, k = 0;
        static void Main(string[] args)
        {
            //将已知函数值输入到字典中
            functionvalue.Add("x0", -0.6);
            functionvalue.Add("x1", -0.2);
            functionvalue.Add("x2", 0.2);
            functionvalue.Add("x3", 0.4);
            functionvalue.Add("y0", 1.6);
            functionvalue.Add("y1", 2.4);
            functionvalue.Add("y2", 1.2);
            functionvalue.Add("y3", 3.2);
            Init();
        }
        /// <summary>
        /// 计算器主程序界面
        /// </summary>
        static void Interface()
        {
            Console.WriteLine("##################################");
            Console.WriteLine("#                                #");
            Console.WriteLine("#                                #");
            Console.WriteLine("#        拉格朗日插值计算        #");
            Console.WriteLine("#                                #");
            Console.WriteLine("#                                #");
            Console.WriteLine("##################################");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("已知的函数值表：");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" Xi  -0.6  -0.2  0.2  0.4");
            Console.WriteLine(" Yi   1.6   2.4  1.2  3.2");
            Console.ResetColor();
            Console.WriteLine("##################################");
        }
        static void Init()
        {
            while (true)
            {   
                Interface();
                Console.WriteLine("请输入1或2选择建立二次差值多项式或三次差值多项式：");
                string userInput = Convert.ToString(Console.ReadLine());
                if (userInput == "1")
                {
                 #region
                        //提示用户输入三个点，保存到point数组中
                        Console.WriteLine("请从x0,x1,x2,x3中任选取三个点，以逗号分隔！");
                        Console.WriteLine("程序会计算 f(0) 的近似值");
                        points = Console.ReadLine();
                        string[] point = points.Split(new char[1] { ',' });
                        //计算a
                        try
                        {
                            a1 = ((functionvalue[point[1]]) * (functionvalue[point[2]])) / (((functionvalue[point[0]]) - (functionvalue[point[1]])) * ((functionvalue[point[0]]) - (functionvalue[point[2]])));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString()); 
                            Environment.Exit(0);
                            throw ex;
                        }
                        //计算b
                        try
                        {
                            b1 = ((functionvalue[point[0]]) * (functionvalue[point[2]])) / (((functionvalue[point[1]]) - (functionvalue[point[0]])) * ((functionvalue[point[1]]) - (functionvalue[point[2]])));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString());
                            Environment.Exit(0);
                            throw ex;
                        }
                        //计算c
                        try
                        {
                            c1 = ((functionvalue[point[0]]) * (functionvalue[point[1]])) / (((functionvalue[point[2]]) - (functionvalue[point[0]])) * ((functionvalue[point[2]]) - (functionvalue[point[1]])));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString()); 
                            Environment.Exit(0);
                            throw ex;
                        }
                    if (functionvalue[point[0]].Equals(-0.6))
                        {
                            //第一个输入的数为x0
                            a2 = functionvalue["y0"];
                        }
                        else if (functionvalue[point[0]].Equals(-0.2))
                        {
                            //第一个输入的数为x1
                            a2 = functionvalue["y1"];
                        }
                        else if (functionvalue[point[0]].Equals(0.2))
                        {
                            //第一个输入的数为x2
                            a2 = functionvalue["y2"];
                        }
                        else if (functionvalue[point[0]].Equals(0.4))
                        {
                            //第一个输入的数为x3
                            a2 = functionvalue["y3"];
                        }

                        if (functionvalue[point[1]].Equals(-0.6))
                        {
                            //第二个输入的数为x0
                            b2 = functionvalue["y0"];
                        }
                        else if (functionvalue[point[1]].Equals(-0.2))
                        {
                            //第二个输入的数为x1
                            b2 = functionvalue["y1"];
                        }
                        else if (functionvalue[point[1]].Equals(0.2))
                        {
                            //第二个输入的数为x2
                            b2 = functionvalue["y2"];
                        }
                        else if (functionvalue[point[1]].Equals(0.4))
                        {
                            //第二个输入的数为x3
                            b2 = functionvalue["y3"];
                        }

                        if (functionvalue[point[2]].Equals(-0.6))
                        {
                            //第三个输入的数为x0
                            c2 = functionvalue["y0"];
                        }
                        else if (functionvalue[point[2]].Equals(-0.2))
                        {
                            //第三个输入的数为x1
                            c2 = functionvalue["y1"];
                        }
                        else if (functionvalue[point[2]].Equals(0.2))
                        {
                            //第三个输入的数为x2
                            c2 = functionvalue["y2"];
                        }
                        else if (functionvalue[point[2]].Equals(0.4))
                        {
                            //第三个输入的数为x3
                            c2 = functionvalue["y3"];
                        }
                        //最终结果result
                        result1 = a1 * a2 + b1 * b2 + c1 * c2;
                        Console.WriteLine(result1);
                        Console.WriteLine("按任意键清除本次计算结果");
                        Console.ReadKey();
                        Console.Clear();
                    }
#endregion
                else if (userInput == "2")
                {
                    #region
                    h = -(functionvalue["x1"]) * (functionvalue["x2"]) * (functionvalue["x3"]) / (((functionvalue["x0"]) - (functionvalue["x1"])) * ((functionvalue["x0"]) - (functionvalue["x2"])) * ((functionvalue["x0"]) - (functionvalue["x3"])));
                    i = -(functionvalue["x0"]) * (functionvalue["x2"]) * (functionvalue["x3"]) / (((functionvalue["x1"]) - (functionvalue["x0"])) * ((functionvalue["x1"]) - (functionvalue["x2"])) * ((functionvalue["x1"]) - (functionvalue["x3"])));
                    j = -(functionvalue["x1"]) * (functionvalue["x0"]) * (functionvalue["x3"]) / (((functionvalue["x2"]) - (functionvalue["x0"])) * ((functionvalue["x2"]) - (functionvalue["x1"])) * ((functionvalue["x2"]) - (functionvalue["x3"])));
                    k = -(functionvalue["x1"]) * (functionvalue["x2"]) * (functionvalue["x0"]) / (((functionvalue["x3"]) - (functionvalue["x0"])) * ((functionvalue["x3"]) - (functionvalue["x1"])) * ((functionvalue["x3"]) - (functionvalue["x2"])));
                    result2 = h * functionvalue["y0"] + i * functionvalue["y1"] + j * functionvalue["y2"] + k * functionvalue["y3"];
                    Console.WriteLine(result2);
                    Console.WriteLine("按任意键清除本次计算结果");
                    Console.ReadKey();
                    Console.Clear();
                    #endregion
                }
                else
                {
                    Console.WriteLine("您输入的数值不正确，请重新输入");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
    }