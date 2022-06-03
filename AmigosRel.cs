using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    public class AmigosRel
    {
        public int idAmigo { get; set; }
        public int idUser { get; set; }

        public AmigosRel(int idA, int idU)
        {
            idAmigo = idA;
            idUser = idU;
        }
    }
}
