using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer_GYM_Project_;
using DataAccessLayer_GYM_Project;
using DataAccessLayer_GYM_Project_;

namespace BusinessLayer_GYM_Project
{
    public class clsPerson
    {
        private enum enMode { AddNew, Update };
        enMode _Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        protected clsPerson()
        {
            this.PersonID = -1;
            this.Name = "";
            this.Email = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.Phone1 = "";
            this.Phone2 = "";
            _Mode = enMode.AddNew;

        }
        protected clsPerson(int PersonID, string Name, string Email, string Address, DateTime DateOfBirth, string Phone1, string Phone2) 
        {
            this.PersonID = PersonID;
            this.Name = Name; 
            this.Email = Email;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.Phone1 = Phone1;
            this.Phone2 = Phone2;
            _Mode = enMode.Update;

        }

        //protected static clsPerson Find(int PersonID)
        //{
        //    string Name = "", Email = "", Address = "", Phone1 = "", Phone2 = "";
        //    DateTime DateOfBirth = DateTime.Now;

        //    if (clsPersonDataAccess.GetPersonInfoByID(ref PersonID, ref Name, ref Email, ref Address, ref DateOfBirth, ref Phone1, ref Phone2))
        //        return new clsPerson(PersonID, Name, Email, Address, DateOfBirth, Phone1, Phone2);

        //    else
        //        return null;
        //}

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonDataAccess.DeletePerson(PersonID);
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonDataAccess.IsPersonExist(PersonID);
        }

        public static bool IsPersonExistByPhoneNumber(string PhoneNumber)
        {
            return clsPersonDataAccess.IsPersonExisByPhoneNumber(PhoneNumber);
        }

        public static DataTable GetAllPersons()
        {
            return clsPersonDataAccess.GetAllPersons();

        }


    }
}
