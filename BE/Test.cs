using System;
using System.Collections.Generic;
using System.Text;


namespace BE
{

    public class Test : IComparable
    {

        public int TestId { get; set; }
        public string TestTesterId { get; set; }
        public string TestTraineeId { get; set; }
        public DateTime TestData
        {
            get
            {
                return TestData.Date;
            }
            set
            {
                TestData = value.Date;
            }
        }
        public DateTime TestDataTime { get; set; }
        public StructClass.Adress TestExitAddress { get; set; }
        public EnumClass.Score TestKeepDistance { get; set; }
        public EnumClass.Score TestParking { get; set; }
        public EnumClass.Score TestUsingMirrors { get; set; }
        public EnumClass.Score TestSignals { get; set; }
        public EnumClass.Score TestPayAttentyonForSignpost { get; set; }
        public EnumClass.Score TestSpeed { get; set; }
        public EnumClass.Score TestFinalScore { get; set; }
        public string TestNotesTester { get; set; }
        public EnumClass.CarType TestType { get; set; }
        public Test()
        {
        }

        public Test(Test test)
        {


        }

        public int CompareTo(object obj)
        {
            return TestDataTime.CompareTo(obj);
        }
    }

}

