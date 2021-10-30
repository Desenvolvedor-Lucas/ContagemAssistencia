using ContagemAssistencia.Models;
using ContagemAssistencia.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContagemAssistencia.ViewModels 
{
    public class AssistenciaViewModel
    {
        //Variaveis e Referencias
        public AdicionarViewModel Adicionar;
        public List<int> ListaAssistenciaNumero = new List<int>();
        public List<string> ListaAssistenciaTexto = new List<string>();


        //Propriedades
        public string Data { get; set; }
        public Label Total { get; set; }
        public ObservableCollection<UsuarioAssistencia> ListaAssistencia { get; set; }
        

        //Propriedades de Comandos
        public ICommand NavegarVisualizarCommand { get; set; }
        public ICommand NavegarAdicionarCommand { get; set; }
        public ICommand NavegarEditarTemaCommand { get; set; }


        //construdor
        public AssistenciaViewModel()
        {
            Total = new Label();
            Adicionar = new AdicionarViewModel(this);
            ListaAssistencia = new ObservableCollection<UsuarioAssistencia>();

            Total.Text = "0";
            Data = System.DateTime.Now.Date.ToString("dd/MM/yyyy");

            for(var i = 0; i < 50; i++)
                ListaAssistencia.Add(new UsuarioAssistencia { NomeNumero = ""});

            NavegarAdicionarCommand = new Command(async() =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AdicionarView(this));
            });

            NavegarVisualizarCommand = new Command(async() => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new VisualizarView(Total, ListaAssistencia));
            });

            NavegarEditarTemaCommand = new Command(async() => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new EditarTemaView());
            });
        }


        //METODOS

        //AtualizaAssistencia() para atualizar os items de ListaAssistencia
        public void AtualizaAssistencia()
        {
            ListaAssistencia.Clear();
            for (int i = 0; i < ListaAssistenciaTexto.Count; i++)
                ListaAssistencia.Add(new UsuarioAssistencia { NomeNumero = $"{ListaAssistenciaTexto[i]}" });

        }

    }
}
