using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CompManBase.Interfaces;


namespace CompManBase.Models
{
    public class Events : EventsBase
    {
        private IWallet _wallet; //кошелек игрока
        private IChangeScore _score; //счет игрока
        private IOtherSoftChange _otherSoftChange; //изменение количества софта
        private IInfoSoft _infoSoft; //информация по софту
        private IInfoComputer _infoComputer; //информация по компьютеру
        private Random _rand = new Random();
        public Events(IDateTimerEvent timer, IPlayer player, IOtherSoftChange softChange, IInfoSoft soft, IInfoComputer infoComputer) : base()
        {
            _wallet = player;
            _score = player;
            _otherSoftChange = softChange;
            _infoSoft = soft;
            _infoComputer = infoComputer;
            timer.NextDayEvent += DayUpdate;
        }
        /// <summary> Ежедневное - выброс случайных событий </summary>
        private void DayUpdate(object sender, EventArgs e)
        {
            if (_infoSoft.GetInfo(SoftBase.Parts.Other) >= 2) //вызов если есть что то у пользователя скачанное
            {
                float randVal = _rand.Next(10000) / 100;
                foreach (var item in MyEvents)
                {
                    if (item.Id == 1 && randVal <= item.May) //Компьютерный вирус атаковал ваш компьютер!
                    {
                        MyEvent1();
                    }
                }
            }
            if (_infoComputer.GetLevel(ComputerBase.Components.Platform) >= 1) //вызов если есть какой либо компьютер
            {
                float randVal = _rand.Next(10000) / 100;
                foreach (var item in MyEvents)
                {
                    if (item.Id == 2 && randVal <= item.May) //Сломался компьютер! Требуется срочный ремонт!
                    {
                        MyEvent2();
                    }
                }
            }
        }
        /// <summary> Компьютерный вирус атаковал ваш компьютер! </summary>
        private void MyEvent1()
        {
            var rez = MessageBox.Show("Злобный компьютерный вирус атаковал ваш любимый компьютер!\nЧто будем делать - убить гада антивирусом?", MyEvents[0].Name, MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (rez == MessageBoxResult.Yes)
            {
                if (_infoSoft.GetInfo(SoftBase.Parts.Antivirus) >= 1)
                {
                    MessageBox.Show("Гадский вирус успешно побежден антивирусом!","Ура!");
                }
                else
                {
                    _score.Substract(1);
                    int soft = _infoSoft.GetInfo(SoftBase.Parts.Other) / 2;
                    _otherSoftChange.SubstractOtherSoft(soft);
                    MessageBox.Show("Не установлен антивирус!\nЗлобный вирус сожрал половину вашего софта", "Вот же гад!");
                }
            }
            else
            {
                _score.Substract(1);
                int soft = _infoSoft.GetInfo(SoftBase.Parts.Other) / 2;
                _otherSoftChange.SubstractOtherSoft(soft);
                MessageBox.Show("Злобный вирус сожрал половину вашего софта", "Вот же гад!");
            }
        }
        /// <summary> Сломался компьютер! Требуется срочный ремонт! </summary>
        private void MyEvent2()
        {
            while (true)
            {
                var rez = MessageBox.Show("Сдох компьютер и из него валит черный дым! Требуется срочный ремонт! Оплатить ремонт - 1000 рублей?", MyEvents[0].Name, MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if (rez == MessageBoxResult.Yes)
                    break;
                MessageBox.Show("Да как же вы без компьютера жить то будете?", "Стоп", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            _wallet.Substract(1000);
            MessageBox.Show("Компьютер успешно отремонтирован!");
        }
    }
}
