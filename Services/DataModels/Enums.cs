using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataModels
{
    public class Enums
    {
        public enum Category
        {
            Book =1 ,
            Journal =2
        }
        public enum Genre
        {
            Action =1 ,
            Horror =2 ,
            Romantic =3 ,
            Fantasy =4 ,
            Children =5 
        }
        public enum Topic
        {
            History =1 ,
            Politic =2 ,
            Science = 3 ,
            News= 4 
        }
        public enum Availability
        {
            Available =1 ,
            Rented = 2
        }

    }
}
