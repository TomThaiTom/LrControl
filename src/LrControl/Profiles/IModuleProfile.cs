using LrControl.Devices;
using LrControl.Functions;
using LrControl.LrPlugin.Api.Common;
using LrControl.LrPlugin.Api.Modules.LrApplicationView;

namespace LrControl.Profiles
{
    public interface IModuleProfile
    {
        Module Module { get; }

        void AssignFunction(in ControllerId controllerId, IFunction function);
        void ClearFunction(in ControllerId controllerId);
        void OnControllerInput(in ControllerId controllerId, int value, Range range);
    }
}