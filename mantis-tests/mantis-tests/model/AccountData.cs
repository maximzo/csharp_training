using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_user_table")]
    public class AccountData : IEquatable<AccountData>, IComparable<AccountData>
    {
        public AccountData()
        {
        }

        public AccountData(string username, string password)
        {
            Name = username;
            Password = password;
        }

        [Column(Name = "id")]
        public string Id { get; set; }
        [Column(Name = "username")]
        public string Name { get; set; }
        [Column(Name = "password")]
        public string Password { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }

        internal static List<AccountData> GetAll()
        {
            using (MantisDB db = new MantisDB())
            {
                return (from a in db.Accounts select a).ToList();
            }
        }

        public bool Equals(AccountData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public int CompareTo(AccountData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}