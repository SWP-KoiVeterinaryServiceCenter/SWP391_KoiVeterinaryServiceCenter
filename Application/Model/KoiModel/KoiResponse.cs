using Domain.Entities.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.KoiModel
{
    public class KoiResponse : BaseEntity
    {
        public string KoiName { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Varieties { get; set; }
        public Guid AccountId { get; set; }
        //public Account Account { get; set; }
        //public Guid? CreatedBy { get; set; }
        //public DateTime? CreationDate { get; set; }
        //public Guid? ModificationBy { get; set; }
        //public DateTime? ModificationDate { get; set; }
        //public bool IsDelete { get; set; }
        //public Guid? DeletedBy { get; set; }
        //public DateTime? DeletionDate { get; set; }
    }
}
