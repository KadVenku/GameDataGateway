using System;
using GameDataGateway.Model;

namespace GameDataGateway.Repository {
    public class RepositoryChangedArgs : EventArgs {
        public RepositoryChangedArgs(GameObject gameObject, ChangeAction changeAction) {
            GameObject = gameObject;
            ChangeAction = changeAction;
        }

        public GameObject GameObject { get; private set; }
        public ChangeAction ChangeAction { get; private set; }
    }

    public enum ChangeAction {
        ADDED,
        REMOVED
    }
}