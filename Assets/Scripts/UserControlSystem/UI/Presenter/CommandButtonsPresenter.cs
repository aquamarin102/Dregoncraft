using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UniRx;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using UserControlSystem.ModelCommand;
using UserControlSystem.UI.View;
using Utils;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [Inject] private CommandButtonsModel _model;
        private ISelectable _currentSelectable;

        private void Start()
        {
            MessageBroker.Default.Receive<ICommandExecutor>().Subscribe(i => _model.OnCommandButtonClicked(i));
            MessageBroker.Default.Receive<ModelOnCommandSent>().Subscribe(_ => _view.UnblockAllInteractions());
            MessageBroker.Default.Receive<ModelOnCommandCancel>().Subscribe(_ => _view.UnblockAllInteractions());
            MessageBroker.Default.Receive<ModelOnCommandAccepted>().Subscribe(command => _view.BlockInteractions(command.commandExecutor));


            _selectable.ReactiveValue.Subscribe(selectable => ONSelected(selectable));
            ONSelected(_selectable.CurrentValue);
        }


        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            if (_currentSelectable != null)
            {
                _model.OnSelectionChanged();
            }
            _currentSelectable = selectable;

            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }
    }
}