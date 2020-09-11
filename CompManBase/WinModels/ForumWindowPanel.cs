using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CompManBase.Annotations;
using CompManBase.Models;

namespace CompManBase.WinModels
{
    public class ForumWindowPanel : INotifyPropertyChanged
    {
        /// <summary> Форум </summary>
        public Forum Forum { get; set; }
        public ForumWindowPanel() { }
        public ForumWindowPanel(Forum forum)
        {
            Forum = forum;
        }
        #region Свойства-зависимости
        public IEnumerable<ForumMes> ForumMessages => Forum.ForumMessages.Select(m => new ForumMes{id = m.Id, Message = m.Message, DoName = m.DoName, Title = m.Title});
        //Действия на интернет-форуме
        public void BuyProgram(int id)
        {
            switch (id)
            {
                case 1: Forum.BuyProgram1();
                    break;
                case 2: Forum.BuyProgram2();
                    break;
                case 3: Forum.BuyProgram3();
                    break;
                case 4: Forum.BuyProgram4();
                    break;
                case 5: Forum.BuyProgram5();
                    break;
                default: return;
            }
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public struct ForumMes
        {
            public int id { get; set; }
            /// <summary> Заголовок </summary>
            public string Title { get; set; }
            /// <summary> Сообщение </summary>
            public string Message { get; set; }
            /// <summary> Название действия </summary>
            public string DoName { get; set; }
        }
    }
}
