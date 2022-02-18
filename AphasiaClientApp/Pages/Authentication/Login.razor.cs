﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AphasiaClientApp.Features.AuthService;
using AphasiaClientApp.Models.Auth;
using Microsoft.AspNetCore.Components;

namespace AphasiaClientApp.Pages.Authentication
{
    public partial class Login
    {
        private UserLoginModel userLoginModel = new UserLoginModel();
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowAuthError { get; set; }
        public string Error { get; set; }
        public async Task ExecuteLogin()
        {
            ShowAuthError = false;
            var result = await AuthenticationService.Login(userLoginModel);
            if (!result.IsAuthSuccessful)
            {
                Error = result.ErrorMessage;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
