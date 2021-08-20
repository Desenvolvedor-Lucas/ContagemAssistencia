using ContagemAssistencia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ContagemAssistencia.ViewModels;
using System.Windows.Input;

namespace ContagemAssistencia.Views
{
    public partial class AssistenciaView : ContentPage
    {
        //Propriedades
        public AssistenciaViewModel ViewModel { get; set; }


        //Construdor
        public AssistenciaView()
        {
            ViewModel = new AssistenciaViewModel();

            InitializeComponent();

            BindingContext = ViewModel;
        }


        //METODOS

        //ListView_ItemTapped(...) quando um item da ListaAssistencia é clicado
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (ViewModel.ListaAssistencia[e.ItemIndex].NomeNumero != "")
            {
                bool TevoRemove = await DisplayAlert($"{ViewModel.ListaAssistenciaTexto[e.ItemIndex]}", 
                    $"{ABC_Translate.AppResources.AlertDeleteMessage}",
                    $"{ABC_Translate.AppResources.AlertDeleteAnswerTrue}", 
                    $"{ABC_Translate.AppResources.AlertDeleteAnswerFalse}");

                if (TevoRemove)
                {
                    ViewModel.ListaAssistencia.RemoveAt(e.ItemIndex);
                    ViewModel.ListaAssistenciaTexto.RemoveAt(e.ItemIndex);
                    ViewModel.ListaAssistenciaNumero.RemoveAt(e.ItemIndex);
                }
                ViewModel.Adicionar.AdicionarAssistencia();
            }
            else
            {
                bool TevoRemover = await DisplayAlert($"{ABC_Translate.AppResources.AlertTitleAttentionDelete}", 
                    $"{ABC_Translate.AppResources.AlertAttentionDeleteMessage}", 
                    $"{ABC_Translate.AppResources.AlertAttentionDeleteAnswerTrue}", 
                    $"{ABC_Translate.AppResources.AlerAttentiontDeleteAnswerFalse}");

                if (TevoRemover)
                {
                    await Navigation.PushAsync(new AdicionarView(ViewModel));
                }
                else
                {
                    ViewModel.ListaAssistencia.Clear();
                    for (var i = 0; i < 50; i++)
                        ViewModel.ListaAssistencia.Add(new UsuarioAssistencia { NomeNumero = "" });
                }
            }
        }


        //Onappearing() para receber e subescrever a msg enviada da ViewModel
        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ICommand>(this, "NavegarAdicionar", 
                async (msg) =>
                {
                    await Navigation.PushAsync(new AdicionarView(ViewModel));
                });

            MessagingCenter.Subscribe<ICommand>(this, "NavegarVisualizar", 
                async (msg) =>
                {
                    await Navigation.PushAsync(new VisualizarView(ViewModel.Total, ViewModel.ListaAssistencia));
                });

        }


        //OnDisappearing() para cancelar a msg recebida depois de utilizada 
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<ICommand>(this, "NavegarAdicionar");
            MessagingCenter.Unsubscribe<ICommand>(this, "NavegarVisualizar");

        }

    }
}
