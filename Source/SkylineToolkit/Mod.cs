﻿using ICities;
using SkylineToolkit.CitiesExtension;
using UnityEngine;

namespace SkylineToolkit
{
    public abstract class Mod : LoadingExtension, IMod
    {
        private bool gameAlreadyStarted = false;

        private bool inGame = false;

        public string Description
        {
            get
            {
                return ModName;
            }
        }

        public string Name
        {
            get
            {
                if (Application.loadedLevel == (int)Level.MainMenu)
                {
                    MyOnMainMenuLoaded();
                }
                else if (!gameAlreadyStarted && !inGame)
                {
                    MyOnApplicationStarted();
                    MyOnMainMenuLoaded();

                    gameAlreadyStarted = true;
                }

                return ModDescription;
            }
        }

        public abstract string ModName
        {
            get;
        }

        public abstract string ModDescription
        {
            get;
        }

        private void MyOnApplicationStarted()
        {
            OnApplicationStarted();
        }

        private void MyOnMainMenuLoaded()
        {
            OnMainMenuLoaded();
        }

        public override void OnCreated(ILoading loading)
        {
            inGame = true;

            base.OnCreated(loading);
        }

        public override void OnReleased()
        {
        }

        protected virtual void OnApplicationStarted()
        {
        }

        protected virtual void OnMainMenuLoaded()
        {
        }
    }
}
