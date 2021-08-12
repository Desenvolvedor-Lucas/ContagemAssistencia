using ContagemAssistencia.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContagemAssistencia
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

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
