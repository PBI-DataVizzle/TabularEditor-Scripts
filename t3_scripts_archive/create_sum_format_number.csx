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
/* 
 * m.Table.AddMeasure( "MeasureName", "Expression", m.DisplayFolder);
 */

/* Creates a SUM measure for every currently selected column(s)
 *
 * Author: Mike Carlo, https://powerbi.tips
 *
 * Select Columns using Control + Left Click
 * Script will create one measure for each column selected
 * Then Change the formatting of the column, adds a description,
 * and places measures in a named folder.
 *
 */


/**** C# SCRIPT START ****/

///--- SET VARIABLES ---\\\
//-- Quotation Character - helpful for wrapping " " around a text string within the DAX code
const string qt = "\"";
var newMeasureFolder = "__Measures";
var newMeasureSubFolder = "\\_m";

var GBP0 = qt + "£" + qt + "#,0";
var INT = "#,0";

//-- Loop through the list of selected columns
foreach(var c in Selected.Columns)
{
    var newMeasure = c.Table.AddMeasure(
        "# " + c.Name + " | BASE",             // Name
        "SUM(" + c.DaxObjectFullName + ")",    // DAX expression
        c.DisplayFolder = newMeasureFolder       // Display Folder
    );
    
    //-- Set the format string on the new measure:
    newMeasure.FormatString = INT;

    //-- Provide some documentation:
    newMeasure.Description = "SUM of Column: " + c.DaxObjectFullName;

    //-- Create all measures within a Named Folder
    newMeasure.DisplayFolder = 
        newMeasureFolder
        // + newMeasureSubFolder
        ;

    // Hide the base column:
    c.IsHidden = true;
}
