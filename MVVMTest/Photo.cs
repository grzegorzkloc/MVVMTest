using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest
{
    public class Photo
    {
        public int id { get; set; }
        public string title { get; set; }
        public Photo(int ID, string TITLE)
        {
            id = ID;
            title = TITLE;
        }
    }
}
