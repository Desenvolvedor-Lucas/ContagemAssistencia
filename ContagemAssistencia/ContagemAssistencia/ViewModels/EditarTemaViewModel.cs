
using System.Windows.Input;
using Xamarin.Forms;

namespace ContagemAssistencia.ViewModels
{
    //acho que só falta dar um revisada pra ficar bonito nas cores e pronto
    public class EditarTemaViewModel 
    {
        public ICommand TemaPadrao { get; set; }
        public ICommand TemaClaro { get; set; }
        public ICommand TemaEscuro { get; set; }
        public ICommand TemaAltoContrasteClaro { get; set; }
        public ICommand TemaAltoContrasteEscuro { get; set; }

        public EditarTemaViewModel()
        {
            TemaPadrao = new Command(() => { DefineTemaPadrao_0(); });
            TemaClaro = new Command(() => { DefineTemaClaro_1(); });
            TemaEscuro = new Command(() => { DefineTemaEscuro_2(); });
            TemaAltoContrasteClaro = new Command(() => { DefineTemaAltoContrasteClaro_3(); });
            TemaAltoContrasteEscuro = new Command(() => { DefineTemaAltoContrasteEscuro_4(); });
        }

        private void DefineTemaPadrao_0()
        {
            var DefaultTheme = ThemeManager.Themes.Default;
            ThemeManager.ChangeTheme(DefaultTheme);
        }

        private void DefineTemaClaro_1()
        {
            var LightTheme = ThemeManager.Themes.Light;
            ThemeManager.ChangeTheme(LightTheme);
        }

        private void DefineTemaEscuro_2()
        {
            var DarkTheme = ThemeManager.Themes.Dark;
            ThemeManager.ChangeTheme(DarkTheme);
        }

        private void DefineTemaAltoContrasteClaro_3()
        {
            var BlueTheme = ThemeManager.Themes.Blue;
            ThemeManager.ChangeTheme(BlueTheme);
        }

        private void DefineTemaAltoContrasteEscuro_4()
        {
            var OrangeTheme = ThemeManager.Themes.Orange;
            ThemeManager.ChangeTheme(OrangeTheme);
        }

    }
}
