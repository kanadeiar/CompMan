using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CompManBase.Models
{
    public class DateTimer : DateTimerBase
    {
        public DateTimer() : base()
        {
            _dateTime = startDateTime = new DateTime(2020, 01, 01, 00, 00, 00);
            
        }
    }
}
