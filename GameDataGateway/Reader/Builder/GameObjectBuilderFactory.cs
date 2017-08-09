using GameDataGateway.Repository;

namespace GameDataGateway.Reader.Builder {
    public class GameObjectBuilderFactory {
        readonly GameObjectRepository repository;

        public GameObjectBuilderFactory(GameObjectRepository repository) {
            this.repository = repository;
        }

        public GameObjectBuilder CreateBuilder(string objectType) {
            switch (objectType) {
                case "Planet":
                    return new IncompletePlanetBuilder();
                case "TradeRoute":
                    return new IncompleteTradeRouteBuilder(repository.Planets);
                default:
                    return null;
            }
        }
    }
}
