using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface INotifier
    {
        void OnError(string error);
        void OnWarning(string warning);
        void OnInfo(string info);
        void OnSucces(string succes);
        bool OnOption(string option,string optionTitle);

        
    }
}
