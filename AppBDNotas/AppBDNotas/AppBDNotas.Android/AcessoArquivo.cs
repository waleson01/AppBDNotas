using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppBDNotas.Droid
{
    public class AcessoArquivo
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename); //retorna o local one estará o banco:  Local: /usr/var/appEsqueci/data.db
        }
    }
}