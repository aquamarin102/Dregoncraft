using System;
using Utils;

namespace UserControlSystem
{
    public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
    {
        private readonly ScriptableObjectValueBase<TAwaited> _scriptableObjectValueBase;
        private TAwaited _result;

        public NewValueNotifier(ScriptableObjectValueBase<TAwaited> scriptableObjectValueBase) : base()
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += ONNewValue;
        }

        private void ONNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= ONNewValue;
            _result = obj;
            SetComleted();
        }

        public override TAwaited GetResult() => _result;
    }
}