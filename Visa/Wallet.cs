using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    public class Wallet
    {
        public double Value { get; private set; } //total simple interest

        public bool IsVisaCardHolder { get; set; }
        public bool IsDiscoverCardHolder { get; set; }
        public bool IsMasterCardHolder { get; set; }

        public double VisaSimpleInterest { get; private set; } //visa si
        public double MasterSimpleInterest { get; private set; } // master si
        public double DiscoverSimpleInterest { get; private set; } //discover si

        public int NumOfVisaCards { get; set; }
        public int NumOfMasterCards { get; set; }
        public int NumOfDiscoverCards { get; set; }

        public void CalculateSimpleInterest(Person p, _CreditCard cc)
        {
            if (IsVisaCardHolder) //conditional check if person is a visa card holder
            {
                Value += cc.Balance * VisaCard.INTEREST;
            }

            if (IsMasterCardHolder)  //conditional check if person is a master card holder
            {
                if (NumOfMasterCards == 2)
                {
                    Value += cc.Balance * (MasterCard.INTEREST * NumOfMasterCards);
                }
                else
                {
                    Value += cc.Balance * MasterCard.INTEREST;
                }
            }

            if (IsDiscoverCardHolder)  //conditional check if person is a discover card holder
            {
                Value += cc.Balance * DiscoverCard.INTEREST;
            }
        }


        /*Individual checks for each cards Simple Interest*/

        public void CalculateSimpleInterestVisa(Person p, _CreditCard cc)
        {
            if (IsVisaCardHolder)
            {
                VisaSimpleInterest += cc.Balance * VisaCard.INTEREST;
            }
        }

        public void CalculateSimpleInterestMasterCard(Person p, _CreditCard cc)
        {
            if (IsMasterCardHolder)
            {
                MasterSimpleInterest += cc.Balance * MasterCard.INTEREST;
            }
        }

        public void CalculateSimpleInterestDiscover(Person p, _CreditCard cc)
        {
            if (IsDiscoverCardHolder)
            {
                DiscoverSimpleInterest += cc.Balance * DiscoverCard.INTEREST;
            }
        }


    }
}
