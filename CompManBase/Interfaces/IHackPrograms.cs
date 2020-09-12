using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompManBase.Models;

namespace CompManBase.Interfaces
{
    public interface IHackPrograms
    {
        IEnumerable<HackBase.HackProgram> HackPrograms { get; set; }
        void AddHackProgram(int id);
    }
}
