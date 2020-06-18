using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prime.Account.Data.Core
{
    [Table("Person")]
    public partial class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BusinessEntityId { get; set; }

        [StringLength(3)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string Suffix { get; set; }

        public int Age { get; set; }

        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
