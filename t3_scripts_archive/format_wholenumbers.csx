// Loop through all selected measures in the model
foreach (var measure in Selected.Measures)
{
    // Get the DAX Object Name (which is the measure name)
    var measureName = measure.Name;

    // Check if the measure name starts with '#'
    if (measureName.StartsWith("#"))
    {
        // Apply the whole number format with comma separator and 0 decimal places
        measure.FormatString = "#,0";
    }
    // Check if the measure name starts with '£'
    else if (measureName.StartsWith("£"))
    {
        // Apply the GBP currency format with comma separator and no decimal places
        measure.FormatString = "£#,0";
    }
}

