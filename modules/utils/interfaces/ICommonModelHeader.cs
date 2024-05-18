
using project.users;

namespace project.utils.interfaces
{
    public interface ICommonModelHeader
    {
        public string userUpdateId { get; set; }

        public DateTime? deleteAt { get; set; }
        public userEntity userUpdate { get; set; }

    }
}