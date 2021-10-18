using System;
using System.Collections;

namespace Appalachia.Editing.Core.Windows.PaneBased.Context
{
    public abstract class AppalachiaWindowPaneContext
    {
        private const string _PRF_PFX = nameof(AppalachiaWindowPaneContext) + ".";

        private bool _initialized;

        private AppalachiaWindowPaneMenuSelectionMetadata[] _menuSelections;

        public abstract int RequiredMenuCount { get; }
        public bool initialized => _initialized;

        public void ChangeMenuSelection(int menuIndex, bool up)
        {
            OnBeforeChangeMenuSelection(menuIndex);

            throw new NotImplementedException();

            /*var menuSelection = _menuSelections[menuIndex];

            if (up)
            {
                menuSelection.currentIndex = Math.Max(0, menuSelection.currentIndex - 1);
            }
            else
            {
                menuSelection.currentIndex = Math.Min(
                    menuSelection.length - 1,
                    menuSelection.currentIndex + 1
                );
            }*/

            OnAfterChangeMenuSelection(menuIndex);
        }

        private void InitializeMenuSelections()
        {
            if (_menuSelections == null)
            {
                _menuSelections = new AppalachiaWindowPaneMenuSelectionMetadata[RequiredMenuCount];                
            }

            for (var menuIndex = 0; menuIndex < RequiredMenuCount; menuIndex++)
            {
                var current = _menuSelections[menuIndex];

                if (current == null)
                {
                    current = new AppalachiaWindowPaneMenuSelectionMetadata();
                    _menuSelections[menuIndex] = current;
                }
            }
        }
        
        public AppalachiaWindowPaneMenuSelectionMetadata GetMenuSelection(int menuIndex)
        {
            InitializeMenuSelections();
            
            return _menuSelections[menuIndex];
        }

        public abstract void ValidateMenuSelection(int menuIndex);

        public void Initialize()
        {
            if (_initialized)
            {
                return;
            }

            OnInitialize();

            InitializeMenuSelections();

            _initialized = true;
        }

        public void Reset()
        {
            OnReset();

            _menuSelections = null;
            _initialized = false;
        }

        protected abstract void OnInitialize();

        protected abstract void OnReset();

        // ReSharper disable once UnusedParameter.Global
        protected virtual void OnAfterChangeMenuSelection(int menuIndex)
        {
        }

        // ReSharper disable once UnusedParameter.Global
        protected virtual void OnBeforeChangeMenuSelection(int menuIndex)
        {
        }
    }
}
