using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace qPCRDataAnalysis
{
    public partial class Form1 : Form
    {
        private MyData[] data = null;//store the input data
        private bool switchXY = false;//setting the X and Y axis
        private Rectangle dragBoxFromMouseDown;//used for the drag and drop row reordering
        private int rowIndexFromMouseDown;//reordering - starting row index
        private int rowIndexOfItemUnderMouseToDrop;//reordering - final row index
        /// <summary>
        /// Initializing the main form interface
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Loading the data and adding events to the controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //data grid panel height must be 1/2 of the screen size
            this.panel2.Height = this.panel1.Height / 2;
            //Add event when the form is resized
            this.Resize += Form1_Resize;
            //change the culture to german
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("de-DE");
            //try to load the input file
            LoadInputData();
            //add events to the filter comboboxes
            comboBox_Gene1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox_Condition1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox_TimePoint1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            //add reordering events to the data grid view
            dataGridView1.AllowDrop = true;
            dataGridView1.MouseMove += dataGridView1_MouseMove;
            dataGridView1.MouseDown += dataGridView1_MouseDown;
            dataGridView1.DragOver += dataGridView1_DragOver;
            dataGridView1.DragDrop += dataGridView1_DragDrop;
            dataGridView1.ColumnDisplayIndexChanged += DataGridView1_ColumnDisplayIndexChanged;
        }
        /// <summary>
        /// Event that occures when the form is resized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            //data grid panel height must be 1/2 of the screen size
            this.panel2.Height = this.panel1.Height / 2;
        }
        /// <summary>
        /// Event when button "Load" is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Load_Click(object sender, EventArgs e)
        {
            //try to load the input file
            LoadInputData();
        }
        /// <summary>
        /// Reads the input file and store the data
        /// </summary>
        private void LoadInputData()
        {
            //clear the previous loaded data
            this.dataGridView1.DataSource = null;
            this.dataGridView2.DataSource = null;
            //clear the combo boxes items list
            this.comboBox_TimePoint1.Items.Clear();
            this.comboBox_TimePoint2.Items.Clear();
            this.comboBox_Condition1.Items.Clear();
            this.comboBox_Condition2.Items.Clear();
            this.comboBox_Gene1.Items.Clear();
            this.comboBox_Gene2.Items.Clear();
            //add the first item "None"
            this.comboBox_TimePoint1.Items.Add("None");
            this.comboBox_TimePoint2.Items.Add("None");
            this.comboBox_Condition1.Items.Add("None");
            this.comboBox_Condition2.Items.Add("None");
            this.comboBox_Gene1.Items.Add("None");
            this.comboBox_Gene2.Items.Add("None");
            //select the first item "None"
            this.comboBox_TimePoint1.SelectedIndex = 0;
            this.comboBox_TimePoint2.SelectedIndex = 0;
            this.comboBox_Condition1.SelectedIndex = 0;
            this.comboBox_Condition2.SelectedIndex = 0;
            this.comboBox_Gene1.SelectedIndex = 0;
            this.comboBox_Gene2.SelectedIndex = 0;
            //Read the data
            this.data = MyFunctions.ReadInputDataFile();
            //break if there is any error
            if (this.data == null)
                return;
            //calculate the avg from the repeats
            this.data = MyFunctions.RemoveRepeats(this.data);

            //load the data to the combo boxes 
            foreach (var val in this.data)
                if (val != null)
                {
                    if (!this.comboBox_TimePoint1.Items.Contains(val.TimePoint))
                        this.comboBox_TimePoint1.Items.Add(val.TimePoint);

                    if (!this.comboBox_TimePoint2.Items.Contains(val.TimePoint))
                        this.comboBox_TimePoint2.Items.Add(val.TimePoint);

                    if (!this.comboBox_Condition1.Items.Contains(val.Condition))
                        this.comboBox_Condition1.Items.Add(val.Condition);

                    if (!this.comboBox_Condition2.Items.Contains(val.Condition))
                        this.comboBox_Condition2.Items.Add(val.Condition);

                    if (!this.comboBox_Gene1.Items.Contains(val.Gene))
                        this.comboBox_Gene1.Items.Add(val.Gene);

                    if (!this.comboBox_Gene2.Items.Contains(val.Gene))
                        this.comboBox_Gene2.Items.Add(val.Gene);
                }
        }
        /// <summary>
        /// THis event is activated when the selected item in the filter combo box is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check is the combobox active
            if (!((ComboBox)sender).Focused) return;
            //set the other combo boxes selection index to 0 - "None"
            if (!this.comboBox_TimePoint1.Focused && this.comboBox_TimePoint1.Items.Count >= 1)
                this.comboBox_TimePoint1.SelectedIndex = 0;

            if (!this.comboBox_Condition1.Focused && this.comboBox_Condition1.Items.Count >= 1)
                this.comboBox_Condition1.SelectedIndex = 0;

            if (!this.comboBox_Gene1.Focused && this.comboBox_Gene1.Items.Count >= 1)
                this.comboBox_Gene1.SelectedIndex = 0;
        }
        /// <summary>
        /// This event is activated when the button process is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Process_Click(object sender, EventArgs e)
        {
            //check is the data loaded
            if (this.data == null)
            {
                MessageBox.Show("No data!");
                return;
            }
            //check are the reference values set
            if (this.comboBox_TimePoint2.SelectedIndex == 0 || this.comboBox_Condition2.SelectedIndex == 0)
            {
                MessageBox.Show("Refference protein Time and Condition not set!");
                return;
            }
            //clear the data grid tables
            this.dataGridView1.DataSource = null;
            this.dataGridView2.DataSource = null;
            //string values of the selected combobox items
            string refGene = "", refTime = "", refCondition = "";
            string gene = "", time = "", condition = "";

            refGene = this.comboBox_Gene2.Text;
            if (this.comboBox_Gene2.SelectedIndex == 0) refGene = "";
            refTime = this.comboBox_TimePoint2.Text;
            refCondition = this.comboBox_Condition2.Text;

            if (this.comboBox_Gene1.SelectedIndex != 0)
                gene = this.comboBox_Gene1.Text;

            if (this.comboBox_TimePoint1.SelectedIndex != 0)
                time = this.comboBox_TimePoint1.Text;

            if (this.comboBox_Condition1.SelectedIndex != 0)
                condition = this.comboBox_Condition1.Text;
            //Calculate the data tables
            DataTable[] dts = MyFunctions.ProcessTheData(
                this.data, refGene, refTime, refCondition, gene, time, condition, this.switchXY);
            //if the data tables are ok - load them to the data grid views
            if (dts != null)
            {
                this.dataGridView1.DataSource = dts[0];
                this.dataGridView2.DataSource = dts[1];
            }
        }
        /// <summary>
        /// This event changes the directions of the tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_switchXY_Click(object sender, EventArgs e)
        {
            //change the directions of the tables
            this.switchXY = !this.switchXY;
            //load the tables to the screen
            button_Process_Click(sender, e);
        }
        /// <summary>
        /// This event is activated when the mouse enters the data grid view 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dataGridView1.DoDragDrop(
                          dataGridView1.Rows[rowIndexFromMouseDown],
                          DragDropEffects.Move);
                }
            }
        }
        /// <summary>
        /// This event is activated by left mouse click (down) over the data grid view 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(
                          new Point(
                            e.X - (dragSize.Width / 2),
                            e.Y - (dragSize.Height / 2)),
                      dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }
        //activate the drag and drop event
        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        //drop the item into the new location
        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                try
                {
                    //prepare the first table
                    DataRow firstSelectedRow = ((DataTable)dataGridView1.DataSource).Rows[rowIndexFromMouseDown];
                    DataRow firstNewRow = ((DataTable)dataGridView1.DataSource).NewRow();
                    firstNewRow.ItemArray = firstSelectedRow.ItemArray; // copy data

                    if (firstNewRow != null &&
                        rowIndexOfItemUnderMouseToDrop > -1 &&
                        rowIndexOfItemUnderMouseToDrop < ((DataTable)dataGridView1.DataSource).Rows.Count)
                    {
                        ((DataTable)dataGridView1.DataSource).Rows.RemoveAt(rowIndexFromMouseDown);
                        ((DataTable)dataGridView1.DataSource).Rows.InsertAt(firstNewRow, rowIndexOfItemUnderMouseToDrop);
                    }
                    //prepare the secound table
                    firstSelectedRow = ((DataTable)dataGridView2.DataSource).Rows[rowIndexFromMouseDown];
                    firstNewRow = ((DataTable)dataGridView2.DataSource).NewRow();
                    firstNewRow.ItemArray = firstSelectedRow.ItemArray; // copy data

                    if (firstNewRow != null &&
                        rowIndexOfItemUnderMouseToDrop > -1 &&
                        rowIndexOfItemUnderMouseToDrop < ((DataTable)dataGridView2.DataSource).Rows.Count)
                    {
                        ((DataTable)dataGridView2.DataSource).Rows.RemoveAt(rowIndexFromMouseDown);
                        ((DataTable)dataGridView2.DataSource).Rows.InsertAt(firstNewRow, rowIndexOfItemUnderMouseToDrop);
                    }
                }
                catch { }
            }
        }
        //reorder the columns
        private void DataGridView1_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //check is the data calculated
            if (this.dataGridView1.DataSource == null || this.dataGridView2.DataSource == null) return;
            //Get column name and index from data grid view 1
            string name = e.Column.Name;
            int ind = e.Column.DisplayIndex;
            //modify data grid view 2
            if (this.dataGridView2.Columns.Contains(name))
            {
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                    if (this.dataGridView2.Columns[i].Name == name)
                    {
                        this.dataGridView2.Columns[i].DisplayIndex = ind;
                    }
            }
        }
        /// <summary>
        /// This event is activated when the button Export is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Export_Click(object sender, EventArgs e)
        {
            //check is the data calculated
            if (dataGridView1.DataSource == null || dataGridView2.DataSource == null) return;
            //open file save dialog and set the settings
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save CSV Files";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //get the file name
                string dir = saveFileDialog1.FileName;
                if (dir.Contains("."))
                    dir = dir.Substring(0, dir.LastIndexOf("."));
                //export the files
                try
                {
                    MyFunctions.ExportDataTable(MyFunctions.PrepareArrayForExport(dataGridView1), dir + "_Data.csv");
                    MyFunctions.ExportDataTable(MyFunctions.PrepareArrayForExport(dataGridView2), dir + "_StDev.csv");
                }
                catch
                {
                    MessageBox.Show("The files are opened in another application or administrative rights are required!");
                }
            }

        }
        /// <summary>
        /// This events  activate data table column deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DeleteColumn_Click(object sender, EventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            if(columnIndex>-1 && columnIndex < dataGridView1.ColumnCount)
            {
                dataGridView1.Columns.RemoveAt(columnIndex);
                dataGridView2.Columns.RemoveAt(columnIndex);
            }
        }
        /// <summary>
        /// This events  activate data table row deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_deleteRow_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            if (rowIndex > -1 && rowIndex < dataGridView1.RowCount)
            {
                dataGridView1.Rows.RemoveAt(rowIndex);
                dataGridView2.Rows.RemoveAt(rowIndex);
            }
        }
    }
}
