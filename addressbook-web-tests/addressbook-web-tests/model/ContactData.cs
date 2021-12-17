using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allContactInfo;
        private string fullName;
        private string allEmail;
        private string allPhones;

        public ContactData()
        {
        }

        public ContactData(string firstname)
        {
            Firstname = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Lastname == other.Lastname && Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() + Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return Lastname + " " + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Object.ReferenceEquals(Lastname, other.Lastname))
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Birthday { get; set; }

        public string Birthmonth { get; set; }

        public string Birthyear { get; set; }

        public string Anniversaryday { get; set; }

        public string Anniversarymonth { get; set; }

        public string Anniversaryyear { get; set; }

        public string Address2 { get; set; }

        public string HomePhone2 { get; set; }

        public string Notes { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllContactInfo
        {
            get
            {
                if (allContactInfo != null)
                {
                    return allContactInfo;
                }
                else
                {
                    return Addrn(FullName) + CleanUp(Nickname) + Addrn(CleanUp(Title) + CleanUp(Company) + CleanUp(Address)) + 
                        Addrn(ForPhones(HomePhone)) + Addrn(ForPhones(MobilePhone)) + Addrn(ForPhones(WorkPhone)) + Addrn(ForPhones(Fax)) +
                        Addrn(CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)) + CleanUp(Homepage) + 
                        Addrn(ForDays(Birthday) + Spaces(Birthmonth) + ForYears(Birthyear) + ForDays(Anniversaryday) + Spaces(Anniversarymonth) + ForYears(Anniversaryyear)) + 
                        Addrn(CleanUp(Address2)) + Addrn(ForPhones(HomePhone2)) + CleanUp(Notes);
                }
            }
            set { allContactInfo = value; }
        }

        public string FullName
        {
            get
            {
                if (fullName != null)
                {
                    return fullName;
                }
                else
                {
                    return (Firstname + " " + Middlename + " " + Lastname).Trim();
                }
            }
            set
            {
                fullName = value;
            }
        }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (Addrn(Email) + Addrn(Email2) + Addrn(Email3)).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (PhonesCleanUp(HomePhone) + PhonesCleanUp(MobilePhone) + PhonesCleanUp(WorkPhone) + PhonesCleanUp(HomePhone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string Spaces(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return data + " ";
        }

        private string CleanUp(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            if (data == Homepage)
            {
                return "Homepage:" + "\r\n" + data + "\r\n\r\n";
            }
            if (data == Notes)
            {
                return (data + "\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            }
            return data + "\r\n";
        }

        private string PhonesCleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[- ()]", "") + "\r\n";
        }

        private string ForPhones(string phone)
        {
            if (phone == HomePhone)
            {
                return "H: " + phone;
            }
            else if (phone == MobilePhone)
            {
                return "M: " + phone;
            }
            else if (phone == WorkPhone)
            {
                return "W: " + phone;
            }
            else if (phone == Fax)
            {
                return "F: " + phone + "\r\n";
            }
            else if (phone == HomePhone2)
            {
                return "P: " + phone + "\r\n";
            }
            return "";
        }

        private string ForDays(string day)
        {
            if (day == null || day == "")
            {
                return "";
            }
            if (day == Birthday)
            {
                return "Birthday " + day + ". ";
            }
            if (day == Anniversaryday)
            {
                return "Anniversary " + day + ". ";
            }
            return "";
        }

        private string ForYears(string year)
        {
            if (year == null || year == "")
            {
                return "";
            }
            return year + " (" + (2021 - Convert.ToInt32(year)) + ")" + "\r\n";
        }

        private string Addrn(string anytext)
        {
            if (anytext == null || anytext == "")
            {
                return "";
            }
            return anytext + "\r\n";
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
