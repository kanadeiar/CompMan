using CompManBase.Interfaces;
using CompManBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CompManBase.Models.WorkBase;

namespace CompManBase.WinModels
{
    public class WorkWindowPanel : INotifyPropertyChanged
    {
        /// <summary> Работа текущая </summary>
        public Work Work { get; set; }
        /// <summary> Сведения о работах </summary>
        public ICollection<WorkType> WorkNames { get; set; }

        public WorkWindowPanel() : this(null) { }
        public WorkWindowPanel(Work work)
        {
            Work = work;
            WorkNames = WorkBase.WorkNames.ToList();

        }

        #region Свойства-зависимости
        public bool MayDoItWork0 => Work.GetMayDoItWork(0);
        public void GoToWork0()
        {
            if (!MayDoItWork0)
                return;
            Work.GoToWork(0);
            ReBlockButtons();
        }
        public bool MayDoItWork1 => Work.GetMayDoItWork(1);
        public void GoToWork1()
        {
            if (!MayDoItWork1)
                return;
            Work.GoToWork(1);
            ReBlockButtons();
        }
        public bool MayDoItWork2 => Work.GetMayDoItWork(2);
        public void GoToWork2()
        {
            if (!MayDoItWork2)
                return;
            Work.GoToWork(2);
            ReBlockButtons();
        }
        public bool MayDoItWork3 => Work.GetMayDoItWork(3);
        public void GoToWork3()
        {
            if (!MayDoItWork3)
                return;
            Work.GoToWork(3);
            ReBlockButtons();
        }
        public bool MayDoItWork4 => Work.GetMayDoItWork(4);
        public void GoToWork4()
        {
            if (!MayDoItWork4)
                return;
            Work.GoToWork(4);
            ReBlockButtons();
        }
        public bool MayDoItWork5 => Work.GetMayDoItWork(5);
        public void GoToWork5()
        {
            if (!MayDoItWork5)
                return;
            Work.GoToWork(5);
            ReBlockButtons();
        }
        public bool MayDoItWork6 => Work.GetMayDoItWork(6);
        public void GoToWork6()
        {
            if (!MayDoItWork6)
                return;
            Work.GoToWork(6);
            ReBlockButtons();
        }

        /// <summary> Изменение блокировок доступных работ управления </summary>
        private void ReBlockButtons()
        {
            Changed(nameof(MayDoItWork0));
            Changed(nameof(MayDoItWork1));
            Changed(nameof(MayDoItWork2));
            Changed(nameof(MayDoItWork3));
            Changed(nameof(MayDoItWork4));
            Changed(nameof(MayDoItWork5));
            Changed(nameof(MayDoItWork6));
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
