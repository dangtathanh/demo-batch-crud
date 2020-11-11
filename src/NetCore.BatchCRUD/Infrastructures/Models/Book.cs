namespace NetCore.BatchCRUD.Infrastructures.Models
{
    public class Book : BaseModel
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
