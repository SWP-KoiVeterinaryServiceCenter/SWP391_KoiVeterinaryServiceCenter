using MassTransit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public  class BaseEntity:BaseEntity<Guid>
    {
        public BaseEntity()
        {
            Id = NewId.Next().ToGuid();
        }
    }
    public class BaseEntity<TId>
    {
        [Key]
        public TId Id { get; set; } = default!;
    }
}
