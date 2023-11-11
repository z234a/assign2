using System.ComponentModel.DataAnnotations;

namespace assign2.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Usefulness { get; set; }
        public int? TopicID { get; set; }
        public virtual Topic Topic { get; set; }
    }
}