using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using GameDataGateway.Model;

namespace GameDataGateway.Reader {
    [TestFixture]
    internal class TradeRouteFileReaderTest {
        private string filePath;

        [OneTimeSetUp]
        public void SetUp() {
            string data = CreateData();
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Path.Combine(documents, "TradeRoutes.xml");
            File.WriteAllText(filePath, data);
        }

        private static string CreateData() {
            return @"<TradeRoutes>
                        <TradeRoute Name=""Abregado_Bothawui"">
                        <Point_A>Abregado_Rae</Point_A>
                        <Point_B>Bothawui</Point_B>
                        <HS_Speed_Factor>0</HS_Speed_Factor>
                        <Political_Control_Gain>0</Political_Control_Gain>
                        <Credit_Gain_Factor>0</Credit_Gain_Factor>
                        <Visible_Line_Name>DEFAULT</Visible_Line_Name>
                        </TradeRoute>
                    </TradeRoutes>";
        }

        [Test]
        public void whenReadingFileWithSingleTradeRoute_shouldReturnListWithOneTradeRoute() {
            var pointA = new Model.Implementation.PlanetImp { Name = "Abregado_Rae" };
            var pointB = new Model.Implementation.PlanetImp { Name = "Bothawui" };
            var planets = new List<Planet> {
                pointB, pointA
            };
            var sut = new TradeRouteFileReader(planets);

            var result = sut.ReadGameFile(filePath) as List<TradeRoute>;
            Assert.That(result.Count, Is.EqualTo(1));

            var tradeRoute = result[0];

            Assert.That(tradeRoute.Name, Is.EqualTo("Abregado_Bothawui"));
            Assert.That(tradeRoute.PointA, Is.SameAs(pointA));
            Assert.That(tradeRoute.PointB, Is.SameAs(pointB));
        }

        [OneTimeTearDown]
        public void TearDown() {
            File.Delete(filePath);
        }

    }
}
