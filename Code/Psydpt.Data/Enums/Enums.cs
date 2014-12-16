using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Data.Enums
{
    public enum UserRole
    {
        Guest = 0,
        Admin = 1,
        Patient = 2
    }


    public enum Gender
    {
        Other = 0,
        Male = 1,
        Female = 2
    }


    public enum MatialStatus
    {
        Other = 0,
        Married = 1,
        Single = 2
    }


    public enum BloodType
    { 
        GroupA = 0,
        GroupB = 1,
        GroupAB = 2,
        GroupO = 3,
    }

    public enum SigeCapVariantType
    { 
        Unchanged = 0,
        Increased = 1,
        Decreased = 2
    }

    public enum SigeCapBooleanType
    {
        Yes = 0,
        No = 1
    }


}
