using DataAccessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_GYM_Project_
{
    public class clsMemberTrainer
    {
        private enum enMode { AddNew, Update };
        enMode _Mode = enMode.AddNew;
        public int MemberID { get; set; }
        public int TrainerID { get; set; }
        public DateTime AssignDate { get; set; }

        private bool _AddNewRecordInMemberTranier()
        {
            if (this.MemberID <= 0 || this.TrainerID <= 0)
                return false;
            else
            {
                return clsMemberTranierDataAccess.AddNewRecordInMemberTranierTable(this.MemberID, this.TrainerID, this.AssignDate);
                
            }
            
        }

        private bool _UpdateRecordInMemberTranier()
        {
            if (this.MemberID <= 0 || this.TrainerID <=0)
                return false;
            else
            {
                return clsMemberTranierDataAccess.AddNewRecordInMemberTranierTable(this.MemberID, this.TrainerID, this.AssignDate);
            }
        }
        public clsMemberTrainer()
        {
            MemberID = -1;
            TrainerID = -1;
            AssignDate = DateTime.Now;
            _Mode = enMode.AddNew;
        }

        private clsMemberTrainer( int memberID, int trainerID, DateTime assginDate)
        {
;           this.MemberID = memberID;
            this.TrainerID = trainerID;
            this.AssignDate = assginDate;
            _Mode = enMode.Update;

        }
        public static clsMemberTrainer Find(int MemberID)
        {
            int TrainerID = -1;
            DateTime AssignDate = DateTime.Now;

            if (clsMemberTranierDataAccess.GetRecordFromMemberTrainersByID(ref MemberID, ref TrainerID, ref AssignDate))
                return new clsMemberTrainer(MemberID, TrainerID, AssignDate);
            else
                return null;

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRecordInMemberTranier())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateRecordInMemberTranier();

            }
            return false;
        }

        public static bool DeleteRecordInMemberTranierTable(int MemberID,int TrainerID)
        {
            return clsMemberTranierDataAccess.DeleteRecordInMemberTranierTable(MemberID,TrainerID);
        }

        public static bool IsRecordMemberTranierExist(int MemberID,int TrainerID)
        {
            return clsMemberTranierDataAccess.IsRecordMemberTranierExist(MemberID,TrainerID);
        }

        public static DataTable GetAllMemberTranierRecords()
        {
            return clsMemberTranierDataAccess.GetAllMemberTranierRecords();
        }

        public static bool IsMemberHasTrainers(int MemberID)
        {
            return clsMemberTranierDataAccess.IsMemberHasTrainers(MemberID);
        }

        public static bool IsTrainerTeachMembers(int TrainerID)
        {
            return clsMemberTranierDataAccess.IsTrainerTeachMembers(TrainerID);
        }




    }
}
