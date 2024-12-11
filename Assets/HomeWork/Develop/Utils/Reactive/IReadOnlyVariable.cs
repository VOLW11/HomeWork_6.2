using System;

namespace Assets.HomeWork.Develop.Utils.Reactive
{
    public interface IReadOnlyVariable<T>
    {
        event Action<T, T> Changed;

        T Value { get; }
    }
}
