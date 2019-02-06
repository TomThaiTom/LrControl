using System.Collections.Generic;
using LrControl.Devices;
using LrControl.Functions;
using LrControl.LrPlugin.Api.Common;
using LrControl.LrPlugin.Api.Modules.LrApplicationView;
using LrControl.LrPlugin.Api.Modules.LrDevelopController;

namespace LrControl.Profiles
{
    public class ModuleProfile : IModuleProfile
    {
        protected readonly Dictionary<ControllerId, IFunction> Functions = new Dictionary<ControllerId, IFunction>();
    
        public virtual Module Module { get; }

        public ModuleProfile(Module module)
        {
            Module = module;
        }

        public void AssignFunction(in ControllerId controllerId, IFunction function)
        {
            Functions[controllerId] = function;
        }

        public void ClearFunction(in ControllerId controllerId)
        {
            Functions.Remove(controllerId);
        }

        public virtual void ApplyFunction(in ControllerId controllerId, int value, Range range, Module activeModule, Panel activePanel)
        {
            if (TryGetFunction(controllerId, out var function))
            {
                function.Apply(value, range, activeModule, activePanel);
            }
        }

        public virtual bool HasFunction(in ControllerId controllerId)
            => Functions.ContainsKey(controllerId);

        public virtual IEnumerable<(ControllerId, ParameterFunction)> GetParameterFunctions(IParameter parameter)
        {
            foreach (var entry in Functions)
            {
                if (entry.Value is ParameterFunction parameterFunction &&
                    ReferenceEquals(parameterFunction.Parameter, parameter))
                {
                    yield return (entry.Key, parameterFunction);
                }
            }
        }

        protected virtual bool TryGetFunction(in ControllerId controllerId, out IFunction function)
            => Functions.TryGetValue(controllerId, out function);
    }
}