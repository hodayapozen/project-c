using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    [Serializable]
    public class Trainee
    {
        public string TraineeId { get; set; }
        public string TraineeFirstName { get; set; }
        public string TraineeLastName { get; set; }
        public EnumClass.Gender TraineeGender { get; set; }
        public DateTime TraineeDateBirth
        {
            get
            {
                return TraineeDateBirth.Date;
            }
            set
            {
                TraineeDateBirth = value.Date;
            }
        }
        public string TraineePhoneNumber { get; set; }
        public StructClass.Adress TraineeAdress { get; set; }
        public EnumClass.CarType TraineeCarType { get; set; }
        public EnumClass.GearboxType TraineeGearboxType { get; set; }
        public String TraineeDrivingSchool { get; set; }
        public String TraineeDrivingTeacher { get; set; }
        public int TraineeNumberOfLessonsDriving { get; set; }
        public Trainee() { }
        public Trainee(Trainee trainee)
        {
            this.TraineeLastName = trainee.TraineeLastName;
            this.TraineeFirstName = trainee.TraineeFirstName;
            this.TraineePhoneNumber = trainee.TraineePhoneNumber;
            this.TraineeAdress = trainee.TraineeAdress;
            this.TraineeNumberOfLessonsDriving = trainee.TraineeNumberOfLessonsDriving;

        }
        public Trainee GetCopy()
        {
            return (Trainee)this.MemberwiseClone();
        }

    }
}
