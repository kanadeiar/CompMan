using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CompManBase.Models
{
    public class Happy : HappyBase
    {
        private IWallet _wallet; //кошелек игрока
        private IInfoSoft _soft; //программы игрока
        private IHappy _happy; //настроение игрока
        private IStates _states; //состояние игрока
        private IChangeScore _score; //счет игрока
        Random rand = new Random();
        /// <summary> Конструктор с кошелем игрока </summary>
        public Happy(IPlayer player, IInfoSoft soft) : base()
        {
            _wallet = player;
            _soft = soft;
            _happy = player;
            _states = player;
            _score = player;
        }

        #region Доступность
        public bool Happy1MayDo => true;
        public bool Happy2MayDo => true;
        public bool Happy3MayDo => true;
        public bool Happy4MayDo => _soft.GetInfo(SoftBase.Parts.Game) >= 1;
        public bool Happy5MayDo => true;
        #endregion

        #region Действие - развлечься
        public void DoHappy1()
        {
            if (!_wallet.MaySubsctact(Happy1Cost))
            {
                MessageBox.Show($"Не хватает денег!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(Happy1Cost);
            _happy.Add(3);
        }
        public void DoHappy2()
        {
            if (!_wallet.MaySubsctact(Happy2Cost))
            {
                MessageBox.Show($"Не хватает денег!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(Happy2Cost);
            _happy.Add(10);
        }
        public void DoHappy3()
        {
            if (!_wallet.MaySubsctact(Happy3Cost))
            {
                MessageBox.Show($"Не хватает денег!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(Happy3Cost);
            _happy.Add(20);
        }
        public void DoHappy4()
        {
            if (!_wallet.MaySubsctact(Happy4Cost))
            {
                MessageBox.Show($"Не хватает денег!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (_soft.GetInfo(SoftBase.Parts.Game) <= 0)
            {
                MessageBox.Show($"Ни одной игры на компьютере не установлено!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(Happy4Cost);
            int happy = (_soft.GetInfo(SoftBase.Parts.Game) * 10 - _states.Level * 10 + 20); //сколько настроения прибавить
            _happy.Add(happy);
        }
        public void DoHappy5()
        {
            if (!_wallet.MaySubsctact(Happy5Cost))
            {
                MessageBox.Show($"Не хватает денег!", "Обломинго!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(Happy4Cost);
            if (rand.Next(100) <= 30)
            {
                var result = MessageBox.Show($"Вы подхватили сифилис от милой барышни! Для лечения срочно требуется 100_000 рублей! Оплатить лечение?", "СИФИЛИС!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _wallet.Substract(100_000);
                    _score.Substract(1);
                    MessageBox.Show($"Вы успешно вылечились!", "Лечение.", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _happy.Substract(60);
                    _score.Substract(2);
                    MessageBox.Show($"Вы проигнорировали лечение и вы будете вечно болеть сифилисом!", "Отказ от лечения.", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                return;
            }
            if (rand.Next(100) <= 10)
            {
                _wallet.Substract(Convert.ToInt32(_states.Money * 0.9));
                _happy.Substract(60);
                _score.Substract(3);
                MessageBox.Show($"Вы были были обмануты, ограблены и избиты до полусмерти милой барышней!", "Ограбление!", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            int happy = 100 - _states.Level * 10; //сколько настроения прибавить
            _happy.Add(happy);
            _score.Add(1);
            MessageBox.Show($"Вы весело провели время с милой барышней!", "Развлечение!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        #endregion
    }
}
