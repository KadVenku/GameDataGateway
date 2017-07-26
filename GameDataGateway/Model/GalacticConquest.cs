using System.Collections.Generic;

namespace GameDataGateway.Model {
    public interface GalacticConquest : GameObject {
        string CampaignSet { get; set; }
        IEnumerable<Planet> Planets { get; }
        IEnumerable<TradeRoute> TradeRoutes { get; }
    }
}
