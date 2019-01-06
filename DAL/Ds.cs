using System;
using System.Collections.Generic;
using System.Text;
using BE;


namespace DAL
{
   public  class Ds
    {
        public static List<Tester> tester;
        public static List<Test> test;
        public static List<Trainee> trainee;

        static Ds()
        {
            tester = new List<Tester>();
            test = new List<Test>();
            trainee = new List<Trainee>();
            CreateDemoEntites();
            //Tester tester2 = new Tester("025395633", "Chen", "Tamar", new DateTime(1966, 4, 10), EnumClass.Gender.male, "055678945", 15, 10, EnumClass.CarType.Private, EnumClass.GearboxType.Manual, 100);
            //int[] days = { 1, 3 };
            //bool[,] testerWorkHours = Configuration.MatrixInitialization(10, 15, days);
            //tester.Add(new Tester
            //{
            //    TesterId = "209303999",
            //    TesterLastName = "Levi",
            //    TesterFirstName = "Amit",
            //    TesterDateBirth = (DateTime.Parse("10-121970")),
            //    TesterGender = EnumClass.Gender.male,
            //    TesterPhoneNumber = "0523121155",
            //    TesterAdress = new StructClass.Adress { street = "Herzel", numberHouse = 20, city = "Tel Aviv" },
            //    TesterYearsExperience = 14,
            //    TesterMaxTest = 10,
            //    TesterCarType = EnumClass.CarType.Private,
            //    TesterGearboxType = EnumClass.GearboxType.Automatic,
            //    TesterMaxDistance = 60,

            //    TesterWorkHours = testerWorkHours
            //});
            //initValues();

        }

        private static void CreateDemoEntites()
        {
            //int[] days = { 1, 3 };
            bool[,] testerWorkHours = new bool[5, 6];
            testerWorkHours = new bool[5, 6];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    testerWorkHours[i, j] = false;
                }

            }
            testerWorkHours[0, 0] = true;
            Tester tester2 = new Tester("025395633", "Chen", "Tamar", new DateTime(1966, 4, 10), EnumClass.Gender.male, "055678945", 15, 10, EnumClass.CarType.Private, EnumClass.GearboxType.Manual, 100, testerWorkHours);
            Tester tester1 = new Tester("025395631", "Chen", "Tamar", new DateTime(1966, 4, 10), EnumClass.Gender.male, "055678945", 15, 10, EnumClass.CarType.Private, EnumClass.GearboxType.Manual, 100, testerWorkHours);
            
            tester.Add(tester2);
            tester.Add(tester1);
            //Trainee trainee1 = new Trainee
            //{
            //    TraineeId = "206666666",
            //    TraineeFirstName = "CHedva",
            //    TraineeLastName = "Edry",
            //    TraineeGender = (EnumClass.Gender)1,
            //    TraineeDateBirth = (DateTime.Parse("20.4.1998")),
            //    TraineePhoneNumber = "0544444477",
            //    TraineeAdress = new StructClass.Adress { street = "Pinsker", numberHouse = 3, city = "Haifa" },
            //    TraineeCarType = (EnumClass.CarType)2,
            //    TraineeGearboxType = (EnumClass.GearboxType)0,
            //    TraineeDrivingSchool = "Loo",
            //    TraineeDrivingTeacher = "Lea ",
            //    TraineeNumberOfLessonsDriving = 22,
            //    TraineePreferredGenderOfTester = (EnumClass.Gender)1
            //};
            //Trainee trainee2 = new Trainee
            //{
            //    TraineeId = "205686616",
            //    TraineeFirstName = "Hodaya",
            //    TraineeLastName = "Pozen",
            //    TraineeGender = (EnumClass.Gender)0,
            //    TraineeDateBirth = (DateTime.Parse("10.12.1997")),

            //    TraineePhoneNumber = "0586669898",
            //    TraineeAdress = new StructClass.Adress { street = "Gordon", numberHouse = 5, city = "Tel Aviv" },
            //    TraineeCarType = (EnumClass.CarType)0,
            //    TraineeGearboxType = (EnumClass.GearboxType)0,
            //    TraineeDrivingSchool = "Rss",
            //    TraineeDrivingTeacher = "Shron",
            //    TraineeNumberOfLessonsDriving = 25,
            //    TraineePreferredGenderOfTester = (EnumClass.Gender)0,
            //};
            //Trainee trainee3 = new Trainee
            //{
            //    TraineeId = "313152547",
            //    TraineeFirstName = "David",
            //    TraineeLastName = "Lev",
            //    TraineeGender = (EnumClass.Gender)0,
            //    TraineeDateBirth = (DateTime.Parse("6.1.1990")),

            //    TraineePhoneNumber = "0586669898",
            //    TraineeAdress = new StructClass.Adress { street = "Yam", numberHouse = 5, city = "Rishon Lezion" },
            //    TraineeCarType = (EnumClass.CarType)0,
            //    TraineeGearboxType = (EnumClass.GearboxType)0,
            //    TraineeDrivingSchool = "Rss",
            //    TraineeDrivingTeacher = "Shron",
            //    TraineeNumberOfLessonsDriving = 31,
            //    TraineePreferredGenderOfTester = (EnumClass.Gender)0,
            //};
            //Test test1 = new Test
            //{

            //    TestTesterId = "025395633",
            //    TestTraineeId = "313152547",
            //    TestData = (DateTime.Parse("24.8.2018")),

            //    TestDataTime = (DateTime.Parse("24.8.2018.13:00")),
            //    TestExitAddress = new StructClass.Adress { street = "Hyarden", numberHouse = 20, city = "Haifa" }

            //};
            //Test test2 = new Test
            //{

            //    TestTesterId = "025395633",
            //    TestTraineeId = "209854587",
            //    TestData = (DateTime.Parse("25.8.2018")),

            //    TestDataTime = (DateTime.Parse("25.8.2018.13:00")),

            //};
            //Test test3 = new Test
            //{

            //    TestTesterId = "204487474",
            //    TestTraineeId = "313198544",
            //    TestData = (DateTime.Parse("25.8.2018")),

            //    TestDataTime = (DateTime.Parse("25.8.2018.13:00")),
            //    TestExitAddress = new StructClass.Adress { street = "Hyarden", numberHouse = 20, city = "Haifa" }

            //};
        }
    }
}

