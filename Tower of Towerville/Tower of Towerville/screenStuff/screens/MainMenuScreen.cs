using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.screenStuff.screenManager;

namespace Tower_of_Towerville.screenStuff.screens
{
    class MainMenuScreen : MenuScreen
    {
        public MainMenuScreen()
            : base("Main Menu")
        {
            MenuEntry playGameMenuEntry = new MenuEntry("Play Game");
            MenuEntry exitMenuEntry = new MenuEntry("Exit");

            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }

        void PlayGameMenuEntrySelected(object sender, EventArgs e)
        {
            
        }

        void OnCancel(object sender, EventArgs e)
        {
            ScreenMngr.Game.Exit();
        }

    }
}
