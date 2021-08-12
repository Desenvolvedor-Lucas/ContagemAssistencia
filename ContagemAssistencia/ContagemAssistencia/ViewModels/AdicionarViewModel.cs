using ContagemAssistencia.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContagemAssistencia.ViewModels
{
    public class AdicionarViewModel
    {
        //Variaveis
        public int Resultado;
        public bool EuPossoNavega;


        //Propriedades
        public string Nome { get; set; }
        public int Numero { get; set; }
        public AssistenciaViewModel Assistencia { get; set; }
        

        //Propriedades de comandos
        public ICommand NavegaEAdicionaCommand { get; set; }


        //construdor
        public AdicionarViewModel(AssistenciaViewModel assistencia)
        {
            Assistencia = assistencia;

            NavegaEAdicionaCommand = new Command(() => 
            {
                AdicionarAssistencia();
                MessagingCenter.Send<ICommand>(NavegaEAdicionaCommand, "NavegarAssistencia");
            });
        }


        //METODOS

        //AdicionarAssistencia() para Adicionar Nome e Numero nas Listas de AssistenciaNumero e AssistenciaTexto
        public void AdicionarAssistencia()
        {
            if ((Numero > 0) && (Nome != ""))
            {
                EuPossoNavega = true;
                Assistencia.ListaAssistenciaTexto.Add($"{Nome} = {Numero}");
                Assistencia.ListaAssistenciaNumero.Add(Numero);
            }
            else
            {
                EuPossoNavega = false;
                MessagingCenter.Send<AdicionarViewModel>(this, $"Atencao");
            }

            CalcularResultatoTotal();
            Assistencia.AtualizaAssistencia();
        }


        //CalcularResultatoTotal() para calcular o resultado total da assistencia
        public void CalcularResultatoTotal()
        {
            Resultado = 0;

            for (int i = 0; i < Assistencia.ListaAssistenciaNumero.Count; i++)
                Resultado += Assistencia.ListaAssistenciaNumero[i];

            Assistencia.Total.Text = Resultado.ToString();
        }
    }
}
