/*---------------------------------------------------
| DESCRIPTION:                                       |
| Create SUM from Selected Columns                   |
| Tabular Editor Advanced Script                     |
 ----------------------------------------------------
| AUTHOR:                                            |
| Imran Haq | PBI Queryous                           |
| https://github.com/PBIQueryous                     |
| STAY QUERYOUS!                                     |
 ---------------------------------------------------*/


//--- C# measure formula template ---\\
/* m.Table.AddMeasure( "MeasureName", "Expression", m.DisplayFolder); */


 /* DESCRIPTION
 * -----------------------------------
 * This script, when executed, will loop through the currently selected measure(s),
 * creating a series of measure(s) declared in the script below.
 * 
 * e.g., from Model select [Measure] where Measure = SUM( tbl[column] ) or COUNT( tbl[column] )
 * -----------------------------------
 */

/**** C# SCRIPT START ****/

///--- SET VARIABLES ---\\\
//-- Quotation Character - helpful for wrapping " " around a text string within the DAX code
const string qt = "\"";
var lf = '\n';
var newMeasureFolder = "__Snap";
var newMeasureSubFolder = "\\SubFolder";

// Number Formatting Strings
var GBP0 = qt + "£" + qt + "#,0";
var GBP2 = qt + "£" + qt + "#,0.00";
var posGBP = GBP0;
var negGBP = "-"+GBP0;
var neutGBP = GBP0;
var Whole = "#,0";
var Percent = "0.0 %";
var Decimal = "#,0.0";
var Number = "#,0";
var Currency0 = posGBP +";" + negGBP + ";" + neutGBP ;
var Currency2 = GBP2+";" +"-"+GBP2+";" +GBP2;
var Deviation = "+"+Decimal+";" +"-"+Decimal+";"+ Decimal;

// Var RETURN text strings
var ts_VarResult = "var _result = ";
var ts_ReturnResult = "RETURN" + '\n' + "_result";
var ts_Return = "RETURN" + '\n';
var ts_IfNotBlank = '\t' + "// IF(  NOT ISBLANK( ";
var ts_ThenResult = " ) ,  _result  )";
var ts_Result = '\t' + "_result";

// MeasureName Variables
var snap = " | SNAP";
var ytd = " | YTD";
var cml = " | CML";
var rem = " | REM";
var ytdCml = " | YTD CML";
var remCml = " | REM CML";
var fytd = " | FYTD";
var aytd = " | AYTD";
var fytdCml = " | FYTD CML";
var aytdCml = " | AYTD CML";
var pytd = " | PYTD";
var pfytd = " | PFYTD";
var paytd = " | PAYTD";
var pfytdCml = " | PFYTD CML";
var paytdCml = " | PAYTD CML";



// TimeIntel Variable Filters
var datesDate = "Dates[Date]";
var datesMTD = "Dates[LatestMTD]";
var isCFY = "Dates[IsCFY] = TRUE";
var isCYTD = "Dates[IsCYTD] = TRUE";
var maxDate = "_maxDate";
var curDate = "_curDate";
var mtdDate = "_ytd";
var vardatesDate = "var " +maxDate+ " = MAX( " + datesDate + " )";
var varlatestMTD = "var "+mtdDate+ " = CALCULATE( MAX( " +datesMTD+ " ), REMOVEFILTERS())";
var varmaxdatesCFY = "var " +maxDate+ " = CALCULATE( MAX( " +datesDate+ "), " + isCFY + " )";
var fiscalyear = qt+"31/3"+qt;
var datesFiscal = "DATESYTD (" + datesDate + "," + fiscalyear + " )";
// Var Measure Folder
var subFolder = "_Measures\\SubFolder";

// Script Variable: Creates a series of time intelligence measures for each selected measure in the Model
foreach(var m in Selected.Measures) 
{
 

 
/***************************************** MeasureStart ************************************/
// Measure1: SUM
    var m1 = m.Table.AddMeasure
    (                             

// startSubScript
        //-- MeasureName
        m.Name + snap,                               
    
        //-- DAX comment string
        lf + 
        "-- Snapshot - no date filters "                            
        + lf

/* DAX expression START */              
        
        //-- Result Expression Variable
        + lf 
        + ts_VarResult + m.DaxObjectName 
        + lf
        
        // Return Expression
        + lf 
        + ts_Return
        + ts_Result
        
        //-- optional in DAX
        //-- useful in cumulative measures - returns blank if no value exists for future dates
        //-- + '\n' + ts_IfNotBlank + m.DaxObjectName + ts_ThenResult
        );
/* DAX expression END */
        
//-- Metadata
        //-- Display Folder (default - same folder as selected)
        m1.DisplayFolder 
        //-- Optional: new Folder name below
        = subFolder
        ;      
    
//-- Provide some documentation
        m1.Description = "SNAP of " + m.Name  + ": " + '\n' +
        //-- Type metadata text here
        "No date filters"
        ;                             
        m1.FormatString = Currency0
        ;
//-- endSubScript
/**************************************** MeasureEnd **************************************/


}
/**** C# SCRIPT END ****/

