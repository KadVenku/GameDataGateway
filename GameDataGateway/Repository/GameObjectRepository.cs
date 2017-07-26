using System;
using System.Collections.Generic;
using GameDataGateway.Model;

namespace GameDataGateway.Repository {
    public interface GameObjectRepository {

        event EventHandler<RepositoryChangedArgs> RepositoryChanged;

        IEnumerable<Planet> Planets { get; }
        IEnumerable<TradeRoute> TradeRoutes { get; }

        void AddPlanet(Planet planet);
        void RemovePlanet(Planet planet);

        void AddTradeRoute(TradeRoute tradeRoute);
        void RemoveTradeRoute(TradeRoute tradeRoute);
    }
}
