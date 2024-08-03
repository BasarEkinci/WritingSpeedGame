using System;
using System.Collections.Generic;

namespace Data.ValueObjects
{
    [Serializable]
    public struct WordBank
    {
        public List<string> turkishWords;
        public List<string> englishWords;
    }
}
