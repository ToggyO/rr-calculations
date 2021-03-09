using System;

namespace RrNetBack.Domain.Models
{
    public class BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}