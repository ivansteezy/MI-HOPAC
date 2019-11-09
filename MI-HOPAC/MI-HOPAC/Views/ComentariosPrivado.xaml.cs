using MI_HOPAC.Foundation;
using MI_HOPAC.MiHomeacupService;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MI_HOPAC.Views
{
    /// <summary>
    /// Interaction logic for ComentariosPrivado.xaml
    /// </summary>
    public partial class ComentariosPrivado : Page
    {
        int fkForo;
        string NombrePac;
        string TextoForo;
        string FechaForo;

        public ComentariosPrivado(int idForo, string nombrePac, string textoForo, string fechaForo)
        {
            InitializeComponent();
            fkForo = idForo;
            NombrePac = nombrePac;
            TextoForo = textoForo;
            FechaForo = fechaForo;

            Nombre.Text = nombrePac;
            Fecha.Text = fechaForo;
            Texto.Text = textoForo;


            Imprimir();
        }

        private void Comentar_Click(object sender, RoutedEventArgs e)
        {

            string fecha = DateTime.Now.Date.ToShortDateString();
            var texto = new TextRange(Comentario.Document.ContentStart, Comentario.Document.ContentEnd).Text;

            MainWebServiceSoapClient client = new MainWebServiceSoapClient();
            client.InsertComentariosPrivado(texto, fecha, 0, fkForo);

            Comentario.Document.Blocks.Clear();
            Imprimir();

            
        }


        private void Imprimir()
        {
            List<ComentarioPrivado> comentarios = GetNotas();

            if (comentarios.Count > 0)
            {
                ListViewComentarios.ItemsSource = comentarios;
            }
        }

        private List<ComentarioPrivado> GetNotas()
        {

            MiHomeacupService.MainWebServiceSoapClient client = new MainWebServiceSoapClient();

            //Consultamos los comentarios
            var result = client.GetComentariosPrivado(fkForo);
            List<ComentarioPrivado> comentarios = new List<ComentarioPrivado>();
            string elNombre, elColor;

            //Para cada comentario de la base de datos, lo pasasmos a una lista para imprimr.
            foreach (MiHomeacupService.ComentariosPrivadoModel i in result)
            {
                if(i.m_TipoDeCuenta == 0)
                {
                    elNombre = "Yo";
                    elColor = "CadetBlue";
                }
                else
                {
                    elNombre = NombrePac;
                    elColor = "DarkSeaGreen";
                }

                var comment = new ComentarioPrivado(i.m_IdComentariosPrivado, i.m_Texto, i.m_Fecha, elNombre, elColor);
                //Lo aniadimos a la lista
                comentarios.Add(comment);
            }

            //Retornamos la lista con los comentarios para imprimir
            return comentarios;

        }

    }
}
