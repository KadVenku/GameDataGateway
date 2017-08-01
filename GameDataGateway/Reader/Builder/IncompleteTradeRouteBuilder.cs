using System;
using System.Collections.Generic;
using GameDataGateway.Model;

namespace GameDataGateway.Reader.Builder {

    public class IncompleteTradeRouteBuilder : TradeRouteBuilder, IncompleteGameObjectBuilder {
        private readonly List<string> usedElements = new List<string> { "Name", "Point_A", "Point_B" };

        public IncompleteTradeRouteBuilder(IEnumerable<Planet> planets) : base(planets) {
        }

        public void AddXmlString(string xmlString) {
            var incompleteTradeRoute = tradeRoute as IncompleteGameObject;
            incompleteTradeRoute.SaveString(xmlString);
        }

        public bool usesElement(string element) {
            return usedElements.Contains(element);
        }
    }
}
