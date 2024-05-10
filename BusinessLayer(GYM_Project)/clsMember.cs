using BusinessLayer_GYM_Project;
using DataAccessLayer_GYM_Project;
using DataAccessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer_GYM_Project_
{
    public class clsMember : clsPerson
    {
        private enum enMode {AddNew,Update};
        enMode _Mode = enMode.AddNew;
        public int MemberID { get; set; }
        public bool IsActive { get; set; }



        private bool _AddNewMember()
        {
            this.PersonID = (clsPersonDataAccess.AddNewPerson(this.Name,this.Email,this.Address,this.DateOfBirth,this.Phone1,this.Phone2));
            this.MemberID = (clsMembersDataAccess.AddNewMember(this.IsActive,this.PersonID));
            return (this.MemberID != -1);
        }

        private bool _UpdateMember()
        {
            return (clsPersonDataAccess.UpdatePerson(this.PersonID, this.Name, this.Email, this.Address, this.DateOfBirth, this.Phone1, this.Phone2)
                && clsMembersDataAccess.UpdateMember(this.MemberID, this.IsActive, this.PersonID)); 
        }

        public clsMember():base()
        {
            
            this.MemberID = -1;
            this.IsActive = false;

            _Mode = enMode.AddNew;
        }

        private clsMember(int PersonID, string Name, string Email, string Address, DateTime DateOfBirth, string Phone1, string Phone2
            ,int MemberID,bool IsActive)
            :base(PersonID, Name,Email,Address,DateOfBirth,Phone1,Phone2)
        {
            this.MemberID = MemberID;
            this.IsActive = IsActive;

            _Mode = enMode.Update;

        }



        public static clsMember Find(int MemberId)
        {
            int PersonID = -1;
            string Name = "", Email = "", Address = "", Phone1 = "", Phone2 = "";
            bool IsActive = false;
            DateTime DateOfBirth = DateTime.Now;

            if (clsMembersDataAccess.GetMemberInfoByID(ref MemberId,ref IsActive,ref PersonID)
                && clsPersonDataAccess.GetPersonInfoByID(ref PersonID,ref Name,ref Email,ref Address,ref DateOfBirth,ref Phone1,ref Phone2))
                return new clsMember(PersonID, Name, Email, Address, DateOfBirth, Phone1, Phone2, MemberId, IsActive);

            else
                return null;

        }

        public static clsMember FindByPhoneNumber(string Phone1)
        {
            int PersonID = -1, MemberId=-1;
            string Name = "", Email = "", Address = "", Phone2 = "";
            bool IsActive = false;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPersonDataAccess.GetPersonInfoByPhoneNumber(ref PersonID, ref Name, ref Email, ref Address, ref DateOfBirth, ref Phone1, ref Phone2)
                && clsMembersDataAccess.GetMemberInfoByPersonID(ref MemberId, ref IsActive, ref PersonID))
                
                return new clsMember(PersonID, Name, Email, Address, DateOfBirth, Phone1, Phone2, MemberId, IsActive);

            else
                return null;

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMember())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateMember();

            }
            return false;
        }

        public static bool DeleteMember(int MemberId)
        {
            return clsMembersDataAccess.DeleteMember(MemberId);
        }

        public static bool IsMemberExist(int MemberId)
        {
            return clsMembersDataAccess.IsMemberExist(MemberId);
        }

        public static bool IsMemberExistByPhoneNumber(string PhoneNumber)
        {
            return clsPersonDataAccess.IsPersonExisByPhoneNumber(PhoneNumber);
        }

        public static DataTable GetAllMembers()
        {
            return clsMembersDataAccess.GetAllMembers();
        }

        public static DataTable SearchByMemberID(int MemberID)
        {
            return clsMembersDataAccess.SearchByMemberID(MemberID);
        }

        public static DataTable GetMemberByPhoneNumber(string PhoneNumber)
        {
            return clsMembersDataAccess.GetMemberByPhoneNumber(PhoneNumber);
        }






    }
}
