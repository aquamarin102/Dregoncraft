using UserControlSystem;
using UniRx;

namespace Abstractions
{
    public abstract class ScriptableObjectStatefullBase<T> : ScriptableObjectValueBase<T>
    {
        public ReactiveProperty<T> ReactiveValue;

        public override void SetValue(T value)
        {
            base.SetValue(value);

            ReactiveValue.Value = value;
        }
    }
}