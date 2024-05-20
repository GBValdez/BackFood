using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using project.users;
using project.utils.interfaces;

namespace project.utils
{
    public class CommonsModel<idClass> : ICommonModel<idClass>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public idClass Id { get; set; }

        public string? userUpdateId { get; set; }

        [ForeignKey("userUpdateId")]
        public userEntity? userUpdate { get; set; }
        public DateTime? deleteAt { get; set; }
        public DateTime? updateAt { get; set; }
    }
}