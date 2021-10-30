using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContagemAssistencia.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true)]

    public class SplashActivity : Activity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        // Lança a tarefa de inicialização
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simula o trabalho de fundo que acontece atrás da tela de respingo
        async void SimulateStartup()  //Simula inicialização
        {
           
            await Task.Delay(0); //1s = 1000 Simule um pouco do trabalho de inicialização.
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}