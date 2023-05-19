using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnobelNetOORPG.Models;

namespace TechnobelNetOORPG.Interfaces
{
    public interface IHeal
    {

        public void heal(Personnage? allie = null);


    }
}
