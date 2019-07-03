using System;
using System.Collections.Generic;

namespace qPCRDataAnalysis
{
    class MyData
    {
        private int _Experiment;
        private string _TimePoint;
        private string _CellLine;
        private string _Condition;
        private string _Gene;
        private double _Value;
        private List<double> _Series;
        private List<string> _Experiments;
        private double _StDev;
        /// <summary>
        /// Create new empty class
        /// </summary>
        public MyData()
        {

        }
        /// <summary>
        /// create new data class by using predefined parameters
        /// </summary>
        /// <param name="str"></param>
        public MyData(string input)
        {
            //splits tab-delimited string and store the information to array
            string[] vals = input.Split(new string[] { ";" }, StringSplitOptions.None);
            //store the information to the arrays
            this._Experiment = int.Parse(vals[0]);//convert string to integer
            this._TimePoint = vals[1];
            this._CellLine = vals[2];
            this._Condition = vals[3];
            this._Gene = vals[4];
            this._Value = double.Parse(vals[5]);//convert string to double
            vals = null;//delete information from the RAM
        }
        /// <summary>
        /// Get or set the experiment index
        /// </summary>
        public int Experiment
        {
            get { return _Experiment; }
            set { this._Experiment = value; }
        }
        /// <summary>
        /// Get or set the time point
        /// </summary>
        public string TimePoint
        {
            get { return _TimePoint; }
            set { this._TimePoint = value; }
        }
        /// <summary>
        /// Get or set the cell line
        /// </summary>
        public string CellLine
        {
            get { return _CellLine; }
            set { this._CellLine = value; }
        }
        /// <summary>
        /// Get or set the condition
        /// </summary>
        public string Condition
        {
            get { return _Condition; }
            set { this._Condition = value; }
        }
        /// <summary>
        /// Get or set the gene name
        /// </summary>
        public string Gene
        {
            get { return _Gene; }
            set { this._Gene = value; }
        }
        /// <summary>
        /// Get or set the value
        /// </summary>
        public double Value
        {
            get { return _Value; }
            set { this._Value = value; }
        }
        /// <summary>
        /// Get or set the StDev.S
        /// </summary>
        public double StDev
        {
            get { return _StDev; }
            set { this._StDev = value; }
        }
        /// <summary>
        /// Get or set the series of the same experiment
        /// </summary>
        public List<double> Series
        {
            get { return _Series; }
            set { this._Series = value; }
        }
        /// <summary>
        /// Get or set the experiment indexes
        /// </summary>
        public List<string> Experiments
        {
            get { return _Experiments; }
            set { this._Experiments = value; }
        }
        /// <summary>
        /// Duplicate the current class
        /// </summary>
        /// <returns>Copy of this class</returns>
        public MyData Duplicate()
        {
            MyData newStorage = new MyData();

            newStorage.Experiment = this._Experiment;
            newStorage.Experiments = this._Experiments;
            newStorage.TimePoint = this._TimePoint;
            newStorage.CellLine = this._CellLine;
            newStorage.Condition = this._Condition;
            newStorage.Gene = this._Gene;
            newStorage.Value = this._Value;
            newStorage.StDev = this._StDev;

            return newStorage;
        }
    }
}
