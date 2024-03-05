namespace Business.Entities.DevelopmentArea.DynamicFormM
{
    public class TableData
    {
        public string ColumnName { get; set; }
        public string Datatype { get; set; }
        public string Size { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsReference { get; set; }
        public string ReferenceTable { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsDefault { get; set; }
        public string DefaultValue { get; set; }
    }
}
