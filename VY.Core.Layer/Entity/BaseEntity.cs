using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VY.Core.Layer.Entity
{
    public class BaseEntity:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  Guid Id { get; set; } 
        public  DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public  DateTime UpdateTime { get; set; }= DateTime.UtcNow;
        public bool IsActive { get; set; } = false;
    }
}
