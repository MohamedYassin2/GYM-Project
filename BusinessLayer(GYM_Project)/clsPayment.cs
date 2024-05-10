using DataAccessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_GYM_Project_
{
    public class clsPayment
    {
        private enum enMode { AddNew, Update };
        enMode _Mode = enMode.AddNew;

        public int PaymentID { set; get; }
        public decimal Amount { set; get; }
        public DateTime PaymentDate { set; get; }
        public int MemberID { set; get; }

        private bool _AddNewPayment()
        {
            if(clsMember.IsMemberExist(this.MemberID) && this.Amount >=0)
            {
                this.PaymentID = clsPaymentDataAccess.AddNewPayment(this.Amount, this.PaymentDate, this.MemberID);
                return (PaymentID != 0);
            }
            return false;
        }

        private bool _UpdatePayment()
        {
            if (clsMember.IsMemberExist(this.MemberID) && this.Amount >= 0)
            {
                return clsPaymentDataAccess.UpdatePayment(this.PaymentID,this.Amount, this.PaymentDate, this.MemberID);
                
            }
            return false;
        }


        public clsPayment()
        {

            this.PaymentID = -1;
            this.Amount = -1;
            this.PaymentDate = DateTime.Now;
            this.MemberID = -1;

            _Mode = enMode.AddNew;
        }

        private clsPayment(int PaymentID, decimal Amount, DateTime PaymentDate, int MemberID)
        {
            this.PaymentID = PaymentID;
            this.Amount = Amount;
            this.PaymentDate = PaymentDate;
            this.MemberID = MemberID;
            _Mode = enMode.Update;
        }

        public static clsPayment Find(int PaymentID)
        {
            decimal Amount = -1;
            DateTime PaymentDate = DateTime.Now;
            int MemberID = -1;


            if (clsPaymentDataAccess.GetPaymentInfoByID(ref PaymentID, ref Amount, ref PaymentDate, ref MemberID))
                return new clsPayment(PaymentID, Amount, PaymentDate, MemberID);

            else
                return null;

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePayment();

            }
            return false;
        }


        public static DataTable GetAllPayments()
        {
            return clsPaymentDataAccess.GetAllPayments();

        }

        public static DataTable GetPaymentByPhoneNumber(string PhoneNumber)
        {
            return clsPaymentDataAccess.GetPaymentByPhoneNumber(PhoneNumber);

        }

        public static bool DeletePayment(int PaymentID)
        {
            return clsPaymentDataAccess.DeletePayment(PaymentID);
        }

        public static bool IsPaymentExist(int PaymentID)
        {
            return clsPaymentDataAccess.IsPaymentExist(PaymentID);
        }

        public static bool IsMemberHasPayment(int MemberID)
        {
            return clsPaymentDataAccess.IsMemberHasPayment(MemberID);
        }









    }
}