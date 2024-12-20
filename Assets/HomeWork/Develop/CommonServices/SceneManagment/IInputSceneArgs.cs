namespace Assets.HomeWork.Develop.CommonServices.SceneManagment
{
    public interface IInputSceneArgs
    {
    }

    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(ISelectCombination selectCombination)
        {
            SelectCombination = selectCombination;
        }

        public ISelectCombination SelectCombination { get; }
    }

    public class MainMenuInputArgs : IInputSceneArgs
    {
    }
}
