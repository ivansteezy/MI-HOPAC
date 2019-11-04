using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Lógica de interacción para HorarioDialog.xaml
    /// </summary>
    public partial class HorarioDialog : Window
    {
        public HorarioDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        public SortedDictionary<int, bool> MapaDias
        {
            get
            {
                SortedDictionary<int, bool> isDayEnabled = new SortedDictionary<int, bool>();
                isDayEnabled.Add((int)DiasDeLaSemana.Lunes, lunes.IsChecked.Value);
                isDayEnabled.Add((int)DiasDeLaSemana.Martes, martes.IsChecked.Value);
                isDayEnabled.Add((int)DiasDeLaSemana.Miercoles, miercoles.IsChecked.Value);
                isDayEnabled.Add((int)DiasDeLaSemana.Jueves, jueves.IsChecked.Value);
                isDayEnabled.Add((int)DiasDeLaSemana.Viernes, viernes.IsChecked.Value);
                isDayEnabled.Add((int)DiasDeLaSemana.Sabado, sabado.IsChecked.Value);
                isDayEnabled.Add((int)DiasDeLaSemana.Domingo, domingo.IsChecked.Value);

                return isDayEnabled;
            }
        }

        public SortedDictionary<int, DateTime?> MapaHoraInicio
        {
            get
            {
                SortedDictionary<int, DateTime?> beginTime = new SortedDictionary<int, DateTime?>();
                beginTime.Add((int)DiasDeLaSemana.Lunes, InicioLunes.SelectedTime);
                beginTime.Add((int)DiasDeLaSemana.Martes, InicioMartes.SelectedTime);
                beginTime.Add((int)DiasDeLaSemana.Miercoles, InicioMiercoles.SelectedTime);
                beginTime.Add((int)DiasDeLaSemana.Jueves, InicioJueves.SelectedTime);
                beginTime.Add((int)DiasDeLaSemana.Viernes, InicioViernes.SelectedTime);
                beginTime.Add((int)DiasDeLaSemana.Sabado, InicioSabado.SelectedTime);
                beginTime.Add((int)DiasDeLaSemana.Domingo, InicioDomingo.SelectedTime);
                return beginTime;
            }
        }

        public SortedDictionary<int, DateTime?> MapaHoraFinal
        {
            get
            {
                SortedDictionary<int, DateTime?> endTime = new SortedDictionary<int, DateTime?>();
                endTime.Add((int)DiasDeLaSemana.Lunes, FinalLunes.SelectedTime);
                endTime.Add((int)DiasDeLaSemana.Martes, FinalMartes.SelectedTime);
                endTime.Add((int)DiasDeLaSemana.Miercoles, FinalMiercoles.SelectedTime);
                endTime.Add((int)DiasDeLaSemana.Jueves, FinalJueves.SelectedTime);
                endTime.Add((int)DiasDeLaSemana.Viernes, FinalViernes.SelectedTime);
                endTime.Add((int)DiasDeLaSemana.Sabado, FinalSabado.SelectedTime);
                endTime.Add((int)DiasDeLaSemana.Domingo, FinalDomingo.SelectedTime);
                return endTime;
            }
        }

        private void Lunes_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(lunes.IsChecked.Value)
                InicioLunes.Visibility = Visibility.Visible;
            else
                InicioLunes.Visibility = Visibility.Hidden;
        }

        enum DiasDeLaSemana
        {
            Lunes     = 0x0001, 
            Martes    = 0x0002,
            Miercoles = 0x0003,
            Jueves    = 0x0004,
            Viernes   = 0x0005,
            Sabado    = 0x0006,
            Domingo   = 0x0007,
        }
    }
}
