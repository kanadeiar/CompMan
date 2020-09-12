using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompManBase.Models
{
    public class WorkBase : INotifyPropertyChanged
    {
        private int _work; //текущая работа

        public WorkBase()
        {
        }

        #region Свойства-зависимости
        public int Work
        {
            get => _work;
            set
            {
                if (value == _work) return;
                _work = value;
                Changed(nameof(Work));
                Changed(nameof(WorkName));
                Changed(nameof(Salary));
            }
        }
        public string WorkName => WorkNames[_work].Name;
        public int Salary => WorkNames[_work].Salary;
        #endregion


        /////////////////////////////////////////////////////////////////////
        public struct WorkType
        {
            /// <summary> Уровень работы </summary>
            public int Level { get; set; }
            /// <summary> Название работы </summary>
            public string Name { get; set; }
            /// <summary> Зарплата этой работы в день </summary>
            public int Salary { get; set; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Данные
        public static WorkType[] WorkNames = new[]
        {
            new WorkType { Level = 0, Name ="Безработный", Salary = 0 },
            new WorkType { Level = 1, Name ="Дворник", Salary = 500 },
            new WorkType { Level = 2, Name ="Бухгалтер", Salary = 1_000 },
            new WorkType { Level = 3, Name ="Сисадмин", Salary = 1_500 },
            new WorkType { Level = 4, Name ="Джун Программист PHP", Salary = 2_000 },
            new WorkType { Level = 5, Name ="Синер Программист С#", Salary = 5_000 },
            new WorkType { Level = 5, Name ="Хакер-Прораммист C++", Salary = 10_000 },
        };
        #endregion
    }
}
