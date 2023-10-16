using System;
using System.Collections.Generic;
using SIPOTCC.SIPOT.Campos;

namespace SIPOTCC.SIPOT
{
    [Serializable]
    public class RegistroTabla
    {
        public int Numero { get; set; }
        public List<Campo> Campos { get; set; }

        public RegistroTabla()
        {
            Numero = 0;
            Campos = new List<Campo>();
        }

        public RegistroTabla(int numero)
        {
            Numero = numero;
            Campos = new List<Campo>();
        }
    }
}
