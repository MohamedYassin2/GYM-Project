using BusinessLayer_GYM_Project;
using DataAccessLayer_GYM_Project;
using DataAccessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_GYM_Project_
{
    public class clsUser :clsPerson
    {
        private enum enMode { AddNew, Update };
        enMode _Mode = enMode.AddNew;

        public enum enPermission {All = -1, Members=1,Trainers=2,Users=4,Subscription=8,Payments=16,SubscriptionType=32,MemberTrainer=64};
        enPermission Per;

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public int Permission { get; set; }
        public decimal Salary { get; set; }

        private bool _AddNewUser()
        {
            this.PersonID = (clsPersonDataAccess.AddNewPerson(this.Name, this.Email, this.Address, this.DateOfBirth, this.Phone1, this.Phone2));
            this.UserID = (clsUserDataAccess.AddNewUser(this.UserName, this.PassWord, this.Permission,this.Salary,PersonID));
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return (clsPersonDataAccess.UpdatePerson(this.PersonID, this.Name, this.Email, this.Address, this.DateOfBirth, this.Phone1, this.Phone2)
                && clsUserDataAccess.UpdateUser(this.UserID, this.UserName, this.PassWord, this.Permission, this.Salary, this.PersonID));
        }
        public clsUser() : base()
        {

            this.UserID = -1;
            this.UserName = "";
            this.PassWord = "";
            this.Permission = -2;
            this.Salary = -1;

            _Mode = enMode.AddNew;
        }

        private clsUser(int PersonID, string Name, string Email, string Address, DateTime DateOfBirth, string Phone1, string Phone2
            , int UserID, string UserName,string PassWord,int Permission, decimal Salary)
            : base(PersonID, Name, Email, Address, DateOfBirth, Phone1, Phone2)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.PassWord = PassWord;
            this.Permission = Permission;
            this.Salary = Salary;

            _Mode = enMode.Update;

        }

        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string Name = "", Email = "", Address = "", Phone1 = "", Phone2 = "";
            DateTime DateOfBirth = DateTime.Now;
             int Permission = -2;
            string UserName = "", Password = "";
            decimal Salary = -1;

            if (clsUserDataAccess.GetUserInfoByID(ref UserID,ref UserName,ref Password, ref Permission,ref Salary,ref PersonID)
                && clsPersonDataAccess.GetPersonInfoByID(ref PersonID, ref Name, ref Email, ref Address, ref DateOfBirth, ref Phone1, ref Phone2))
                return new clsUser(PersonID, Name, Email, Address, DateOfBirth, Phone1, Phone2,UserID,UserName,Password,Permission,Salary);

            else
                return null;

        }

        public static clsUser Find(string UserName,string Password)
        {
            int PersonID = -1,UserID=-1;
            string Name = "", Email = "", Address = "", Phone1 = "", Phone2 = "";
            DateTime DateOfBirth = DateTime.Now;
            int Permission = -2;
            decimal Salary = -1;

            if (clsUserDataAccess.GetUserInfoByUserNameAndPassword(ref UserID, ref UserName, ref Password, ref Permission, ref Salary, ref PersonID)
                && clsPersonDataAccess.GetPersonInfoByID(ref PersonID, ref Name, ref Email, ref Address, ref DateOfBirth, ref Phone1, ref Phone2))
                return new clsUser(PersonID, Name, Email, Address, DateOfBirth, Phone1, Phone2, UserID, UserName, Password, Permission, Salary);

            else
                return null;

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();

            }
            return false;
        }

        public static bool DeleteUser(int UserID)
        {
           return clsUserDataAccess.DeleteUser(UserID);
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUserDataAccess.IsUserExist(UserID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

        public static DataTable GetUserByPhoneNumber(string PhoneNumber)
        {
            return clsUserDataAccess.GetUserByPhoneNumber(PhoneNumber);
        }

        public bool CheckAccessPermission(enPermission Permission)
        {
            if (this.Permission == (int)enPermission.All)
                return true;
            if ((Convert.ToInt32(Permission) & this.Permission) == Convert.ToInt32(Permission))
                return true;
            else
                return false;
        }



    }
}
