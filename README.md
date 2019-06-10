# qPCRDataAnalysis

![Interface](https://github.com/GDanovski/qPCRDataAnalysis/blob/master/qPCRDataAnalysis_Interface.png?raw=true)

  Our software can be used for qPCR data analysis. Your data needs to be stored in CSV file (with  “;” as delimiter) and the name of the file must be “qPCRdata.csv”. It must be located in the “Input” folder in the directory, where the executable file is located. The input  file must contain the following data:<br/>
  *“Experiment;	Timepoint;	Cell line;		Condition;	Gene;	dCt;	Comment;”*<br/>
  In order to process the data you need to specify what to be displayed on the data tables. This can be done by choosing one of our filters. If you select time point filter, the exported table will contain all conditions and genes for the given time point. Analogically, you can set condition (the table will contain all time points and genes for this condition) or gene (the table will contain all time points and conditions for this gene). The rows and columns can be switched by using the button “switchXY”. Reordering of the columns and the rows is also possible by using the “drag-and-drop” feathers of the results table.<br/>
  The tables can be exported as CSV files by pressing the button “Export”.
