using ContagemAssistencia.Models;
using ContagemAssistencia.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ContagemAssistencia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisualizarView : ContentPage
    {
        //Variaveis
        VisualizarViewModel ViewModel;


        //construdor
        public VisualizarView(Label total, ObservableCollection<UsuarioAssistencia> lista)
        {
            ViewModel = new VisualizarViewModel(total, lista);

            InitializeComponent();

            BindingContext = ViewModel;
        }

        //METODOS

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ICommand>(this, "CompartilharAssistencia",
                async (msg) =>
                {
                    await Share.RequestAsync(new ShareTextRequest
                    {
                        Text = ViewModel.CompartilharTextofomartado,
                        Title = $"{ABC_Translate.AppResources.TitleShare}"
                    });
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<ICommand>(this, "CompartilharAssistencia");
        }
    }

}