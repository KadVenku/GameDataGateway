using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using GameDataGateway.Model;

namespace GameDataGateway.Reader {
    [TestFixture]
    internal class PlanetFileReaderTest {
        private string filePath;

        [OneTimeSetUp]
        public void SetUp() {
            string data = CreateData();
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Path.Combine(documents, "Planets.xml");
            File.WriteAllText(filePath, data);
        }

        private static string CreateData() {
            return @"<Planets>
                        <Planet Name=""Galaxy_Core_Art_Model"">
                        <Text_ID />
                        <Galactic_Model_Name>w_galaxy00.alo</Galactic_Model_Name>
                        <Loop_Idle_Anim_00>No</Loop_Idle_Anim_00>
                        <Always_Instantiate_Galactic>yes</Always_Instantiate_Galactic>
                        <Mass>1.0</Mass>
                        <Scale_Factor>2.0</Scale_Factor>
                        <Show_Name>No</Show_Name>
                        <Name_Adjust>-10.0, 10.0, -0.1</Name_Adjust>
                        <Behavior>IDLE</Behavior>

                        <Pre_Lit>no</Pre_Lit>
                        <Political_Control>0</Political_Control>
                        <Camera_Aligned>No</Camera_Aligned>
                        <Terrain />
                        <Planet_Credit_Value>0</Planet_Credit_Value>
                        <Galactic_Position>12.0, 34.0, -10.0</Galactic_Position>
                        <Special_Structures>0</Special_Structures>
                        <In_Background>yes</In_Background>
                        <Max_Ground_Base>0</Max_Ground_Base>
                        <Max_Space_Base>0</Max_Space_Base>
                        </Planet>
                    </Planets>";
        }

        [Test]
        public void whenReadingXmlWithValidPlanet_shouldReturnListWithPlanet() {
            var sut = new PlanetFileReader();

            var result = sut.ReadGameFile(filePath) as List<Planet>;

            Assert.That(result.Count, Is.EqualTo(1));

            var planet = result[0];
            Assert.That(planet, Is.InstanceOf(typeof(Planet)));
            Assert.That(planet.Name, Is.EqualTo("Galaxy_Core_Art_Model"));
            Assert.That(planet.X, Is.EqualTo(12.0));
            Assert.That(planet.Y, Is.EqualTo(34.0));
            Assert.That(planet.Z, Is.EqualTo(-10.0));
        }

        [OneTimeTearDown]
        public void TearDown() {
            File.Delete(filePath);
        }
    }
}
