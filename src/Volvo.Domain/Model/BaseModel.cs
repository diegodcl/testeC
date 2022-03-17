using System.ComponentModel.DataAnnotations;

namespace Volvo.Domain.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? _createdAt;
        public DateTime? CreatedAt { 
            get { return _createdAt; } 
            set { _createdAt = (value ==  null ? DateTime.UtcNow : value); }
        }
        public  DateTime? UpdatedAt { get; set; }
    }
}