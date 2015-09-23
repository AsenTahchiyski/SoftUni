using WinterIsComing.Core.Commands;

namespace WinterIsComing.Core
{
    public class CommandDispatcherExtension : CommandDispatcher
    {
        public override void SeedCommands()
        {
            base.SeedCommands();
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
        }
    }
}
