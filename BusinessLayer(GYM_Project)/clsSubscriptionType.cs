using DataAccessLayer_GYM_Project_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer_GYM_Project_
{
    public class clsSubscriptionType
    {
        private enum enMode { AddNew, Update };
        enMode _Mode = enMode.AddNew;

        public int SubscriptionTypeID { set; get; }
        public string Name { set; get; }

        private bool _AddSubscriptionType()
        {
            if(this.Name !="")
            {
               this.SubscriptionTypeID = clsSubscriptionTypeDataAccess.AddNewSubscriptionType(this.Name);
                return (this.SubscriptionTypeID != 0);
            }
            return false;
        }
        private bool _UpdateSubscriptionType()
        {
            if (this.Name != "")
            {
                return clsSubscriptionTypeDataAccess.UpdateSubscriptionType(this.SubscriptionTypeID,this.Name);

            }
            return false;
        }
        public clsSubscriptionType()
        {

            this.SubscriptionTypeID = -1;
            this.Name = "";

            _Mode = enMode.AddNew;
        }

        private clsSubscriptionType(int SubscriptionTypeID, string SubscriptionName)
        {
            this.SubscriptionTypeID = SubscriptionTypeID;
            this.Name = SubscriptionName;
            _Mode = enMode.Update;
        }

        public static clsSubscriptionType Find(int SubscriptionTypeID)
        {
            string SubscriptionName = "";


            if (clsSubscriptionTypeDataAccess.GetSubscriptionTypeInfoByID(ref SubscriptionTypeID, ref SubscriptionName))
                return new clsSubscriptionType(SubscriptionTypeID, SubscriptionName);

            else
                return null;

        }

        public static clsSubscriptionType Find(string SubscriptionTypeName)
        {
            int SubscriptionTypeID = 0;


            if (clsSubscriptionTypeDataAccess.GetSubscriptionTypeInfoBySubscriptionName(ref SubscriptionTypeID, ref SubscriptionTypeName))
                return new clsSubscriptionType(SubscriptionTypeID, SubscriptionTypeName);

            else
                return null;

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddSubscriptionType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateSubscriptionType();

            }
            return false;
        }

        public static DataTable GetAllSubscriptionType()
        {
            return clsSubscriptionTypeDataAccess.GetAllSubscriptionTypes();

        }

        public static bool DeleteSubscriptionType(int SubscriptionTypeID)
        {
            return clsSubscriptionTypeDataAccess.DeleteSubscriptionType(SubscriptionTypeID);
        }

        public static bool IsSubscriptionTypeExist(int SubscriptionTypeID)
        {
            return clsSubscriptionTypeDataAccess.IsSubscriptionTypeExist(SubscriptionTypeID);
        }

        public static bool IsSubscriptionTypeExistByName(string Name)
        {
            return clsSubscriptionTypeDataAccess.IsSubscriptionTypeExistByName(Name);
        }



    }
}
