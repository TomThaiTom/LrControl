﻿using LrControl.LrPlugin.Api.Common;

namespace LrControl.LrPlugin.Api.Modules.LrDevelopController
{
    public class Tool : Enumeration<Tool,string>
    {
        public static readonly Tool Loupe               = new Tool("loupe", "Loupe");
        public static readonly Tool Crop                = new Tool("crop", "Crop");
        public static readonly Tool SpotRemoval         = new Tool("dust", "Spot Removal");
        public static readonly Tool RedEye              = new Tool("redeye", "Red Eye Correction");
        public static readonly Tool GraduatedFilter     = new Tool("gradient", "Graduated Filter");
        public static readonly Tool RadialFilter        = new Tool("circularGradient", "Radial Filter");
        public static readonly Tool AdjustmentBrush     = new Tool("localized", "Adjustment Brush");

        
        private Tool(string value, string name) : base(value, name)
        {
        }
    }
}