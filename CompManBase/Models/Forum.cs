using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CompManBase.Interfaces;

namespace CompManBase.Models
{
    public class Forum : ForumBase
    {
        private IWallet _wallet; //кошелек игрока
        private IStates _states; //состояние игрока
        private IHackPrograms _hackPrograms; //программы игрока
        public Forum(IPlayer player, IHackPrograms hack) : base()
        {
            _states = player;
            _wallet = player;
            _hackPrograms = hack;
        }
        public new IEnumerable<ForumMessage> ForumMessages => ForumBase.ForumMessages.Where(m => m.NeedLevel <= _states.Level);

        #region Действия на форуме
        /// <summary> Продажа анонимайзера </summary>
        public void BuyProgram1()
        {
            if (!_wallet.MaySubsctact(10_000))
            {
                MessageBox.Show("Не хватает денег для покупки этой программы!", "Облом", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (_hackPrograms.HackPrograms.Count(p => p.Id == 1) != 0)
            {
                MessageBox.Show("У вас уже есть такая программа!", "Хватит и одной!", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            _wallet.Substract(10_000);
            _hackPrograms.AddHackProgram(1);
        }
        /// <summary> Продажа программы подбора паролей </summary>
        public void BuyProgram2()
        {
            if (!_wallet.MaySubsctact(25_000))
            {
                MessageBox.Show("Не хватает денег для покупки этой программы!", "Облом", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            var tmp = _hackPrograms.HackPrograms.Count(p => p.Id == 2);
            if (_hackPrograms.HackPrograms.Count(p => p.Id == 2) != 0)
            {
                MessageBox.Show("У вас уже есть такая программа!", "Хватит и одной!", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            _wallet.Substract(25_000);
            _hackPrograms.AddHackProgram(2);
        }
        /// <summary> Обмен программы маскировки </summary>
        public void BuyProgram3()
        {
            if (_hackPrograms.HackPrograms.Count(p => p.Id == 2) == 0)
            {
                MessageBox.Show("У вас нет в наличии для обмена программы для подбора паролей!", "Облом", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (_hackPrograms.HackPrograms.Count(p => p.Id == 3) != 0)
            {
                MessageBox.Show("У вас уже есть такая программа!", "Хватит и одной!", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            _hackPrograms.AddHackProgram(3);
        }
        /// <summary> Обмен программы подбора паролей </summary>
        public void BuyProgram4()
        {
            if (_hackPrograms.HackPrograms.Count(p => p.Id == 1) == 0)
            {
                MessageBox.Show("У вас нет в наличии для обмена программы - анонимайзера!", "Облом", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (_hackPrograms.HackPrograms.Count(p => p.Id == 2) != 0)
            {
                MessageBox.Show("У вас уже есть такая программа!", "Хватит и одной!", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            _hackPrograms.AddHackProgram(2);
        }
        /// <summary> Продажа программы ДДОС-атаки </summary>
        public void BuyProgram5()
        {
            if (!_wallet.MaySubsctact(100_000))
            {
                MessageBox.Show("Не хватает денег для покупки этой программы!", "Облом", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (_hackPrograms.HackPrograms.Count(p => p.Id == 4) != 0)
            {
                MessageBox.Show("У вас уже есть такая программа!", "Хватит и одной!", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            _wallet.Substract(100_000);
            _hackPrograms.AddHackProgram(4);
        }
        /// <summary> Продажа программы использования VPN-туннелей </summary>
        public void BuyProgram6()
        {
            if (!_wallet.MaySubsctact(200_000))
            {
                MessageBox.Show("Не хватает денег для покупки этой программы!", "Облом", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (_hackPrograms.HackPrograms.Count(p => p.Id == 5) != 0)
            {
                MessageBox.Show("У вас уже есть такая программа!", "Хватит и одной!", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            _wallet.Substract(200_000);
            _hackPrograms.AddHackProgram(5);
        }
        /// <summary> Продажа программы шифратора/дешифратора </summary>
        public void BuyProgram7()
        {
            if (!_wallet.MaySubsctact(1_000_000))
            {
                MessageBox.Show("Не хватает денег для покупки этой программы!", "Облом", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (_hackPrograms.HackPrograms.Count(p => p.Id == 6) != 0)
            {
                MessageBox.Show("У вас уже есть такая программа!", "Хватит и одной!", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            _wallet.Substract(1_000_000);
            _hackPrograms.AddHackProgram(6);
        }
        #endregion
    }
}
