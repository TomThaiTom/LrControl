using LrControl.Configurations;
using LrControl.Core.Configurations;
using LrControl.LrPlugin.Api;
using LrControl.LrPlugin.Api.Common;

namespace LrControl.Core.Functions
{
    internal class UndoRedoFunction : Function
    {
        private readonly Operation _operation;

        public UndoRedoFunction(ISettings settings, ILrApi api, string displayName, string key, Operation operation) 
            : base(settings, api, displayName, key)
        {
            _operation = operation;
        }

        public override void Apply(int value, Range range)
        {
            if (!range.IsMaximum(value)) return;

            switch (_operation)
            {
                case Operation.Undo:
                    if (Api.LrUndo.CanUndo(out var canUndo) && canUndo)
                    {
                        Api.LrDevelopController.StopTracking();
                        Api.LrUndo.Undo();
                    }
                    break;
                case Operation.Redo:
                    if (Api.LrUndo.CanRedo(out var canRedo) && canRedo)
                    {
                        Api.LrDevelopController.StopTracking();
                        Api.LrUndo.Redo();
                    }
                    break;
            }
        }

        public enum Operation
        {
            Undo,
            Redo
        }
    }
}