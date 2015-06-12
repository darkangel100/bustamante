using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Asiento
    {
        private string nombre_asiento;
        private List<Asiento> listaAsiento;

        public string NOMBREASIENTO
        {
            get { return nombre_asiento; }
            set { nombre_asiento = value; }

        }

        public List<Asiento> LISTAASIENTO
        {
            get { return listaAsiento; }
            set { listaAsiento = value; }
        }

    }
}
