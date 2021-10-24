using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_studyAMS
{
    interface IFactory
    {
        object produce(string name);
    }
}
