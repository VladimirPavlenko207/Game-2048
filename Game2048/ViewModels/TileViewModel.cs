using Game2048.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Game2048.ViewModels
{
    internal class TileViewModel : ViewModel
    {
        private string valueStr = string.Empty;
        private Brush brush;

        public string ValueStr
        {
            get
            {
                if (valueStr == "0") return string.Empty;
                return valueStr.ToString();
            }
            set
            {
                Set(ref valueStr, value);
                SetBrush();
            }
        }

        private void SetBrush()
        {
            Brush = ValueStr switch
            {
                "2" => (Brush)Application.Current.Resources["Color2"],
                "4" => (Brush)Application.Current.Resources["Color4"],
                "8" => (Brush)Application.Current.Resources["Color8"],
                "16" => (Brush)Application.Current.Resources["Color16"],
                "32" => (Brush)Application.Current.Resources["Color32"],
                "64" => (Brush)Application.Current.Resources["Color64"],
                "128" => (Brush)Application.Current.Resources["Color128"],
                "256" => (Brush)Application.Current.Resources["Color256"],
                "512" => (Brush)Application.Current.Resources["Color512"],
                "1024" => (Brush)Application.Current.Resources["Color1024"],
                "2048" => (Brush)Application.Current.Resources["Color2048"],
                _ => (Brush)Application.Current.Resources["Color0"],
            };
        }

        public Brush Brush
        {
            get => brush;
            set => Set(ref brush, value);
        }
    }
}
