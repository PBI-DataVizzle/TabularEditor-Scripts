// Loop through all tables in the model
foreach (var table in Model.Tables)
{
    // Loop through all columns in each table
    foreach (var column in table.Columns)
    {
        // Check if the column data type is DateTime
        if (column.DataType == DataType.DateTime)
        {
            // Apply the 'dd/MM/yyyy' format
            column.FormatString = "dd/MM/yyyy";
        }
    }
}
