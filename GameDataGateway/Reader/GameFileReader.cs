using System.Collections.Generic;

namespace GameDataGateway.Reader {
    public interface GameFileReader<T> {
        IEnumerable<T> ReadGameFile(string filePath);
    }
}
