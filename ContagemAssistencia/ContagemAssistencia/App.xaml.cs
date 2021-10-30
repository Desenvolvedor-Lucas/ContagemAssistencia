using ContagemAssistencia.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContagemAssistencia
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ThemeManager.LoadTheme();

            MainPage = new NavigationPage(new AssistenciaView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
