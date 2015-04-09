﻿using ICities;
using SkylineToolkit.CitiesExtension;
using System;
using UnityEngine;

namespace SkylineToolkit
{
    public abstract class Mod : LoadingExtension, IMod
    {
        private bool gameAlreadyStarted = false;

        private bool inGame = false;

        static Mod()
        {
            EmbeddedAssembly.RegisterResolver();
        }

        public string Description
        {
            get
            {
                return ModDescription;
            }
        }

        public string Name
        {
            get
            {
                Log.Info("test " + this.GetType().Name);

                if (Application.loadedLevel == (int)Level.MainMenu)
                {
                    InternalOnMainMenuLoaded();
                }
                else if (!gameAlreadyStarted && !inGame)
                {
                    InternalOnApplicationStarted();
                    InternalOnMainMenuLoaded();

                    gameAlreadyStarted = true;
                }

                return String.Format("{0} [{1}]", ModName, Version);
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

        public abstract string Version
        {
            get;
        }

        public abstract string Author
        {
            get;
        }

        private void InternalOnApplicationStarted()
        {
            OnApplicationStarted();
        }

        private void InternalOnMainMenuLoaded()
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
