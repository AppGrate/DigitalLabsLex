using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalConverterLex.BusinessLayer.Strategy
{
    public enum NumberType
    {
        BASE2 = 2,
        BASE3 = 3,
        BASE4 = 4,
        BASE5 = 5,
        BASE6 = 6,
        BASE7 = 7,
        BASE8 = 8,
        BASE9 = 9,
        BASE10 = 10,
        BASE11 = 11,
        BASE12 = 12,
        BASE13 = 13,
        BASE14 = 14,
        BASE15 = 15,
        BASE16 = 16,

        BCD,
        EXCESS3,
        COMPLEMENT1,
        COMPLEMENT2,
        COMPLEMENT9,
        COMPLEMENT10,

        NULL
    }
}
