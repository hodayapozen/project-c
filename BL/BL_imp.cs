using System;
using System.Collections.Generic;
using System.Globalization;

using BE;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Net;
using DAL;

namespace BL
{
    internal class BL_imp : IBL
    {

        DAL.Idal dal;
        public BL_imp()
        {
            dal = DAL.FactoryDAL.GetDAL();
          //  CreateDemoEntites();

        }
      
            //private static readonly BL_imp instance = new BL_imp();

            //public static BL_imp Instance
            //{
            //    get { return instance; }
            //}


            //static Idal dal;



            //private BL_imp() { }


            //static BL_imp()
            //{
            //    dal = FactoryDAL.getDAL("List");
            //}

            #region Tester Function
            public void AddTester(Tester tester)

           {
            if (tester.TesterId.Length != 9)
            {
                throw new Exception("Invalid ID");
            }
            if (Configuration.Age(tester.TesterDateBirth) < Configuration.MinAgeTester)
            {
                throw new Exception("The tester is under 40 years of age");
            }
            dal.AddTester(tester);
        }

        public void DeleteTester(string id)
        {
            dal.DeleteTester(id);
        }
        public void UpdateTester(Tester tester)
        {
            dal.UpdateTester(tester);
        }
        public Tester GetTester(string id)
        {
            if (dal.GetTester(id) == null)
            {
                throw new Exception("The tester is not exist in the system");
            }
            return dal.GetTester(id);
        }
        public List<Tester> testers()
        {
            return dal.testers();
        }
        #endregion
        #region Trainee Function
        public void AddTrainee(Trainee trainee)
        {

            //   if (dal.GetTester(trainee.TraineeId) != null)
            // {
            //   throw new Exception("The trainee is exist in the system");
            //}
            if (Configuration.Age(trainee.TraineeDateBirth) < Configuration.MinAgeTrainee)
            {
                throw new Exception("You can not add a student younger than 18 years of age");
            }
            if (!(Configuration.CheckId(trainee.TraineeId)))
            {
                throw new Exception("ID card is not valid");
            }
            if (!(Configuration.CheckPhoneNumber(trainee.TraineePhoneNumber)))
            {
                throw new Exception("Invalid phone number");
            }
            dal.AddTrainee(trainee);

        }

        public void DeleteTrainee(string id)
        {
            if (dal.GetTrainee(id) == null)
            {
                throw new Exception("The trainee is not exist in the system");
            }
            dal.DeleteTrainee(id);
        }
        public void UpdateTrainee(Trainee trainee)
        {
            if (dal.GetTester(trainee.TraineeId) == null)
            {
                throw new Exception("The trainee is not exist in the system");
            }
            dal.UpdateTrainee(trainee);
        }
        public Trainee GetTrainee(string id)
        {
            if (dal.GetTrainee(id) == null)
            {
                throw new Exception("The trainee is not exist in the system");
            }
            return dal.GetTrainee(id);
        }
        public List<Trainee> trainees()
        {
            return dal.trainees();
        }
        #endregion
        #region Test Function
        public void AddTest(Test test)
        {
            if (GetTrainee(test.TestTesterId) == null)
            {
                throw new Exception("The trainee does not exist in the system");
            }
            if (GetTrainee(test.TestTesterId).TraineeNumberOfLessonsDriving < 20)///בדיקה שהנבחן עשה לפחות 20 שיעורי נהיגה
            {
                throw new Exception("Unable to access the test should have at least 20 driving lessons");
            }

            IEnumerable<Test> tests = DAL.Ds.test.Where(L => L.TestTraineeId == test.TestTraineeId);///רשימה של כל הטסטים שהנבחן עשה כדי לבדוק האם הוא נבחן בטווח של 7 ימים
            foreach (Test t in tests)
            {
                if ((test.TestData - t.TestData).TotalDays <= 7)
                {
                    throw new Exception(" You can not add a test within 7 days of the previous test");
                }
            }
            foreach (Test t in tests)
            {
                if (t.TestType == test.TestType && t.TestFinalScore == EnumClass.Score.passes)
                {
                    throw new Exception("There is no way to reexamine the type of vehicle you have already passed the test");
                }
            }

            List<Tester> testers = new List<Tester>();
            testers = TesterFree(test.TestDataTime);///רשימה שמכילה את כל הטסטים שפנויים בתאריך המבוקש
            foreach (Tester t in testers)///בדיקה עבור כל בוחן אם עבר את מכסת השיעורים שלו לאותו שבוע או שאינו מתמחה באותו סוג רכב  תסיר אותו מהרשימה
            {
                IEnumerable<Test> tests2 = DAL.Ds.test.Where(L => Configuration.DatesAreInTheSameWeek(L.TestDataTime, test.TestDataTime));
                if (tests2.Count() >= t.TesterMaxTest || t.TesterCarType != test.TestType)
                    testers.Remove(t);
            }
            if (testers.Count == 0)///אם הרשימה ריקה זה אומר לא נשאר שום בוחן שמתאים לתאריך
            {
                throw new Exception("There is no free examiner at the requested time and enter another time");
            }
          //  IEnumerable<Tester> tester = testers.Where(L => L.TesterGender == GetTrainee(test.TestTraineeId).TraineePreferredGenderOfTester);

            //if (!(tester.Count() == 0))///אם יש  בוחן מהמין המועדף תבחר אותו ותעדכן תנתונים
            //{

            //    test.TestTesterId = testers.First().TesterId;

            //}
            else
            {
                test.TestTesterId = testers.First().TesterId;

            }

        }
        public void UpdateTest(Test test)
        {
            int help = test.TestId;

            Test test1 = GetTest(help);
            if (test1 == null)
            {
                throw new Exception("Test with this id doesn't exists");
            }
            dal.UpdateTest(test);
        }
        public Test GetTest(int id)
        {
            if (dal.GetTest(id) == null)
            {
                throw new Exception("The tester is not exist in the system");
            }
            return dal.GetTest(id);
        }
        public List<Test> tests()
        {
            return dal.tests();
        }

        #endregion

        public List<Tester> TesterDistance_X(StructClass.Adress adress)
        {
            int d = Configuration.Distance.Next(0, 480);
            IEnumerable<Tester> testers = DAL.Ds.tester.Where(t => Configuration.DistanceRandom(t.TesterAdress.ToString(), adress.ToString()) <= d);
            return testers.ToList();


        }

        public List<Tester> TesterFree(DateTime dateTime)
        {
            if (dateTime.Hour > 2 || dateTime.Hour < 9 || (int)dateTime.DayOfWeek == 6 || (int)dateTime.DayOfWeek == 7)///בודק אם השעה/היום המבוקש טווח זמני העבודה
            {
                throw new Exception("There are no tests at the requested time");
            }
            IEnumerable<Tester> tester = DAL.Ds.tester.Where(l => l.TesterWorkHours[dateTime.Hour, (int)dateTime.DayOfWeek] == true);///רשימה של כל הבוחנים שעובדים בשעה המבוקשת
            foreach (Tester t in tester)
            {
                IEnumerable<Test> test = DAL.Ds.test.Where(l => l.TestTesterId == t.TesterId);
                foreach (Test T in test)
                {
                    if (T.TestDataTime == dateTime)
                    {
                        tester.ToList().Remove(t);
                    }
                }
            }
            return tester.ToList();
        }

        public List<Test> testIf(Predicate<Test> func)
        {
            List<Test> test = new List<Test>();
            test = DAL.Ds.test.FindAll(func);
            return test;
        }

        public int CountTest(Trainee trainee)
        {
            int count = 0;
            foreach (Test testt in DAL.Ds.test)
            {
                if (testt.TestTraineeId == trainee.TraineeId)
                {
                    count += 1;
                }
            }
            return count;
        }
        public bool CanGetLicense(Trainee trainee)
        {

            IEnumerable<Test> test = DAL.Ds.test.ToList().Where(l => l.TestTraineeId == trainee.TraineeId);
            foreach (Test t in test)
            {

                if (t.TestFinalScore == EnumClass.Score.passes)
                {
                    return true;
                }

            }
            return false;
        }


        public List<Test> TestInDay(DateTime dateTime)

        {
            IEnumerable<Test> test = DAL.Ds.test.ToList().Where(l => l.TestData == dateTime.Date);
            return test.ToList();

        }
        public IEnumerable<IGrouping<EnumClass.CarType, Tester>> TesterGroupingByTypeCar(bool sort)
        {

            if (sort)
            {
                var result =
                    from Tester in DAL.Ds.tester
                    group Tester by (Tester.TesterCarType) into g
                    orderby g.Key
                    select g;
                return result;
            }
            else
            {
                var result =
                      from Tester in DAL.Ds.tester
                      group Tester by (Tester.TesterCarType) into g
                      select g;
                return result;
            }
        }

        public IEnumerable<IGrouping<string, Trainee>> TraineeGroupingByDrivingScool(bool sort)
        {
            if (sort)
            {
                var result =
                    from Trainee in DAL.Ds.trainee
                    group Trainee by (Trainee.TraineeDrivingSchool) into g
                    orderby g.Key
                    select g;
                return result;
            }
            else
            {
                var result =
                      from Trainee in DAL.Ds.trainee
                      group Trainee by (Trainee.TraineeDrivingSchool) into g
                      select g;
                return result;
            }
        }
        public IEnumerable<IGrouping<string, Trainee>> TraineeGroupingByDrivingTeacher(bool sort)
        {
            if (sort)
            {
                var result =
                    from Trainee in DAL.Ds.trainee
                    group Trainee by (Trainee.TraineeDrivingTeacher) into g
                    orderby g.Key
                    select g;
                return result;
            }
            else
            {
                var result =
                      from Trainee in DAL.Ds.trainee
                      group Trainee by (Trainee.TraineeDrivingTeacher) into g
                      select g;
                return result;
            }
        }
        public IEnumerable<IGrouping<int, Trainee>> TraineeGroupingByNumTest(bool sort)
        {
            if (sort)
            {
                var result =
                    from Trainee in DAL.Ds.trainee
                    group Trainee by (Trainee.TraineeNumberOfLessonsDriving) into g
                    orderby g.Key
                    select g;
                return result;
            }
            else
            {
                var result =
                      from Trainee in DAL.Ds.trainee
                      group Trainee by (Trainee.TraineeNumberOfLessonsDriving) into g
                      select g;
                return result;
            }

        }
        //פונקציה לחישוב אחוזי מעבר של נבחנים אצל טסטר מסוים
        public double PercentOfThePast(Tester tester)
        {
            double help = 0;
            double k = 0;
            IEnumerable<Test> test = DAL.Ds.test.ToList().Where(l => l.TestTesterId == tester.TesterId);
            k = (double)test.ToList().LongCount();
            foreach (Test t in test)
            {
                if (t.TestFinalScore == EnumClass.Score.passes)
                {
                    help += 1;
                }
            }
            return ((help / k) * 100);
        }
        //פונקציה שמחזירה רשימה של טסטים של טסטר מסוים ביום ספציפי
        public List<Test> TestInDayOfTester(DateTime dateTime, string id)
        {
            Tester tester = GetTester(id);
            IEnumerable<Test> t = TestInDay(dateTime).ToList().Where(l => l.TestTesterId == tester.TesterId); ;
            return t.ToList();

        }
        ///פונקציה שמחזירה לי לוח שנה של הטסטים שהיו באותו חודש
        public Calendar calendarOfTest(DateTime dateTime)
        {
            int i = dateTime.Month;
            IEnumerable<Test> test = DAL.Ds.test.ToList().Where(l => l.TestData.Month == i);

            Calendar c = CultureInfo.InvariantCulture.Calendar;
            foreach (Test t in test)
            {
                c.AddDays(t.TestDataTime, t.TestData.Day);
            }
            return c;
        }
        ///פונקציה שמחזירה לי לוח שנה של הטסטים שהיו באותו חודש לטסטר מסוים
        public Calendar calendarOfTester(DateTime dateTime, string id)
        {
            int i = dateTime.Month;
            Tester tester = GetTester(id);

            IEnumerable<Test> test = DAL.Ds.test.ToList().Where(l => l.TestData.Month == i && l.TestTesterId == tester.TesterId);

            Calendar c = CultureInfo.InvariantCulture.Calendar;
            foreach (Test t in test)
            {
                c.AddDays(t.TestDataTime, t.TestData.Day);
            }
            return c;
        }
    }
}