// Loop through all selected measures in the model
foreach (var measure in Selected.Measures)
{
    // Apply the variance percentage format with triangle up/down for positive/negative
    measure.FormatString = "▲#,0%;▼#,0%";
    
    // If measure contains negative values, they will show the downward triangle ▼
    // If measure contains positive values, they will show the upward triangle ▲
}

