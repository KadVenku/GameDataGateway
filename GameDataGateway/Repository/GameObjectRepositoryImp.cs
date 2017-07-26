using System;
using System.Collections.Generic;
using GameDataGateway.Model;

namespace GameDataGateway.Repository {
    public class GameObjectRepositoryImp : GameObjectRepository {

        private readonly List<Planet> planets = new List<Planet>();
        private readonly List<TradeRoute> tradeRoutes = new List<TradeRoute>();

        public event EventHandler<RepositoryChangedArgs> RepositoryChanged;

        public IEnumerable<Planet> Planets => planets;

        public IEnumerable<TradeRoute> TradeRoutes => tradeRoutes;

        public void AddPlanet(Planet planet) {
            planets.Add(planet);
            var args = new RepositoryChangedArgs(planet, ChangeAction.ADDED);
            OnRepositoryChanged(args);
        }

        public void AddTradeRoute(TradeRoute tradeRoute) {
            tradeRoutes.Add(tradeRoute);
            var args = new RepositoryChangedArgs(tradeRoute, ChangeAction.ADDED);
            OnRepositoryChanged(args);
        }

        public void RemovePlanet(Planet planet) {
            planets.Remove(planet);
            var args = new RepositoryChangedArgs(planet, ChangeAction.REMOVED);
            OnRepositoryChanged(args);
        }

        public void RemoveTradeRoute(TradeRoute tradeRoute) {
            tradeRoutes.Remove(tradeRoute);
            var args = new RepositoryChangedArgs(tradeRoute, ChangeAction.REMOVED);
            OnRepositoryChanged(args);
        }

        private void OnRepositoryChanged(RepositoryChangedArgs args) {
            RepositoryChanged?.Invoke(this, args);
        }
    }
}

