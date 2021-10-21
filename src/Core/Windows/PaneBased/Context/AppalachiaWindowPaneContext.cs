using System;
using System.Collections;

namespace Appalachia.Editing.Core.Windows.PaneBased.Context
{
    public abstract class AppalachiaWindowPaneContext
    {
        protected const string G_ = "Appalachia/Editor Windows";
        private const string _PRF_PFX = nameof(AppalachiaWindowPaneContext) + ".";

        private bool _initialized;

        private AppalachiaWindowPaneMenuSelectionMetadata[] _menuSelections;

        public abstract int RequiredMenuCount { get; }
        public bool initialized => _initialized;

        public bool ChangeMenuSelection(int menuIndex, bool up)
        {
            OnBeforeChangeMenuSelection(menuIndex);

            var menuSelection = GetMenuSelection(menuIndex);

            var visibleIndex = menuSelection.currentVisibleIndex;

            if (up && (visibleIndex == 0))
            {
                return false;
            }
            
            if (!up && (visibleIndex >= (menuSelection.visibleCount - 1)))
            {
                return false;
            }

            var nextVisibleIndex = visibleIndex + (up ? -1 : 1);

            var nextIndex = menuSelection.GetIndex(nextVisibleIndex);

            menuSelection.SetSelected(nextIndex);
            
            OnAfterChangeMenuSelection(menuIndex);

            return true;
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
            _menuSelections = null;
            _initialized = false;
            
            OnReset();
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
