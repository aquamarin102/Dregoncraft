using UniRx;

namespace Core
{
    public class PauseModel
    {
        public ReactiveProperty<bool> pause;

        public PauseModel()
        {
            pause = new ReactiveProperty<bool>();
            pause.Value = false;
        }

        public bool IsPause => pause.Value;

        public void SetPause(bool newValue)
        {
            pause.Value = newValue;
        }
    }
}