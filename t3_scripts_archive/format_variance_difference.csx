// Loop through all selected measures in the model
foreach (var measure in Selected.Measures)
{
    // Get the DAX Object Name (which is the measure name)
    var measureName = measure.Name;

    // Check if the measure name starts with '#'
    if (measureName.StartsWith("#"))
    {
        // Apply the plus/minus format with 1 decimal place
        measure.FormatString = "+#,0.0;-#,0.0";
    }
    // Check if the measure name starts with '%'
    else if (measureName.StartsWith("%"))
    {
        // Apply the variance percentage format with triangle up/down for positive/negative
        // and 1 decimal place
        measure.FormatString = "▲ #,0.0%;▼ #,0.0%";
    }
}

