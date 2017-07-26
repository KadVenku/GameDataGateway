using System.Collections.Generic;
using System.Xml;
using GameDataGateway.Model;
using GameDataGateway.Reader.Builder;

namespace GameDataGateway.Reader {
    public class TradeRouteFileReader : GameFileReader<TradeRoute> {

        private readonly List<TradeRoute> tradeRoutes = new List<TradeRoute>();
        private string currentNode;
        private TradeRouteBuilder builder;


        private readonly IEnumerable<Planet> planets;

        public TradeRouteFileReader(IEnumerable<Planet> planets) {
            this.planets = planets;
        }

        public IEnumerable<TradeRoute> ReadGameFile(string filePath) {
            XmlReader reader;
            using (reader = XmlReader.Create(filePath)) {
                while (reader.Read())
                    ReadNode(reader);
                reader.Close();
            }
            return tradeRoutes;
        }

        private void ReadNode(XmlReader reader) {
            switch (reader.NodeType) {
                case XmlNodeType.Element:
                    HandleElement(reader);
                    currentNode = reader.Name;
                    break;
                case XmlNodeType.EndElement:
                    HandleEndElement(reader);
                    break;
                case XmlNodeType.Text:
                    HandleText(currentNode, reader.Value);
                    break;
            }
        }

        private void HandleElement(XmlReader reader) {
            if (reader.Name == "TradeRoute") {
                builder = new TradeRouteBuilder(planets);
                if (reader.HasAttributes)
                    builder.AddAttribute("Name", reader.GetAttribute("Name"));
            }
        }

        private void HandleEndElement(XmlReader reader) {
            if (reader.Name == "TradeRoute") {
                tradeRoutes.Add(builder.GetTradeRoute());
                currentNode = string.Empty;
            }
        }

        private void HandleText(string nodeName, string value) {
            builder.AddAttribute(nodeName, value);
        }
    }
}
