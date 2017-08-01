namespace GameDataGateway.Model {
    public abstract class IncompleteGameObject {
        protected string xmlString = string.Empty;

        public void SaveString(string content) {
            xmlString += content;
        }

        public string GetString() {
            return xmlString;
        }
    }
}