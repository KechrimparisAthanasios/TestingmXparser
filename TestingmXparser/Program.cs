using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace TestingmXparser
{
    class Program
    {
        static void FormulaGenerator()
        {
            char[] chars = new char[] { '+', '-', '*', '/', '^' };
            char[] letters = new char[] { 'x', 'y', 'z' };
            string generatedFormula = "";
            string generateFormulaWithLetters = "";
            StringBuilder build = new StringBuilder();
            Random r;
            string result = "";
            string resultWithLetter = "";
            for (int i = 0; i < 10; i++)
            {
                r = new Random();

                generatedFormula = r.Next(1, 100).ToString() + chars[r.Next(chars.Length)]+ "(" + r.Next(1, 100).ToString() + chars[r.Next(chars.Length)] + r.Next(1, 100).ToString() + ")" + chars[r.Next(chars.Length)] + r.Next(1, 100).ToString() + chars[r.Next(chars.Length)] + r.Next(1, 100).ToString();
                generateFormulaWithLetters =  r.Next(1, 100).ToString() + chars[r.Next(chars.Length)]  + letters[r.Next(letters.Length)] + chars[r.Next(chars.Length)]  + "(" + r.Next(1, 100).ToString() + chars[r.Next(chars.Length)] + r.Next(1, 100).ToString() + ")" + chars[r.Next(chars.Length)] + r.Next(1, 100).ToString() + chars[r.Next(chars.Length)] + r.Next(1, 100).ToString();
                try
                {
                    org.mariuszgromada.math.mxparser.Expression formula = new org.mariuszgromada.math.mxparser.Expression(generatedFormula);
                    org.mariuszgromada.math.mxparser.Expression formulaWithLetters = new org.mariuszgromada.math.mxparser.Expression(generateFormulaWithLetters);
                    result = formula.calculate().ToString();
                    resultWithLetter = formulaWithLetters.calculate().ToString();


                    //if (!File.Exists(path))
                    //{
                    //    File.Create(path).Dispose();
                    //    using (TextWriter tw = new StreamWriter(path))
                    //    {
                    //        tw.WriteLine("The very first line!");
                    //        tw.Close();
                    //    }

                    //}

                    //else if (File.Exists(path))
                    //{
                        FileStream fs = new FileStream("Results.txt", FileMode.Append);
                        StreamWriter sw = new StreamWriter(fs);

                            sw.WriteLine("Number " + i.ToString());
                            sw.WriteLine("\n" + "Formula : " + generatedFormula);
                            sw.WriteLine("Result : " + result + "\n");
                            
                            sw.WriteLine();
                        sw.Close();
                        fs.Close();
                    //}

                    Console.WriteLine("Number " + i.ToString() + "\n" + "Formula : " + generatedFormula + "\n" + "Result : " + result + "\n" + "Condition " + true.ToString());
                    Console.WriteLine("Number " + i.ToString() + "\n" + "Formula : " + generateFormulaWithLetters + "\n" + "Result : " + resultWithLetter + "\n"  + "Condition " + true.ToString());
                }
                catch (Exception e)
                {
                    generateFormulaWithLetters = e.ToString() + "false";
                }

                Thread.Sleep(1000);
            }
            
        }
        static void Main(string[] args)
        {


            Thread generate = new Thread(new ThreadStart(FormulaGenerator));
            generate.Start();
            generate.Join();

            //string p = "10^2";
            //new
            //double u = 0.123;
            //CultureInfo danishCulture = new CultureInfo("da-DK");
            //double lp = double.Parse(u.ToString());
            //Console.WriteLine(lp.ToString(danishCulture));


            //CultureInfo kli = CultureInfo.InvariantCulture;
            //string kolj = lp.ToString(kli);
            //Console.WriteLine(kolj);
            //org.mariuszgromada.math.mxparser.Expression formula = new org.mariuszgromada.math.mxparser.Expression(kolj + p);
            //object result = formula.calculate().ToString();
            //Console.WriteLine(result);
            //Console.Read();
        }
    }
}
