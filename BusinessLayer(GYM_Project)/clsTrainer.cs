using BusinessLayer_GYM_Project;
using DataAccessLayer_GYM_Project;
using DataAccessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_GYM_Project_
{
    public class clsTrainer : clsPerson
    {
        private enum enMode { AddNew, Update };
        enMode _Mode = enMode.AddNew;
        public int TrainerID { get; set; }
        public string Qualification { get; set; }
        public decimal Salary { get; set; }

        private bool _AddNewTrainer()
        {
            this.PersonID = (clsPersonDataAccess.AddNewPerson(this.Name, this.Email, this.Address, this.DateOfBirth, this.Phone1, this.Phone2));
            this.TrainerID = (clsTrainerDataAccess.AddNewTrainer(this.Qualification,this.Salary,this.PersonID));
            return (this.TrainerID != -1);
        }

        private bool _UpdateTrainer()
        {
            return (clsPersonDataAccess.UpdatePerson(this.PersonID, this.Name, this.Email, this.Address, this.DateOfBirth, this.Phone1, this.Phone2)
                && clsTrainerDataAccess.UpdateTrainer(this.TrainerID,this.Qualification,this.Salary,this.PersonID));
        }
        public clsTrainer() : base()
        {

            this.TrainerID = -1;
            this.Qualification = "";
            this.Salary = -1;

            _Mode = enMode.AddNew;
        }

        private clsTrainer(int PersonID, string Name, string Email, string Address, DateTime DateOfBirth, string Phone1, string Phone2
            , int TrainerID, string Qualification, decimal Salary)
            : base(PersonID, Name, Email, Address, DateOfBirth, Phone1, Phone2)
        {
            this.TrainerID = TrainerID;
            this.Qualification = Qualification;
            this.Salary = Salary;
            _Mode = enMode.Update;

        }

        public static clsTrainer Find(int TrainerID)
        {
            int PersonID = -1;
            string Name = "", Email = "", Address = "", Phone1 = "", Phone2 = "";
            string Qualification = "";
            DateTime DateOfBirth = DateTime.Now;
            decimal Salary = -1;

            if (clsTrainerDataAccess.GetTrainerInfoByID(ref TrainerID, ref Qualification,ref Salary, ref PersonID)
                && clsPersonDataAccess.GetPersonInfoByID(ref PersonID, ref Name, ref Email, ref Address, ref DateOfBirth, ref Phone1, ref Phone2))
                return new clsTrainer(PersonID, Name, Email, Address, DateOfBirth, Phone1, Phone2, TrainerID, Qualification,Salary);

            else
                return null;

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTrainer())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateTrainer();

            }
            return false;
        }

        public static bool DeleteTrainer(int TrainerID)
        {
            return clsTrainerDataAccess.DeleteTrainer(TrainerID);
        }

        public static bool IsTrainerExist(int TrainerID)
        {
            return clsTrainerDataAccess.IsTrainerExist(TrainerID);
        }

        public static bool IsTrainerExistByPhoneNumber(string PhoneNumber)
        {
            return clsTrainerDataAccess.IsTrainerExistByPhoneNumber(PhoneNumber);
        }



        public static DataTable GetAllTrainers()
        {
            return clsTrainerDataAccess.GetAllTraniers();
        }

        public static DataTable GetTrainerByPhoneNumber(string PhoneNumber)
        {
            return clsTrainerDataAccess.GetTranierByPhoneNumber(PhoneNumber);
        }



    }
}
