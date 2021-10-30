using ContagemAssistencia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContagemAssistencia.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarTemaView : ContentPage
	{
		EditarTemaViewModel vm;
		public EditarTemaView ()
		{
			vm = new EditarTemaViewModel();
			InitializeComponent ();
			BindingContext = vm;
		}
	}
}