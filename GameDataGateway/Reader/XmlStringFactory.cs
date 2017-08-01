namespace GameDataGateway.Reader {
    internal static class XmlStringFactory {
        public static string CreateXmlString(string type) {
            switch (type) {
                case "Planet":
                    return CreatePlanetString();
                case "SimplePlanet":
                    return CreateSimplePlanetString();
                case "TradeRoute":
                    return CreateTradeRouteString();
                default:
                    return string.Empty;
            }
        }

        private static string CreatePlanetString() {
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

                        <Abilities>
                            <Test>
                                <A>asd</A>
                            </Test>
                        </Abilities>
                        </Planet>
                    </Planets>";
        }

        public static string CreateSimplePlanetString() {
            return @"<Planets><Planet Name=""Test_Planet"">
                    <Galactic_Position>1, 2, 3</Galactic_Position>
                    <Tag1>Something</Tag1>
                    <Tag2>
                    <SubTag>
                        <SubSubTag>42</SubSubTag>
                    </SubTag>
                    </Tag2>
                    </Planet></Planets>";
        }

        private static string CreateTradeRouteString() {
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
    }
}