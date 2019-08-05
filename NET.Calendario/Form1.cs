using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET.Calendario
{
    public partial class Form1 : Form
    {
        enum DiaSemana { Lunes = 1, Martes = 2, Miercoles = 3, Jueves = 4, Viernes = 5, Sabado = 6, Domingo = 0 }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] laDias = new int[30];
            for (int liContador = 0; liContador < laDias.Length; liContador++) {
                laDias[liContador] = liContador + 1;
            }
            
            CultureInfo loConfiguracion = new CultureInfo("Es-Es");
            string lsDia = loConfiguracion.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);

            DiaSemana hoy = (DiaSemana)Enum.Parse(typeof(DiaSemana), lsDia, true);

            MessageBox.Show(hoy.ToString());

            MessageBox.Show(DevolverNumeroDias().ToString());

        }

        private int DevolverNumeroDias() {

            DateTime ldFechaActual = DateTime.Today;
            int lnDias = 0;
            int lnMes = ldFechaActual.Month;
            int lnAno = ldFechaActual.Year;

            switch (lnMes)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    lnDias = 31; break;
                case 4:
                case 6:
                case 11:
                    lnDias = 30; break;
                case 2:
                    lnDias = 28;
                    if (DateTime.IsLeapYear(lnAno)) {
                        lnDias = 29;
                    }
                    break;
            }
            return lnDias;
        }
    }
}
