using System.ComponentModel.DataAnnotations;

namespace NetCore.BatchCRUD.Infrastructures.Models
{
    public class Book : BaseModel
    {
        [StringLength(200)]
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
