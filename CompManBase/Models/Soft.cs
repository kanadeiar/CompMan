using CompManBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static CompManBase.Models.ComputerBase;

namespace CompManBase.Models
{
    public class Soft : SoftBase
    {
        private IWallet _wallet; //кошелек игрока
        private IInfoComputer _infoComputer; //инфа по компьютеру
        /// <summary> Конструктор с кошелем игрока </summary>
        /// <param name="wallet">Кошель игрока</param>
        public Soft(IWallet wallet, IInfoComputer computer)
        {
            _wallet = wallet;
            _infoComputer = computer;
        }

        #region Следующие по уровню компоненты

        public string NextActionOs
        {
            get
            {
                if (Os == 0)
                    return "Установка новой операционной системы";
                if (Os >= OsNames.Length - 1)
                    return "У вас и так максимально мощная операционка";
                return "Установка более мощной операционной системы";
            }
        }
        public SoftPrt NextOs => GetNextPart(Os, OsNames);
        public bool NextOsMayBuy => NextOs.Level != -1 && _wallet.MaySubsctact(NextOs.Cost);




        /// <summary> Получение следующей по уровню программной части </summary>
        private SoftPrt GetNextPart(int part, SoftPrt[] names)
        {
            if (part <= names.Length - 2)
                return names[part + 1];
            else
                return new SoftPrt { Level = -1, Name = "Улучшать софт дальше некуда" };
        }
        #endregion

        #region Установка частей программ
        public void BuyOs()
        {
            if (Os >= OsNames.Length - 1)
                return;
            bool needs = false;
            StringBuilder sb = new StringBuilder();
            if (Os >= _infoComputer.GetLevel(Components.Platform))
            {
                needs = true;
                sb.AppendLine("более мощная платформа");
            }
            if (Os >= _infoComputer.GetLevel(Components.Ram) + 1 || _infoComputer.GetLevel(Components.Ram) <= 0)
            {
                needs = true;
                sb.AppendLine("более мощная оперативная память");
            }
            if (Os >= _infoComputer.GetLevel(Components.Hdd) + 1 || _infoComputer.GetLevel(Components.Hdd) <= 0)
            {
                needs = true;
                sb.AppendLine("более мощный жесткий диск");
            }
            if (Os >= _infoComputer.GetLevel(Components.Video) + 1 || _infoComputer.GetLevel(Components.Video) <= 0)
            {
                needs = true;
                sb.AppendLine("более мощная видеокарта");
            }
            if (needs)
            {
                MessageBox.Show($"Для установки ОС {NextOs.Name} взамен {OsName} требуется:\n" + sb.ToString(), "Апгрейд недоступен", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _wallet.Substract(NextOs.Cost);
            Os++;
        }




        #endregion
    }
}
