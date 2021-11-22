using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allContactInfo;
        private string fullName;
        private string allPhones;

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

        public string Firstname { get; set; }

        public string Middlename { get; set; }

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
                    string birthday = string.Empty;
                    if (Birthday != "0")
                    {
                        birthday = Birthday + ".";
                    }
                    
                    string birtmonth = string.Empty;
                    if (Birthmonth != "-")
                    {
                        birtmonth = " " + Birthmonth;
                    }

                    string birthyear = string.Empty;
                    if (Birthyear != "")
                    {
                        birthyear = " " + Birthyear;
                    }

                    string age = string.Empty;
                    if (Birthyear != "")
                    {
                        age = " (" + (2021 - Convert.ToInt32(Birthyear)) + ")".ToString();
                    }

                    string anniversaryday = string.Empty;
                    if (Anniversaryday != "0")
                    {
                        anniversaryday = Anniversaryday + ".";
                    }

                    string anniversarymonth = string.Empty;
                    if (Anniversarymonth != "-")
                    {
                        anniversarymonth = " " + Anniversarymonth;
                    }

                    string anniversaryyear = string.Empty;
                    if (Anniversaryyear != "")
                    {
                        anniversaryyear = " " + Anniversaryyear;
                    }

                    string annyage = string.Empty;
                    if (Anniversaryyear != "")
                    {
                        annyage = " (" + (2021 - Convert.ToInt32(Anniversaryyear)) + ")".ToString();
                    }

                    return (Addrn(FullName) + Addrn(Nickname) + Addrn(Title) + Addrn(Company) + Addrn(Address) + Addrn(HomePhone) + Addrn(MobilePhone) + 
                        Addrn(WorkPhone) + Addrn(Fax) + Addrn(Email) + Addrn(Email2) + Addrn(Email3) + Addrn(Homepage) + Addrn(birthday + birtmonth + birthyear + age) + 
                        Addrn(anniversaryday + anniversarymonth + anniversaryyear + annyage) + Addrn(Address2) + Addrn(HomePhone2) + Addrn(Notes)).Trim();
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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(HomePhone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        private string Addrn(string anytext)
        {
            if (anytext == null || anytext == "")
            {
                return "";
            }
            return anytext + "\r\n";
        }
    }
}
