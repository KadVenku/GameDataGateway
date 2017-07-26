using System.Collections.Generic;
using System.Xml;
using GameDataGateway.Model;
using GameDataGateway.Reader.Builder;

namespace GameDataGateway.Reader {
    public class GenericGameObjectFileReader<T> where T : GameObject {

        private readonly List<T> gameObjects = new List<T>();
        private readonly string objectType;
        private string currentNode;

        private readonly GameObjectBuilderFactory factory;
        private GameObjectBuilder builder;

        public GenericGameObjectFileReader(string objectName, GameObjectBuilderFactory factory) {
            this.factory = factory;
            this.objectType = objectName;
        }

        public IEnumerable<T> ReadGameFile(string filePath) {
            XmlReader reader;
            using (reader = XmlReader.Create(filePath)) {
                while (reader.Read())
                    ReadNode(reader);
                reader.Close();
            }
            return gameObjects;
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
            if (reader.Name == objectType) {
                builder = factory.CreateBuilder(objectType);
                if (reader.HasAttributes)
                    builder.AddAttribute("Name", reader.GetAttribute("Name"));
            }
        }

        private void HandleText(string nodeName, string content) {
            builder.AddAttribute(nodeName, content);
        }

        private void HandleEndElement(XmlReader reader) {
            if (reader.Name == objectType) {
                gameObjects.Add((T)builder.GetGameObject());
                currentNode = string.Empty;
            }
        }
    }
}
