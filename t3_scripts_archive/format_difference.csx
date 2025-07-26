// Loop through all selected measures in the model
foreach (var measure in Selected.Measures)
{
    // Apply the plus/minus format for positive and negative values
    measure.FormatString = "+#,0;-#,0";
    
    // If measure contains positive values, they will be prefixed with a '+'
    // If measure contains negative values, they will be prefixed with a '-'
}
