using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAbuse.OSRSObjects
{
    public class OSRSItemInformation
    {
        public string Name { get; set; }
        public string ExamineText { get; set; }
        public uint Id { get; set; }
        public bool MembersOnly { get; set; }
        public uint HighAlchAmount { get; set; }
        public uint LowAlchAmount { get; set; }
        public uint Value { get; set; }
        public uint BuyLimit { get; set; }
        public string IconName { get; set; }
    }
}
