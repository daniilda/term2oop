using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Instrumentation;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Documents;
using _2Term_OOP_Lab4.Annotations;

namespace _2Term_OOP_Lab4
{

    /// <summary>
    /// The class responsible for reading and recording data from files
    /// </summary>
    public class FilesWork
    {
        /// <summary>
        /// The func gets path of file location, then read and returns class[] of charts
        /// </summary>
        /// <param name="path">location of txt file</param>
        /// <param name="filetype"></param>
        /// <returns>list of numbers in file</returns>
        public static Charts[] GetChartsFromFile(string path, FileType filetype)
        {
            switch (filetype)
            {
                case FileType.Txt:
                {
                    if (!File.Exists(path)) return null;
                    var rowdata = File.ReadAllLines(path);
                    var charts = new Charts[rowdata.Length];
                    for(var i=0;i<rowdata.Length;i++)
                    {
                        charts[i] = new Charts();
                    }
                    if (rowdata.Length == 0) return null;
                    int k = 0;
                    foreach (var t in rowdata)
                    {
                        var elements = t.Split(' ');
                        for (var i = 0; i < 4; i++)
                        {
                            bool isItInt = int.TryParse(elements[i], out int outN);
                            if (!isItInt) return null;
                            switch (i)
                            {
                                case 0:
                                    charts[k].RealValue = Convert.ToDouble(outN);
                                    continue;
                                case 1:
                                {
                                    charts[k].RColor = outN;
                                    continue;
                                }
                                case 2:
                                {
                                    charts[k].GColor = outN;
                                    continue;
                                }
                                case 3:
                                {
                                    charts[k].BColor = outN;
                                    break;
                                }
                            }
                        }

                        k++;
                    }

                    double chartSum = 0;
                    for (int i = 0; i < charts.Length; i++)
                    {
                        chartSum += charts[i].RealValue;
                    }

                    for (int i = 0; i < charts.Length; i++)
                    {
                        charts[i].Value = (charts[i].RealValue / chartSum) * 100;
                    }
                    
                    return charts;
                }
                case FileType.Sql:
                    break;
            }
            return null;
        }

        /// <summary>
        /// The func gets path of file location and class[] of charts then write them into the file
        /// </summary>
        /// <param name="path">location of txt file</param>
        /// <param name="charts">class[] which containing charts params</param>
        public static void WriteChartsInFile(string path, Charts[] charts)
        {
            if (!File.Exists(path)) File.Create(path);
            var input = new string[charts.Length];
            for (var i = 0; i < charts.Length; i++)
            {
                input[i] = $"{charts[i].RealValue} {charts[i].RColor} {charts[i].GColor} {charts[i].BColor}";
            }
            File.WriteAllLines(path,input);
        }

    }
}