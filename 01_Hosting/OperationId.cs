using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Hosting
{
    public class OperationId : IOperationId
    {
        public Guid Id => Guid.NewGuid();
    }
}
