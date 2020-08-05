using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CompManBase.Annotations;

namespace CompManBase.Models
{
    public class HackBase : INotifyPropertyChanged
    {
        public HackBase()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /////////////////////////////////////////////////////////////////////
        public struct HackProgram
        {
            /// <summary> Идентификатор </summary>
            public int Id;
            /// <summary> Название </summary>
            public string Name;
        }
        #region Данные
        public static HackProgram[] HackProgramsNames = new[]
        {
            new HackProgram{Id = 1, Name = "Простой анонимайзер"}, 
            new HackProgram{Id = 2, Name = "Программа подбора паролей"}, 
            new HackProgram{Id = 3, Name = "Программа маскировки"}, 
        };
        #endregion
    }
}
