using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    // Common lifecycle interface 
    public interface Lifecycle
    {
        public void initialize();
        public void terminate();
        public bool isInitialized();
    }
}
