using System.Collections.Generic;
using System.Linq;
using GameDataGateway.Model;
using GameDataGateway.Model.Implementation;

namespace GameDataGateway.Reader.Builder {
    public class TradeRouteBuilder : GameObjectBuilder {
        private readonly IEnumerable<Planet> planets;
        private TradeRoute tradeRoute;

        private readonly List<string> usedElements = new List<string> {"Name", "Point_A", "Point_B"};

        public TradeRouteBuilder(IEnumerable<Planet> planets) {
            this.planets = planets;
        }

        public void AddAttribute(string attributeName, string content) {
            if (tradeRoute == null) tradeRoute = CreateTradeRoute();

            switch (attributeName) {
                case "Name":
                    tradeRoute.Name = content;
                    break;
                case "Point_A":
                    tradeRoute.PointA = planets.First(p => p.Name == content);
                    break;
                case "Point_B":
                    tradeRoute.PointB = planets.First(p => p.Name == content);
                    break;
            }
        }

        public bool usesElement(string element) {
            return usedElements.Contains(element);
        }

        protected virtual TradeRoute CreateTradeRoute() {
            return new TradeRouteImp();
        }

        public GameObject GetGameObject() {
            return tradeRoute;
        }
    }
}