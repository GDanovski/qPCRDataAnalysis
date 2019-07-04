using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace qPCRDataAnalysis
{
    class MyFunctions
    {
        /// <summary>
        /// Read the input file
        /// </summary>
        /// <returns>Data set as My Data array</returns>
        public static MyData[] ReadInputDataFile()
        {
            //arrey for the file rows
            string[] content = new string[0];
            //input directory as string
            string dir = System.Reflection.Assembly.GetEntryAssembly().Location;
            dir = dir.Substring(0, dir.LastIndexOf("\\")) + "\\Input";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            dir += "\\qPCRdata.csv";
            //check is the file existing
            if (!File.Exists(dir))
            {
                MessageBox.Show("Input directory is empty!");
                return null;
            }
            //create array that contains the information from the input file
            try
            {
                 content = File.ReadAllLines(dir);
            }
            catch
            {
                MessageBox.Show("Input data file is used by another application!");
                return null;
            }
            //create data set variable
            MyData[] data = new MyData[content.Length];

            //loop the whole input file row by row
            for (int i = 1; i < content.Length; i++)
                try
                {
                    data[i] = new MyData(content[i]);//load the data from the selected row
                }
                catch
                {
                    MessageBox.Show("Error!\n" + content[i]);//return error message
                    return null;//break the void
                }
            //clear
            content = null;

            return data;
        }
        /// <summary>
        /// Removes the repeats by calculating the average value and the StDev.S
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Data set as My Data array</returns>
        public static MyData[] RemoveRepeats(MyData[] data)
        {
            //prepare the variables required for sorting
            Dictionary<string, MyData> dict = new Dictionary<string, MyData>();
            List<MyData> newData = new List<MyData>();
            //create the dictionary - kay[TimePoint_Condition_Gene] value[MyData]
            foreach (var val in data)
                if (val != null)
                {
                    string key = val.TimePoint + "_" + val.Condition + "_" + val.Gene;

                    if (dict.ContainsKey(key))
                    {
                        dict[key].Series.Add(val.Value);
                        dict[key].Experiments.Add(val.Experiment.ToString());
                    }
                    else
                    {
                        val.Series = new List<double>();
                        val.Series.Add(val.Value);

                        val.Experiments = new List<string>();
                        val.Experiments.Add(val.Experiment.ToString());

                        dict.Add(key, val);
                    }
                }
            //create new data set
            foreach (var kvp in dict)
            {
                MyData current = kvp.Value;
                current.Value = current.Series.Average();//calculates the average value
                current.StDev = GetStDevS(current.Series, current.Value);//calculates the StDev.S
                //Clear the array
                current.Series.Clear();
                current.Series = null;
                //add to the new set
                newData.Add(current);
            }
            //clear
            dict.Clear();
            dict = null;
            data = null;
            //return the set as array
            return newData.ToArray();
        }
        /// <summary>
        /// Calculates the standart deviation
        /// </summary>
        /// <param name="vals"></param>
        /// <param name="avg"></param>
        /// <returns></returns>
        private static double GetStDevS(List<double> vals, double avg)
        {
            double result = 0;

            foreach (var val in vals)
                result += Math.Pow(val - avg, 2);

            result = Math.Sqrt(result / (vals.Count - 1));

            return result;
        }
        /// <summary>
        /// Calculates the data tables
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refGene"></param>
        /// <param name="refTime"></param>
        /// <param name="refCondition"></param>
        /// <param name="gene"></param>
        /// <param name="time"></param>
        /// <param name="condition"></param>
        /// <param name="switchXY"></param>
        /// <returns></returns>
        public static DataTable[] ProcessTheData(
            MyData[] data,string refGene, string refTime , string refCondition, string gene , string time, string condition, bool switchXY)
        {
            //prepare variables
            Dictionary<string, double> refSet = new Dictionary<string, double>();
            List<MyData> valSet = new List<MyData>();

            //loop the set in order to find the refference genes
            foreach (var val in data)
            {
                if (val.TimePoint == refTime &&
                    val.Condition == refCondition &&
                    ((refGene != "" && refGene == val.Gene) || refGene == "") &&
                    !refSet.ContainsKey(val.Gene))
                {
                    refSet.Add(val.Gene, val.Value);
                }                
            }
            //loop the data and sort
            foreach (var val in data)
            {
                if (gene != "" && val.Gene == gene)
                    valSet.Add(val);
                if (time != "" && val.TimePoint == time)
                    valSet.Add(val);
                if (condition != "" && val.Condition == condition)
                    valSet.Add(val);
            }
            //calculate the value based on the following formula: value = 2^-(valN-valRef)
            valSet = calculateValues(valSet, refSet);
            //Load the data to data tables
            if (switchXY)
            {
                if (time != "")
                    return DataTableForTime(valSet);
                else if (condition != "")
                    return DataTableForCondition(valSet);
                else if (gene != "")
                    return DataTableForGene(valSet);
            }
            else
            {
                if (time != "")
                    return DataTableForTime1(valSet);
                else if (condition != "")
                    return DataTableForCondition1(valSet);
                else if (gene != "")
                    return DataTableForGene1(valSet);
            }

            return null;
        }
        /// <summary>
        /// Calculate the value based on the following formula: value = 2^-(valN-valRef)
        /// </summary>
        /// <param name="valSet"></param>
        /// <param name="refSet"></param>
        /// <returns></returns>
        private static List<MyData> calculateValues(List<MyData> valSet, Dictionary<string, double> refSet)
        {
            List<MyData> result = new List<MyData>();

            foreach (var val in valSet)
                if (refSet.ContainsKey(val.Gene))
                {
                    double value = Math.Pow((double)2, -(val.Value - refSet[val.Gene]));
                    MyData newVal = val.Duplicate();
                    newVal.Value = value;
                    result.Add(newVal);
                }

            return result;
        }
        /// <summary>
        /// Data table: Condition/Gene
        /// </summary>
        /// <param name="valSet"></param>
        /// <returns></returns>
        private static DataTable[] DataTableForTime(List<MyData> valSet)
        {
            //Create variables
            List<string> genes = new List<string>();
            List<string> conditions = new List<string>();
            //extract all XY values
            foreach (var val in valSet)
            {
                if (!genes.Contains(val.Gene)) genes.Add(val.Gene);
                if (!conditions.Contains(val.Condition)) conditions.Add(val.Condition);
            }
            //create data tables
            DataTable dt = new DataTable();
            DataTable dtStDev = new DataTable();
            //add the row titles column
            dt.Columns.Add("Condition\\Gene");
            dtStDev.Columns.Add("Condition\\Gene");
            //add all coulmn titles
            foreach (string str in genes)
            {
                dt.Columns.Add(str);
                dtStDev.Columns.Add(str);
            }
            //add the rows
            foreach (string str in conditions)
            {
                var row = dt.NewRow();
                var rowStDev = dtStDev.NewRow();
                //set the row title
                row["Condition\\Gene"] = str;
                rowStDev["Condition\\Gene"] = str;
                //store the value and the StDev to the table
                foreach (var val in valSet)
                    if (val.Condition == str)
                    {
                        row[val.Gene] = val.Value;
                        rowStDev[val.Gene] = val.StDev.ToString() + " ("+ string.Join(",", val.Experiments) +")";
                    }
                //add the rows to the tables
                dt.Rows.Add(row);
                dtStDev.Rows.Add(rowStDev);
            }
            //clear
            genes.Clear();
            conditions.Clear();
            genes = null;
            conditions = null;
            //Return value
            return new DataTable[] { dt, dtStDev };
        }
        /// <summary>
        /// Data table: Time/Gene
        /// </summary>
        /// <param name="valSet"></param>
        /// <returns></returns>
        private static DataTable[] DataTableForCondition(List<MyData> valSet)
        {
            //Create variables
            List<string> genes = new List<string>();
            List<string> time = new List<string>();
            //extract all XY values
            foreach (var val in valSet)
            {
                if (!genes.Contains(val.Gene)) genes.Add(val.Gene);
                if (!time.Contains(val.TimePoint)) time.Add(val.TimePoint);
            }
            //create data tables
            DataTable dt = new DataTable();
            DataTable dtStDev = new DataTable();
            //add the row titles column
            dt.Columns.Add("Time\\Gene");
            dtStDev.Columns.Add("Time\\Gene");
            //add all coulmn titles
            foreach (string str in genes)
            {
                dt.Columns.Add(str);
                dtStDev.Columns.Add(str);
            }
            //add the rows
            foreach (string str in time)
            {
                var row = dt.NewRow();
                var rowStDev = dtStDev.NewRow();
                //set the row title
                row["Time\\Gene"] = str;
                rowStDev["Time\\Gene"] = str;
                //store the value and the StDev to the table
                foreach (var val in valSet)
                    if (val.TimePoint == str)
                    {
                        row[val.Gene] = val.Value;
                        rowStDev[val.Gene] = val.StDev.ToString() + " (" + string.Join(",", val.Experiments) + ")";
                    }
                //add the rows to the tables
                dt.Rows.Add(row);
                dtStDev.Rows.Add(rowStDev);
            }
            //clear
            genes.Clear();
            time.Clear();
            genes = null;
            time = null;
            //Return value
            return new DataTable[] { dt, dtStDev };
        }
        /// <summary>
        /// Data table: Time/Condition
        /// </summary>
        /// <param name="valSet"></param>
        /// <returns></returns>
        private static DataTable[] DataTableForGene(List<MyData> valSet)
        {
            //Create variables
            List<string> Condition = new List<string>();
            List<string> time = new List<string>();
            //extract all XY values
            foreach (var val in valSet)
            {
                if (!Condition.Contains(val.Condition)) Condition.Add(val.Condition);
                if (!time.Contains(val.TimePoint)) time.Add(val.TimePoint);
            }
            //create data tables
            DataTable dt = new DataTable();
            DataTable dtStDev = new DataTable();
            //add the row titles column
            dt.Columns.Add("Time\\Condition");
            dtStDev.Columns.Add("Time\\Condition");
            //add all coulmn titles
            foreach (string str in Condition)
            {
                dt.Columns.Add(str);
                dtStDev.Columns.Add(str);
            }
            //add the rows
            foreach (string str in time)
            {
                var row = dt.NewRow();
                var rowStDev = dtStDev.NewRow();
                //set the row title
                row["Time\\Condition"] = str;
                rowStDev["Time\\Condition"] = str;
                //store the value and the StDev to the table
                foreach (var val in valSet)
                    if (val.TimePoint == str)
                    {
                        row[val.Condition] = val.Value;
                        rowStDev[val.Condition] = val.StDev.ToString() + " (" + string.Join(",", val.Experiments) + ")";
                    }
                //add the rows to the tables
                dt.Rows.Add(row);
                dtStDev.Rows.Add(rowStDev);
            }
            //clear
            time.Clear();
            Condition.Clear();
            time = null;
            Condition = null;
            //Return value
            return new DataTable[] { dt, dtStDev };
        }
        /// <summary>
        /// Data table: Gene/Condition
        /// </summary>
        /// <param name="valSet"></param>
        /// <returns></returns>
        private static DataTable[] DataTableForTime1(List<MyData> valSet)
        {
            //create variables
            List<string> genes = new List<string>();
            List<string> conditions = new List<string>();
            //extract all XY values
            foreach (var val in valSet)
            {
                if (!genes.Contains(val.Gene)) genes.Add(val.Gene);
                if (!conditions.Contains(val.Condition)) conditions.Add(val.Condition);
            }
            //create data tables
            DataTable dt = new DataTable();
            DataTable dtStDev = new DataTable();
            //add the row titles column
            dt.Columns.Add("Gene\\Condition");
            dtStDev.Columns.Add("Gene\\Condition");
            //add all coulmn titles
            foreach (string str in conditions)
            {
                dt.Columns.Add(str);
                dtStDev.Columns.Add(str);
            }
            //add the rows
            foreach (string str in genes)
            {
                var row = dt.NewRow();
                var rowStDev = dtStDev.NewRow();
                //set the row title
                row["Gene\\Condition"] = str;
                rowStDev["Gene\\Condition"] = str;
                //store the value and the StDev to the table
                foreach (var val in valSet)
                    if (val.Gene == str)
                    {
                        row[val.Condition] = val.Value;
                        rowStDev[val.Condition] = val.StDev.ToString() + " (" + string.Join(",", val.Experiments) + ")";
                    }
                //add the rows to the tables
                dt.Rows.Add(row);
                dtStDev.Rows.Add(rowStDev);
            }
            //clear
            genes.Clear();
            conditions.Clear();
            genes = null;
            conditions = null;
            //Return value
            return new DataTable[] { dt, dtStDev };
        }
        /// <summary>
        /// Data table: Gene/Time
        /// </summary>
        /// <param name="valSet"></param>
        /// <returns></returns>
        private static DataTable[] DataTableForCondition1(List<MyData> valSet)
        {
            //create variables
            List<string> genes = new List<string>();
            List<string> time = new List<string>();
            //extract all XY values
            foreach (var val in valSet)
            {
                if (!genes.Contains(val.Gene)) genes.Add(val.Gene);
                if (!time.Contains(val.TimePoint)) time.Add(val.TimePoint);
            }
            //create data tables
            DataTable dt = new DataTable();
            DataTable dtStDev = new DataTable();
            //add the row titles column
            dt.Columns.Add("Gene\\Time");
            dtStDev.Columns.Add("Gene\\Time");
            //add all coulmn titles
            foreach (string str in time)
            {
                dt.Columns.Add(str);
                dtStDev.Columns.Add(str);
            }
            //add the rows
            foreach (string str in genes)
            {
                var row = dt.NewRow();
                var rowStDev = dtStDev.NewRow();
                //set the row title
                row["Gene\\Time"] = str;
                rowStDev["Gene\\Time"] = str;
                //store the value and the StDev to the table
                foreach (var val in valSet)
                    if (val.Gene == str)
                    {
                        row[val.TimePoint] = val.Value;
                        rowStDev[val.TimePoint] = val.StDev.ToString() + " (" + string.Join(",", val.Experiments) + ")";
                    }
                //add the rows to the tables
                dt.Rows.Add(row);
                dtStDev.Rows.Add(rowStDev);
            }
            //clear
            genes.Clear();
            time.Clear();
            genes = null;
            time = null;
            //Return value
            return new DataTable[] { dt, dtStDev };
        }
        /// <summary>
        /// Data table: Condition/Time
        /// </summary>
        /// <param name="valSet"></param>
        /// <returns></returns>
        private static DataTable[] DataTableForGene1(List<MyData> valSet)
        {
            //create variables
            List<string> Condition = new List<string>();
            List<string> time = new List<string>();
            //extract all XY values
            foreach (var val in valSet)
            {
                if (!Condition.Contains(val.Condition)) Condition.Add(val.Condition);
                if (!time.Contains(val.TimePoint)) time.Add(val.TimePoint);
            }
            //create data tables
            DataTable dt = new DataTable();
            DataTable dtStDev = new DataTable();
            //add the row titles column
            dt.Columns.Add("Condition\\Time");
            dtStDev.Columns.Add("Condition\\Time");
            //add all coulmn titles
            foreach (string str in time)
            {
                dt.Columns.Add(str);
                dtStDev.Columns.Add(str);
            }
            //add the rows
            foreach (string str in Condition)
            {
                var row = dt.NewRow();
                var rowStDev = dtStDev.NewRow();
                //set the row title
                row["Condition\\Time"] = str;
                rowStDev["Condition\\Time"] = str;
                //store the value and the StDev to the table
                foreach (var val in valSet)
                    if (val.Condition == str)
                    {
                        row[val.TimePoint] = val.Value;
                        rowStDev[val.TimePoint] = val.StDev.ToString() + " (" + string.Join(",", val.Experiments) + ")";
                    }
                //add the rows to the tables
                dt.Rows.Add(row);
                dtStDev.Rows.Add(rowStDev);
            }
            //clear
            time.Clear();
            Condition.Clear();
            time = null;
            Condition = null;
            //Return value
            return new DataTable[] { dt, dtStDev };
        }
        /// <summary>
        /// Saves two-dimmentional string array to given directory by using ";" as separator - CSV file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dir"></param>
        public static void ExportDataTable(string[][] data, string dir)
        {
            StreamWriter write = new StreamWriter(File.Create(dir));

            foreach (string[] row in data)
                write.WriteLine(string.Join(";", row));

            write.Close();
            write.Dispose();
        }
        /// <summary>
        /// Prepare the data table for exporting
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static string[][] PrepareArrayForExport(DataGridView dgv)
        {
            string[][] result = new string[dgv.Rows.Count + 1][];
            int[] matrix = new int[dgv.Columns.Count];
            DataTable dt = (DataTable)dgv.DataSource;

            for (int i = 0; i < matrix.Length; i++)
                matrix[i] = dgv.Columns[i].DisplayIndex;

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new string[dgv.Columns.Count];

                if (i != 0)
                    for (int j = 0; j < matrix.Length; j++)
                        result[i][matrix[j]] = dt.Rows[i - 1].ItemArray[j].ToString();
                else
                    for (int j = 0; j < matrix.Length; j++)
                        result[i][matrix[j]] = dt.Columns[j].ColumnName;
            }
            matrix = null;
            dt = null;
            return result;
        }
    }
}
