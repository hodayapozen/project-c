using System;
using System.Collections.Generic;
using System.Security;
using System.Text;


namespace BE
{
    [Serializable]
    public class Tester
    {

        private DateTime testerDatecBirth = DateTime.Now.AddYears(-40);
        public string TesterId { get; set; }
        public string TesterLastName { get; set; }
        public string TesterFirstName { get; set; }
        public DateTime TesterDateBirth
        {
            get
            {
                return testerDatecBirth;
            }
            set {
                testerDatecBirth = value;
            }
        }
        public EnumClass.Gender TesterGender { get; set; }
        public string TesterPhoneNumber { get; set; }
        public StructClass.Adress TesterAdress { get; set; }
        public int TesterYearsExperience { get; set; }
        public int TesterMaxTest { get; set; }
        public EnumClass.CarType TesterCarType { get; set; }
        public EnumClass.GearboxType TesterGearboxType { get; set; }
        public double TesterMaxDistance { get; set; }
      
        public bool[,] TesterWorkHours { get; set; }

        public Tester()
        {
            TesterWorkHours = new bool[5, 6];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    TesterWorkHours[i, j] = false;
                }

            }

        }


        public Tester(Tester tester)
        {

            TesterId = tester.TesterId;
            TesterLastName = tester.TesterLastName;
            TesterFirstName = tester.TesterFirstName;
            TesterDateBirth = tester.TesterDateBirth;
            TesterGender = tester.TesterGender;
            TesterPhoneNumber = tester.TesterPhoneNumber;

            TesterYearsExperience = tester.TesterYearsExperience;
            TesterMaxTest = tester.TesterMaxTest;
            TesterCarType = tester.TesterCarType;
            TesterGearboxType = tester.TesterGearboxType;
            TesterMaxDistance = tester.TesterMaxDistance;
            TesterWorkHours = tester.TesterWorkHours;
        }

        public Tester(string testerId, string testerLastName, string testerFirstName, DateTime testerDateBirth, EnumClass.Gender testerGender, string testerPhoneNumber,  int testerYearsExperience, int testerMaxTest, EnumClass.CarType testerCarType, EnumClass.GearboxType testerGearboxType, double testerMaxDistance,bool [,] testerWorkHours)
        {
            TesterId = testerId;
            TesterLastName = testerLastName;
            TesterFirstName = testerFirstName;
            TesterDateBirth = testerDateBirth;
            TesterGender = testerGender;
            TesterPhoneNumber = testerPhoneNumber;
       
            TesterYearsExperience = testerYearsExperience;
            TesterMaxTest = testerMaxTest;
            TesterCarType = testerCarType;
            TesterGearboxType = testerGearboxType;
            TesterMaxDistance = testerMaxDistance;
            TesterWorkHours = testerWorkHours;

        }

      
        public override string ToString()
        {
            return TesterFirstName + " " + TesterLastName + " " + TesterId + "\nphone number: " + TesterPhoneNumber +
                "\naddress: " + TesterAdress + "\nYearsExperience: " + TesterYearsExperience + "/n";
        }

        public Tester GetCopy()
        {
            return (Tester)this.MemberwiseClone();
        }
    }}