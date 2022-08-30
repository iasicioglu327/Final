using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Core.UnitofWorks
{
    public interface IUnitofWork
    {
        void Commit();
    }
}
