using System;
using System.Numerics;

namespace RSA.symbols
{
    public class Symbols
    {
        public BigInteger GetJacobi(BigInteger a, BigInteger p)
        {
            if (BigInteger.GreatestCommonDivisor(a, p) != 1)
                return (0);
            int r = 1;
            
            if (a < 0)
            {
                a = (-1) * a;
                if (p % 4 == 3)
                    r = (-1) * r;
            }

            do
            {
                int t = 0;
                while (a % 2 == 0)
                {
                    t += 1;
                    a = a / 2;
                }

                if (t % 2 == 1)
                {
                    if (p % 8 == 3 || p % 8 == 5)
                        r = (-1) * r;
                }

                if (a % 4 == 3 || p % 4 == 3)
                {
                    r = (-1) * r;
                }
                
                var c = a;
                a = p % c;
                p = c;
                
            } while (a != 0) ;
            
            return (r);
        }

        // public BigInteger GetLegendra(BigInteger a, BigInteger p)
        // {
        //     
        // }
    }
}