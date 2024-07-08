using Infrastructure.Attributes;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 1)]
    public class SetNextLevelAction : ButtonAction
    {
        private LevelsService _levelsService;

        public override void Action()
        {
            _levelsService.SetNextLevel();
        }

        protected override void Initialize()
        {
            _levelsService = ServiceLocator.GetService<LevelsService>();
        }
    }
}