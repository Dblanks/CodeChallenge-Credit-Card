using CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    public class _CreditCard
    {
        public double Balance { get; set; }
    }

    public class VisaCard
    {
        public const double INTEREST = 0.10;
    }

    public class MasterCard
    {
        public const double INTEREST = 0.05;
    }

    public class DiscoverCard
    {
        public const double INTEREST = 0.01;
    }
}
