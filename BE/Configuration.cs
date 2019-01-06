using System;
using System.Linq;
using System.Text.RegularExpressions;

using System.IO;
using System.Text;


namespace BE
{
    public class Configuration
    {

        public static int testID = 00000000;
        public static int MinAgeTester = 40;
        public static int MinAgeTrainee = 18;
        public static int MinRangeTest = 7;
        public static int NinDrivingLessons = 20;
        public static Random Distance = new Random();
      

    public static string[] arr = { "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00" };
        /// פונקציה שבודקת תקינות של תעודת זהות
        public static bool CheckId(string str)
        {
            //if ((str.Count(char.IsDigit) == 9) && // only 9 digits
            //    (str.EndsWith("X", StringComparison.OrdinalIgnoreCase)
            //     || str.EndsWith("V", StringComparison.OrdinalIgnoreCase)) && //a letter at the end 'x' or 'v'
            //    (str[2] != '4' && str[2] != '9')) //3rd digit can not be equal to 4 or 9
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }
        public static bool CheckPhoneNumber(string str)
        {
            //  return Regex.Match(str, @"^(\+[05][0|2-5|8][0-9]{9})$").Success;
            return true;
        }
        public static int Age(DateTime dateTime)
        {
            int years = DateTime.Now.Year - dateTime.Year;
            if ((dateTime.Month > DateTime.Now.Month) || (dateTime.Month == DateTime.Now.Month && dateTime.Day > DateTime.Now.Day))
                years--;
            return years;
        }
        public static bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));

            return d1 == d2;
        }
        public static int DistanceRandom(string plaA, string plaB)
        {
            string place1 = plaA;
            string place2 = plaB;
            if (place1 == place2) throw new Exception("the places is same");
            string AtoB = place1 + "&" + place2;
            string BtoA = place2 + "&" + place1;
            string Textresult = "0";
            int IntResult = 0;

            string projPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string filePath = Path.Combine(projPath, "fakeDistance.txt");

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
            else if (File.Exists(filePath))
            {
                string lineToWrite = null;
                string[] lines = File.ReadAllLines(filePath);
                int corentLine = 0;
                while (corentLine < lines.Length)
                {
                    lineToWrite = lines[corentLine++];
                    if (lineToWrite == AtoB || lineToWrite == BtoA)
                    {
                        Textresult = lines[corentLine++];
                        if (!Int32.TryParse(Textresult, out IntResult)) throw new Exception("error in format distance:" + Textresult);
                        return IntResult;
                    }
                }
            }
            if (Textresult == "0") IntResult = HelpFuncCreateNewRoute(AtoB);
            return IntResult;
        }
        private static int HelpFuncCreateNewRoute(string citys)
        {
            Random rnd = new Random();
            int dist = rnd.Next(1, 201);
            string projPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string filePath = Path.Combine(projPath, "fakeDistance.txt");

            try
            {
                File.AppendAllText(filePath,
                   citys + Environment.NewLine);
                File.AppendAllText(filePath,
                          dist.ToString() + Environment.NewLine);
            }
            catch (Exception e) { throw new Exception("Erorr with write to file"); }
            return dist;
        }

        ///פונקציה שמאתחלת את המטריצה לפי שעות עבודה
        public static bool[,] MatrixInitialization(int hours1, int hours2, int[] days)
        {
            bool[,] matrixWorkHours = new bool[5, 6];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    matrixWorkHours[i, j] = false;
                }
            }
            foreach (int d in days)
            {
                for (int i = hours1 - 8; i<hours2-8; i++)
                {
                    matrixWorkHours[i, d - 1] = true;
                }
            }
            return matrixWorkHours;
        }
    }
}