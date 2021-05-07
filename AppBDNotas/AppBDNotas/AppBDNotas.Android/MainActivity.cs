using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace AppBDNotas.Droid
{
    [Activity(Label = "AppBDNotas", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            //criação no banco de Dados
            string dbName = "dbAula3";

            //retorno no local de armazenamento do BD
            string dbPath = AcessoArquivo.GetLocalFilePath(dbName);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //LoadApplication(new App());

            //Passagem de parametro pelo construtor da pagina do local e nome do BD
            LoadApplication(new App(dbPath, dbName));

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}