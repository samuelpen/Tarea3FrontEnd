using AppEquipos.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AppEquipos.Services;
using Xamarin.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
namespace AppEquipos.ViewModels
{
    

        class TeamViewModel : BaseViewModel
        {
            #region Services

            private ApiService apiService;
            #endregion


            #region Attributes

            private ObservableCollection<Team> team;
            private bool isRefreshing;
            #endregion


            #region Properties
            public ObservableCollection<Team> Team
            {
                get { return this.team; }
                set { SetValue(ref this.team, value); }
            }

            public bool IsRefreshing
            {
                get { return this.isRefreshing; }
                set { SetValue(ref this.isRefreshing, value); }
            }
            #endregion



            #region Constructors

            public TeamViewModel()
            {
                this.apiService = new ApiService();
                this.LoadTeams();
            }

            #endregion


            #region Methods
            private async void LoadTeams()
            {
                this.IsRefreshing = true;
                var connection = await this.apiService.CheckConnection();
                if (!connection.IsSuccess)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert(
                       "Error", connection.Message,
                       "Aceptar");
                    return;
                    await Application.Current.MainPage.Navigation.PopAsync();
                }

                var response = await this.apiService.GetList<Team>(
                    "https://www.scorebat.com",
                    "/video-api",
                    "/v1");
                if (!response.IsSuccess)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error", response.Message,
                        "Aceptar");
                    return;
                }
                var list = (List<Team>)response.Result;
                this.Team = new ObservableCollection<Team>(list);
                this.IsRefreshing = false;
            }
            #endregion

            #region Commands
            public ICommand RefreshCommand
            {
                get
                {
                    return new RelayCommand(LoadTeams);

                }
            }
            #endregion
        }


    
}
