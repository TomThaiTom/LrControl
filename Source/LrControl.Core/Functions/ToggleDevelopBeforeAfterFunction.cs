﻿using LrControl.Api;
using LrControl.Api.Modules.LrApplicationView;

namespace LrControl.Core.Functions
{
    internal class ToggleDevelopBeforeAfterFunction : Function
    {
        private bool _toggled;

        public ToggleDevelopBeforeAfterFunction(LrApi api, string displayName, string key) : base(api, displayName, key)
        {
        }

        protected override void ControllerChanged(int controllerValue)
        {
            if (controllerValue != (int) Controller.Range.Maximum) return;

            if (_toggled)
            {
                Api.LrApplicationView.ShowView(PrimaryView.DevelopLoupe);
                ShowHud("After");
                _toggled = false;
            }
            else
            {
                Api.LrApplicationView.ShowView(PrimaryView.DevelopBefore);
                ShowHud("Before");
                _toggled = true;
            }
        }
    }
}