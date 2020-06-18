using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime.Account.Data.Core
{
    [Table("PersonAddressType")]
    public partial class PersonAddressType
    {
        public PersonAddressType()
        {
            PersonAddresses = new HashSet<PersonAddress>();
        }

        [Key]
        public int AddressTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
    }
}
