﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;

namespace AphasiaClientApp.Extensions.Navigation
{
    public class Navigation : IDisposable
    {
        private const int MinHistorySize = 256;
        private const int AdditionalHistorySize = 64;
        private readonly NavigationManager _navigationManager;
        private readonly List<string> _history;

        public Navigation(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _history = new List<string>(MinHistorySize + AdditionalHistorySize);
            _history.Add(_navigationManager.Uri);
            _navigationManager.LocationChanged += OnLocationChanged;
        }

        public void NavigateTo(string url) => _navigationManager.NavigateTo(url);

        public bool CanNavigateBack => _history.Count >= 2;

        public void Dispose() =>
            _navigationManager.LocationChanged -= OnLocationChanged;

        public void NavigateBack()
        {
            if (!CanNavigateBack) return;
            var backPageUrl = _history[^2];
            _history.RemoveRange(_history.Count - 2, 2);
            _navigationManager.NavigateTo(backPageUrl);
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            EnsureSize();
            _history.Add(e.Location);
        }

        private void EnsureSize()
        {
            if (_history.Count < MinHistorySize + AdditionalHistorySize) return;
            _history.RemoveRange(0, _history.Count - MinHistorySize);
        }
    }
}
