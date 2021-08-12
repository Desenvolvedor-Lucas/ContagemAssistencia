using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContagemAssistencia.Models;
using ContagemAssistencia.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContagemAssistencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarView : ContentPage
    {
        //Vairiaveis
        AdicionarViewModel ViewModel;


        //Construdor
        public AdicionarView(AssistenciaViewModel assistencia)
        {
            ViewModel = new AdicionarViewModel(assistencia);

            InitializeComponent();
            BindingContext = ViewModel;
        }

        //Metodos

        //Onappearing() para receber e subescrever a msg enviada da ViewModel
        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ICommand>(this, "NavegarAssistencia", 
                (msg) =>
                {
                    if(ViewModel.EuPossoNavega)
                        Navigation.PopAsync();
                });

            MessagingCenter.Subscribe<AdicionarViewModel>(this, "Atencao", 
                (msg) =>
                {
                    DisplayAlert($"{ABC_Translate.AppResources.AlertTitleAttentionNM}",$"{ABC_Translate.AppResources.AlertAttentionNMMenssage}",
                        $"{ABC_Translate.AppResources.AlertAttentionNMAnswer}");
                });

        }

        //OnDisappearing() para cancelar a msg recebida depois de utilizada 
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<string>(this, "NavegarAssistencia");
            MessagingCenter.Unsubscribe<string>(this, "Atencao");

        }

    }
}