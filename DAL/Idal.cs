using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using BE;

namespace DAL
{
    public interface Idal
    {
        #region Tester Function
        void AddTester(Tester tester);
        void DeleteTester(string id);
        void UpdateTester(Tester tester);
        Tester GetTester(string id);
        List<Tester> testers();
        #endregion
        #region Trainee Function
        void AddTrainee(Trainee trainee);
        void DeleteTrainee(string id);
        void UpdateTrainee(Trainee trainee);
        Trainee GetTrainee(string id);
        List<Trainee> trainees();
        #endregion
        #region Test Function
        void AddTest(Test test);
        void UpdateTest(Test test);
        Test GetTest(int id);
        List<Test> tests();

        #endregion





    }
}
