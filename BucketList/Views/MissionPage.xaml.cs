using BucketList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MissionPage : ContentPage
    {
        MissionViewModel viewModel;
        public MissionPage()
        {
            InitializeComponent();
            viewModel = BindingContext as MissionViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (string.IsNullOrEmpty(viewModel.MissionStatement))
                viewModel.LoadMissionCommand.Execute(null);

        }
    }
}