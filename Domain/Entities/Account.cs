using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account : BaseEntity,ICreatedBy,IModificationBy,IDeletedBy
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Fullname { get; set; }
        public string Location { get; set; }
        public string Phonenumber { get; set; }
        public string ContactLink { get; set; }
        public string? ProfileImage { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Guid? WorkingScheduleId { get; set; }
        public WorkingSchedule WorkingSchedule { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? ModificationBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDelete { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public ICollection<Koi> KoiLists { get; set; }
    }
}
