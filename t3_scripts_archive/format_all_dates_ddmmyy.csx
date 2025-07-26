foreach(var column in Model.Tables.SelectMany(t => t.Columns))
{
    if(column.DataType.ToString() == "DateTime")
    {
        column.FormatString = "dd/mm/yy";
        column.RemoveAnnotation("Format");
    } 
}
