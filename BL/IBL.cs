using System;
using System.Collections.Generic;
using System.Text;
using BE;
using System.Linq;
using System.Globalization;

namespace BL
{
    public interface IBL
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

        List<Tester> TesterDistance_X(StructClass.Adress adress);
        List<Tester> TesterFree(DateTime dateTime);
        List<Test> testIf(Predicate<Test> func);
        int CountTest(Trainee trainee);
        bool CanGetLicense(Trainee trainee);
        List<Test> TestInDay(DateTime dateTime);




        IEnumerable<IGrouping<EnumClass.CarType, Tester>> TesterGroupingByTypeCar(bool sort);
        IEnumerable<IGrouping<string, Trainee>> TraineeGroupingByDrivingScool(bool sort);
        IEnumerable<IGrouping<string, Trainee>> TraineeGroupingByDrivingTeacher(bool sort);
        IEnumerable<IGrouping<int, Trainee>> TraineeGroupingByNumTest(bool sort);

        double PercentOfThePast(Tester tester);
        List<Test> TestInDayOfTester(DateTime dateTime, string id);
        Calendar calendarOfTest(DateTime dateTime);
        Calendar calendarOfTester(DateTime dateTime, string id);
    }
}
