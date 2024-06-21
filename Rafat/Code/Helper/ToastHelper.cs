using Rafat.Gui.ToastGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Code.Helper
{
    public static class ToastHelper
    {
        public static void ShowAddToast()
        {
            ToastForm.Instance("اضافة بيانات","تم اضافة البيانات بنجاح").Show();
        }

        public static void ShowEditToast()
        {
            ToastForm.Instance("تعديل بيانات", "تم تعديل البيانات بنجاح").Show();
        }

        public static void ShowDeleteToast()
        {
            ToastForm.Instance("حذف بيانات", "تم حذف البيانات بنجاح").Show();
        }
    }
}
