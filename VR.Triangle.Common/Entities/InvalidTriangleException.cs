using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VR.Triangle.Common.Entities
{
   internal class InvalidTriangleException:Exception
    {
        internal InvalidTriangleException(ValidationResult _state)
        {
            state = _state;
        }
        internal ValidationResult state;
    }
}
