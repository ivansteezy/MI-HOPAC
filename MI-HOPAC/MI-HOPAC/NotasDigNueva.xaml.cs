﻿using System;
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

namespace MI_HOPAC
{
    /// <summary>
    /// Interaction logic for NotasDigNueva.xaml
    /// </summary>
    public partial class NotasDigNueva : Page
    {
        enum colores
        {
            //#ff9aa2, perp,asdas,gasdad
            
        };

        public NotasDigNueva()
        {
            InitializeComponent();

            var converter = new System.Windows.Media.BrushConverter();

            var brush1 = (Brush)converter.ConvertFromString("#ff9aa2");

            Nota.Background = brush1;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var converter = new System.Windows.Media.BrushConverter();

            var brush1 = (Brush)converter.ConvertFromString("#ff9aa2");
            var brush2 = (Brush)converter.ConvertFromString("#ffdac1");
            var brush3 = (Brush)converter.ConvertFromString("#f7f7b7");
            var brush4 = (Brush)converter.ConvertFromString("#e2f0cb");
            var brush5 = (Brush)converter.ConvertFromString("#b5ead7");
            var brush6 = (Brush)converter.ConvertFromString("#c7ceea");


            if (Nota.Background.ToString() == brush1.ToString())
                Nota.Background = brush2;    
            else if (Nota.Background.ToString() == brush2.ToString())
                Nota.Background = brush3;
            else if (Nota.Background.ToString() == brush3.ToString())
                Nota.Background = brush4;
            else if (Nota.Background.ToString() == brush4.ToString())
                Nota.Background = brush5;
            else if (Nota.Background.ToString() == brush5.ToString())
                Nota.Background = brush6;
            else if (Nota.Background.ToString() == brush6.ToString())
                Nota.Background = brush1;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
