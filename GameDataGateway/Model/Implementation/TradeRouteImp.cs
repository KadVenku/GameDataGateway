namespace GameDataGateway.Model.Implementation {
    public class TradeRouteImp : IncompleteGameObject, TradeRoute {
        public Planet PointA { get; set; }
        public Planet PointB { get; set; }
        public string Name { get; set; }
    }
}