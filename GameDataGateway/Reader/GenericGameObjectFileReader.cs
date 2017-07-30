using System;
using System.Collections.Generic;
using System.Xml;
using GameDataGateway.Model;
using GameDataGateway.Reader.Builder;

namespace GameDataGateway.Reader {
    public class GenericGameObjectFileReader<T> where T : GameObject {
        private readonly List<T> gameObjects = new List<T>();
        private readonly string objectType;
        private string currentNode;

        private bool isFirst = true;

        private readonly GameObjectBuilderFactory factory;
        private GameObjectBuilder builder;

        public GenericGameObjectFileReader(string objectType, GameObjectBuilderFactory factory) {
            this.factory = factory;
            this.objectType = objectType;
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
            if (IsRoot()) return;
            if (reader.Name == objectType) {
                builder = factory.CreateBuilder(objectType);
                if (reader.HasAttributes && reader.GetAttribute("Name") != null)
                    builder.AddAttribute("Name", reader.GetAttribute("Name"));
            } else if (reader.Name == "Test") {
                Console.WriteLine(reader.ReadInnerXml());
            }
        }

        private bool IsRoot() {
            if (!isFirst) return false;
            isFirst = false;
            return true;
        }

        private void HandleText(string nodeName, string content) {
            builder.AddAttribute(nodeName, content);
        }

        private void HandleEndElement(XmlReader reader) {
            if (reader.Name != objectType) return;
            gameObjects.Add((T) builder.GetGameObject());
            currentNode = string.Empty;
        }
    }
}