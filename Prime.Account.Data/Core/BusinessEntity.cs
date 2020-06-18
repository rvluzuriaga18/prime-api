using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime.Account.Data.Core
{
    [Table("BusinessEntity")]
    public partial class BusinessEntity
    {
        public BusinessEntity()
        {
            PersonAddresses = new HashSet<PersonAddress>();
        }

        public long BusinessEntityId { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
    }
}
