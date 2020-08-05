using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompManBase.Interfaces;

namespace CompManBase.Models
{
    public class Hack : HackBase, IHackPrograms
    {
        public Hack() : base()
        {
            HackPrograms = new ObservableCollection<HackProgram>();
        }
        public IEnumerable<HackProgram> HackPrograms { get; set; }
        public void AddHackProgram(int id)
        {
            ((ObservableCollection<HackProgram>)HackPrograms).Add(new HackProgram {Id = id, Name = HackProgramsNames.First(p => p.Id == id).Name});
        }
    }
}
