﻿using System;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.MobileBlazorBindings;
using Microsoft.MobileBlazorBindings.WebView;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BlazorHybridApp
{
    public class App : Application
    {
        public App()
        {
            BlazorHybridHost.AddResourceAssembly(GetType().Assembly, contentRoot: "WebUI/wwwroot");

            var host = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Adds web-specific services such as NavigationManager
                    services.AddBlazorHybrid();
                    // Register app-specific services
                    services.AddSingleton<AppState>();
                })
                .Build();

            MainPage = new ContentPage { Title = "My Application" };
            host.AddComponent<Main>(parent: MainPage);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
