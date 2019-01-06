using System;
using System.Collections.Generic;
using System.Text;
using BE;
using System.Linq;
using DAS;

namespace DAL
{
    internal class Dal_imp : Idal
    {
        Ds d;
        public Dal_imp()
        {
            d = new Ds();
        }



        //private static readonly Dal_imp instance = new Dal_imp();
        //public static Dal_imp Instance
        //{
        //    get { return instance; }
        //}

        //public Dal_imp() { }
        //static Dal_imp() { }


        #region Tester Function
        public void AddTester(Tester tester)
        {
            Tester t = GetTester(tester.TesterId);
            if (t != null)
            {
                throw new Exception("The tester is already in the system");
            }
 
             Ds.tester.Add(tester);
            
        }
        public void DeleteTester(string id)
        {
            Tester tester = GetTester(id);
            if (tester == null)
            {
                throw new Exception("Tester with this id doesn't exists ");
            }
            Ds.tester.Remove(tester);

        }
        public void UpdateTester(Tester t)
        {
            //string help = tester.TesterId;
            //Tester tester1 = GetTester(help);
            //if (tester1 == null)
            //{
            //    throw new Exception("Tester with this id doesn't exists");
            //}
            //tester1 = tester;
            int index = Ds.tester.IndexOf(GetTester(t.TesterId));
            if (index == -1)//wasn't found
                throw new Exception("Tester with this id doesn't exists");
            Ds.tester[index] = t;
        }
        public Tester GetTester(string id)
        {

            return Ds.tester.FirstOrDefault(testr => testr.TesterId == id);
        }
        public List<Tester> testers()
        {
            List<Tester> help = new List<Tester>();
            help = Ds.tester;
            return help;
        }
        #endregion
        #region Trainee Function
        public void AddTrainee(Trainee trainee)
        {
            if (GetTrainee(trainee.TraineeId) != null)
            {
                throw new Exception("The tester is already in the system");
            }
            Ds.trainee.Add(trainee);
        }
        public void DeleteTrainee(string id)
        {
            Trainee trainee = GetTrainee(id);
            if (trainee == null)
            {
                throw new Exception("Trainee with this id doesn't exists");
            }
            Ds.trainee.Remove(trainee);
        }
        public void UpdateTrainee(Trainee trainee)
        {
            string help = trainee.TraineeId;
            Trainee trainee1 = GetTrainee(help);
            if (trainee1 == null)
            {
                throw new Exception("Tester with this id doesn't exists");
            }
            trainee1 = trainee;
        }
        public Trainee GetTrainee(string id)
        {
            return Ds.trainee.FirstOrDefault(trainee => trainee.TraineeId == id);
        }
        public List<Trainee> trainees()
        {
            List<Trainee> help = new List<Trainee>();
            help = Ds.trainee;
            return help;
        }
        #endregion
        #region Test Function
        public void AddTest(Test test)
        {

            if (GetTest(test.TestId) != null)
            {
                throw new Exception("The tester is already in the system");
            }

            if (Configuration.testID < 99999999)
            {
                Configuration.testID += 1;
                test.TestId = Configuration.testID;
            }
            Ds.test.Add(test);
        }
        public void UpdateTest(Test test)
        {

            int help = test.TestId;
            Test test1 = GetTest(help);
            if (test1 == null)
            {
                throw new Exception("Test with this id doesn't exists");
            }
            /* test1.TestData = test.TestData;
        test1.TestDataTime = test.TestDataTime;*/
            test1.TestKeepDistance = test.TestKeepDistance;
            test1.TestParking = test.TestParking;
            test1.TestUsingMirrors = test.TestUsingMirrors;
            test1.TestSignals = test.TestSignals;
            test1.TestPayAttentyonForSignpost = test.TestPayAttentyonForSignpost;
            test1.TestSpeed = test.TestSpeed;
            test1.TestFinalScore = test.TestFinalScore;
            test1.TestNotesTester = test.TestNotesTester;


        }
        public Test GetTest(int id)
        {
            return Ds.test.FirstOrDefault(test => test.TestId == id);
        }
        public List<Test> tests()
        {
            List<Test> help = new List<Test>();
            help = Ds.test;
            return help;
        }
        #endregion
    }
}
