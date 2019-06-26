using AppEquipos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEquipos.ViewModels
{
    class MainViewModel
    {
        #region Properties
        public TokenResponse Token
        {
            get; set;
        }

        #endregion

        #region ViewModels
        public TeamViewModel Login ///en caso de login
        {
            get; set;
        }
        public TeamViewModel Team
        {
            get; set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new TeamViewModel();

        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();

            }
            return instance;
        }

        #endregion
    }
}
