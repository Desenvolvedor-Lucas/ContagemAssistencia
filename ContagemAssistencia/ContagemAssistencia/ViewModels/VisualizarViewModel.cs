using ContagemAssistencia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContagemAssistencia.ViewModels
{
    public class VisualizarViewModel
    {
        //Variaveis referencias
        public string CompartilharTextofomartado;
        public List<string> ListaAssistenciaFormatada = new List<string>();


        //Propriedades
        public string VisualizaData { get; set; }
        public Label VisualizaTotal { get; set; }
        public ObservableCollection<UsuarioAssistencia> VisualizaListaAssistencia { get; set; }


        //Propriedade de Comandos
        public ICommand CompartilharCommand { get; set; }


        //Construdor
        public VisualizarViewModel(Label total, ObservableCollection<UsuarioAssistencia> lista)
        {
            VisualizaListaAssistencia = new ObservableCollection<UsuarioAssistencia>();

            VisualizaData = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
            VisualizaTotal = total;

            AdicionarListaOrdemAlfabetica(lista);

            CompartilharAssitenciaFormadoTexto(ListaAssistenciaFormatada);

            CompartilharCommand = new Command(() =>
            {
                MessagingCenter.Send<ICommand>(CompartilharCommand, "CompartilharAssistencia");
            });
        }


        //METODOS

        //AdicionarListaOrdemAlfabetica(...) para Adicionar a lista em ordem alfabetica
        private void AdicionarListaOrdemAlfabetica(ObservableCollection<UsuarioAssistencia> lista)
        {
            var ListaAssistenciaOrdenada = lista.OrderBy(m => m.NomeNumero);

            ListaAssistenciaFormatada.Clear();
            
            foreach (var item in ListaAssistenciaOrdenada)
            {
                if (item != null)
                {
                    string textoordenado = item.NomeNumero;
                    ListaAssistenciaFormatada.Add($"{textoordenado}");
                    VisualizaListaAssistencia.Add(new UsuarioAssistencia { NomeNumero = $"{textoordenado}" });
                }
            }
        }


        //CompartilharAssitenciaFormadoTexto(...) para arrumar o texto que vai ser compartilhado
        public void CompartilharAssitenciaFormadoTexto(List<string> Listatexto)
        {
            CompartilharTextofomartado = "";
            CompartilharTextofomartado += $"*{ABC_Translate.AppResources.Date} : {VisualizaData}* \n";
            CompartilharTextofomartado += $"*{ABC_Translate.AppResources.Total} {VisualizaTotal.Text}* \n \n";
            CompartilharTextofomartado += $"*{ABC_Translate.AppResources.TitleAssists}* \n \n";
            
            for(int i = 0; i < Listatexto.Count; i++)
            {
                CompartilharTextofomartado += Listatexto[i] + "\n";
            }
            
        }
    }
}
