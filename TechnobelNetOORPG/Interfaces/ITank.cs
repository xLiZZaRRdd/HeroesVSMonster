using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnobelNetOORPG.Models;

namespace TechnobelNetOORPG.Interfaces
{
    public interface ITank
    {
        public double ResistanceBuff { get; set; }
        public void Resist();

    }
}
