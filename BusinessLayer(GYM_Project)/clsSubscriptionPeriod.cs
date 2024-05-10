using DataAccessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_GYM_Project_
{
    public class clsSubscriptionPeriod
    {
        private enum enMode { AddNew, Update };
        enMode _Mode = enMode.AddNew;

        public int PeriodID             { set; get; }
        public DateTime StartDate       { set; get; }
        public DateTime EndDate             { set; get; }
        public int Fees                  { set; get; }
        public int MemberID                 { set; get; }
        public int PaymentID            { set; get; }
        public int SubscriptionTypeID    { set; get; }

        private bool _AddSubscriptionPeriod()
        {
            if (clsMember.IsMemberExist(this.MemberID) && this.Fees >= 0 && clsPayment.IsPaymentExist(this.PaymentID) && clsSubscriptionType.IsSubscriptionTypeExist(this.SubscriptionTypeID) )
            {
                this.PeriodID = clsSubscriptionPeriodDataAccess.AddNewSubscriptionPeriod(this.StartDate,this.EndDate,this.Fees,this.MemberID,this.PaymentID,this.SubscriptionTypeID);
                return (PeriodID != 0);
            }
            return false;
        }

        private bool _UpdateSubscriptionPeriod()
        {
            if (clsMember.IsMemberExist(this.MemberID) && this.Fees >= 0 && clsPayment.IsPaymentExist(this.PaymentID) && clsSubscriptionType.IsSubscriptionTypeExist(this.SubscriptionTypeID))
            {
                return clsSubscriptionPeriodDataAccess.UpdateSubscriptionPeriod(this.PeriodID,this.StartDate,this.EndDate,this.Fees,this.MemberID,this.PaymentID,this.SubscriptionTypeID);

            }
            return false;
        }


        public clsSubscriptionPeriod()
        {

            this.PeriodID = -1;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.Fees = -1;
            this.MemberID = -1;
            this.PaymentID = -1;
            this.SubscriptionTypeID = -1;


            _Mode = enMode.AddNew;
        }

        private clsSubscriptionPeriod(int PeriodID,DateTime StartDate,DateTime EndDate,int Fees ,int MemberID,int PaymentID,int SubscriptionTypeID )
        {
            this.PeriodID = PeriodID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Fees = Fees;
            this.MemberID = MemberID;
            this.PaymentID = PaymentID;
            this.SubscriptionTypeID = SubscriptionTypeID;

            _Mode = enMode.Update;

        }


        public static clsSubscriptionPeriod Find(int PeriodID)
        {
            DateTime StartDate=DateTime.Now, EndDate = DateTime.Now;
            int Fees=-1, MemberID=-1,PaymentID=-1, SubscriptionTypeID=-1;

            if (clsSubscriptionPeriodDataAccess.GetSubscriptionPeriodInfoByID(ref PeriodID,ref StartDate,ref EndDate,ref Fees,ref MemberID,ref PaymentID,ref SubscriptionTypeID))
                return new clsSubscriptionPeriod(PeriodID,StartDate,EndDate,Fees,MemberID,PaymentID,SubscriptionTypeID);

            else
                return null;

        }

        public static clsSubscriptionPeriod FindByPaymentID(int PaymentID)
        {
            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;
            int Fees = -1, MemberID = -1, PeriodID = -1, SubscriptionTypeID = -1;

            if (clsSubscriptionPeriodDataAccess.GetSubscriptionPeriodInfoByPaymentID(ref PeriodID, ref StartDate, ref EndDate, ref Fees, ref MemberID, ref PaymentID, ref SubscriptionTypeID))
                return new clsSubscriptionPeriod(PeriodID, StartDate, EndDate, Fees, MemberID, PaymentID, SubscriptionTypeID);

            else
                return null;

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddSubscriptionPeriod())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateSubscriptionPeriod();

            }
            return false;
        }

        public static DataTable GetSubscriptionPeriods()
        {
            return clsSubscriptionPeriodDataAccess.GetAllSubscriptionPeriods();

        }

        public static bool DeleteSubscriptionPeriod(int PeriodID)
        {
            return clsSubscriptionPeriodDataAccess.DeleteSubscriptionPeriod(PeriodID);
        }

        public static bool DeleteSubscriptionPeriodByPaymentID(int PaymentID)
        {
            return clsSubscriptionPeriodDataAccess.DeleteSubscriptionPeriodByPaymentID(PaymentID);
        }

        public static bool IsSubscriptionPeriodExist(int PeriodID)
        {
            return clsSubscriptionPeriodDataAccess.IsSubscriptionPeriodExist(PeriodID);
        }

        public static bool IsMemberHasSubscription(int MemberID)
        {
            return clsSubscriptionPeriodDataAccess.IsMemberHasSubscription(MemberID);
        }

        public static DataTable GetSubscriptionPeriodByMemberID(int MemberID)
        {
            return clsSubscriptionPeriodDataAccess.GetSubscriptionPeriodByMemberID(MemberID);

        }

    }
}
