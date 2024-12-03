namespace Assets.HomeWork.Develop.CommonServices.SceneManagment
{
    public interface IInputSceneArgs
    {
    }

    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(int levelNumber, ISelectCombination selectCombination)
        {
            LevelNumber = levelNumber;
            SelectCombination = selectCombination;
        }

        public int LevelNumber { get; }
        public ISelectCombination SelectCombination { get; }
    }

    public class MainMenuInputArgs : IInputSceneArgs
    {
    }
}
