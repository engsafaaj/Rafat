using Rafat.Code.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rafat.Gui.HomeGui
{
    public partial class HomeUserControl : UserControl
    {
        private static  HomeUserControl? homeUserControl;
        public HomeUserControl()
        {
            InitializeComponent();
            labelWelcome.Text = $"مرحبا بك {LocalUser.FullName}";
            labelCompnayName.Text = Properties.Settings.Default.CompanyName;
        }

        public static HomeUserControl Instance()
        {
            return homeUserControl??(homeUserControl= new HomeUserControl());
        }
    }
}
