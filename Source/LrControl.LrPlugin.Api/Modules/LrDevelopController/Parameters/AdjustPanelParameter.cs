﻿namespace LrControl.LrPlugin.Api.Modules.LrDevelopController.Parameters
{
    public class AdjustPanelParameter : ParameterGroup
    {
        public readonly IParameter<WhiteBalanceValue> WhiteBalance       = new Parameter<WhiteBalanceValue>("WhiteBalance", "Whitebalance");
        public readonly IParameter<double> Temperature                   = new Parameter<double>("Temperature", "Whitebalance: Temperature");
        public readonly IParameter<double> Tint                          = new Parameter<double>("Tint", "Whitebalance: Tint");
        public readonly IParameter<double> Exposure                      = new Parameter<double>("Exposure", "Tone: Exposure");
        public readonly IParameter<int> Contrast                         = new Parameter<int>("Contrast", "Tone: Contrast");
        public readonly IParameter<int> Highlights                       = new Parameter<int>("Highlights", "Tone: Highlights");
        public readonly IParameter<int> Shadows                          = new Parameter<int>("Shadows", "Tone: Shadows");
        public readonly IParameter<int> Whites                           = new Parameter<int>("Whites", "Tone: Whites");
        public readonly IParameter<int> Blacks                           = new Parameter<int>("Blacks", "Tone: Blacks");
        public readonly IParameter<int> Clarity                          = new Parameter<int>("Clarity", "Presence: Clarity");
        public readonly IParameter<int> Vibrance                         = new Parameter<int>("Vibrance", "Presence: Vibrance");
        public readonly IParameter<int> Saturation                       = new Parameter<int>("Saturation", "Presence: Saturation");

        internal AdjustPanelParameter() : base("Basic")
        {
            AddParameters(WhiteBalance, Temperature, Tint, Exposure, Contrast, Highlights, Shadows, Whites, Blacks,
                Clarity, Vibrance, Saturation);
        }
    }
}