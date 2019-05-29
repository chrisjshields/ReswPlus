﻿/* ReswPlusLib
 * Author Rudy Huyn
 * License MIT / http://bit.ly/mit-license
 */
using ReswPlusLib.Interfaces;
using ReswPlusLib.Utils;


namespace ReswPlusLib.Providers
{
    internal class LatvianProvider: IPluralProvider
    {
        public PluralTypeEnum ComputePlural(double n)
        {
            if (n == 0 || (n % 100).IsBetween(11, 19))
            {
                return PluralTypeEnum.ZERO;
            }

            var f = n.DigitsAfterDecimal();
            if (f.IsBetween(11, 19))
                return PluralTypeEnum.ZERO;

            if (n % 10 == 1 && n % 100 != 11)
                return PluralTypeEnum.ONE;
            if (f % 10 == 1)
            {
                if (n.GetNumberOfDigitsAfterDecimal() == 2)
                {
                    if (f % 100 != 11)
                        return PluralTypeEnum.ONE;
                }
                else
                {
                    return PluralTypeEnum.ONE;
                }
            }
            return PluralTypeEnum.OTHER;
        }
    }
}
