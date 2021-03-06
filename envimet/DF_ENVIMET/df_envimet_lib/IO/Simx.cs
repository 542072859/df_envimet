﻿using System;
using System.IO;
using System.Text;
using System.Xml;
using df_envimet_lib.Settings;

namespace df_envimet_lib.IO
{
    public class Simx
    {
        public const string NEWLINE = "\n";

        public MainSettings MainSettings { get; }
        public SimpleForcingSettings SimpleForcing { get; set; }
        public TThread TThread { get; set; }
        public TimeSteps TimeSteps { get; set; }
        public ModelTiming ModelTiming { get; set; }
        public SoilConfig SoilSettings { get; set; }
        public Sources Sources { get; set; }
        public Turbulence Turbulence { get; set; }
        public OutputSettings OutputSettings { get; set; }
        public Cloud Cloud { get; set; }
        public Background Background { get; set; }
        public SolarAdjust SolarAdjust { get; set; }
        public BuildingSettings BuildingSettings { get; set; }
        public IVS IVS { get; set; }
        public ParallelCPU ParallelCPU { get; set; }
        public SOR SOR { get; set; }
        public InflowAvg InflowAvg { get; set; }
        public Facades Facades { get; set; }
        public PlantSetting PlantSetting { get; set; }
        public LBC LBC { get; set; }
        public FullForcing FullForcing { get; set; }

        public Simx(MainSettings mainSettings)
        {
            MainSettings = mainSettings;
            SimpleForcing = null;
            TThread = null;
            TimeSteps = null;
            ModelTiming = null;
            SoilSettings = null;
            Sources = null;
            Turbulence = null;
            OutputSettings = null;
            Cloud = null;
            Background = null;
            SolarAdjust = null;
            BuildingSettings = null;
            IVS = null;
            SOR = null;
            InflowAvg = null;
            Facades = null;
            PlantSetting = null;
            LBC = null;
            FullForcing = null;
        }

        public void WriteSimx()
        {
            var now = DateTime.Now;
            string revisionDate = now.ToString("yyyy-MM-dd HH:mm:ss");
            string filePath = Path.Combine(Path.GetDirectoryName(MainSettings.Inx), MainSettings.Name + ".simx");
            string[] empty = { };

            XmlTextWriter xWriter = new XmlTextWriter(filePath, Encoding.UTF8);
            xWriter.WriteStartElement("ENVI-MET_Datafile");
            xWriter.WriteString(NEWLINE);

            // Header section
            string headerTitle = "Header";
            string[] headerTag = new string[] { "filetype", "version", "revisiondate", "remark", "encryptionlevel" };
            string[] headerValue = new string[] { "SIMX", "2", revisionDate, "Created with lb_envimet", "0" };

            Inx.CreateXmlSection(xWriter, headerTitle, headerTag, headerValue, 0, empty);

            // Main section
            string mainTitle = "mainData";
            string[] mainTag = new string[] { "simName", "INXFile", "filebaseName", "outDir", "startDate", "startTime", "simDuration", "windSpeed", "windDir", "z0", "T_H", "Q_H", "Q_2m" };
            string[] mainValue = new string[]
              { MainSettings.Name,
                    Path.GetFileName(MainSettings.Inx),
                    MainSettings.Name,
                    " ",
                    MainSettings.StartDate,
                    MainSettings.StartTime,
                    MainSettings.SimDuration.ToString(),
                    MainSettings.WindSpeed.ToString(),
                    MainSettings.WindDir.ToString(),
                    MainSettings.Roughness.ToString(),
                    MainSettings.InitialTemperature.ToString(),
                    MainSettings.SpecificHumidity.ToString(),
                    MainSettings.RelativeHumidity.ToString()
              };

            Inx.CreateXmlSection(xWriter, mainTitle, mainTag, mainValue, 0, empty);

            if (SimpleForcing != null && FullForcing == null)
            {
                string sfTitle = "SimpleForcing";
                string[] sfTag = new string[] { "TAir", "Qrel" };
                string[] sfValue = new string[] { SimpleForcing.Temperature, SimpleForcing.RelativeHumidity };

                Inx.CreateXmlSection(xWriter, sfTitle, sfTag, sfValue, 0, empty);
            }

            if (TThread != null)
            {
                string parallelTitle = "TThread";
                string[] parallelTag = new string[] { "UseTThread_CallMain", "TThreadPRIO" };
                string[] parallelValue = new string[] { TThread.UseTreading.ToString(), TThread.TThreadpriority.ToString() };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (ModelTiming != null)
            {
                string parallelTitle = "ModelTiming";
                string[] parallelTag = new string[] { "surfaceSteps", "flowSteps", "radiationSteps", "plantSteps", "sourcesSteps" };
                string[] parallelValue = new string[] { ModelTiming.SurfaceSteps.ToString(), ModelTiming.FlowSteps.ToString(), ModelTiming.RadiationSteps.ToString(), ModelTiming.PlantSteps.ToString(), ModelTiming.SourcesSteps.ToString() };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (SoilSettings != null)
            {
                string parallelTitle = "Soil";
                string[] parallelTag = new string[] { "tempUpperlayer", "tempMiddlelayer", "tempDeeplayer", "tempBedrockLayer", "waterUpperlayer", "waterMiddlelayer", "waterDeeplayer", "waterBedrockLayer" };
                string[] parallelValue = new string[] { SoilSettings.TempUpperlayer.ToString("n6"), SoilSettings.TempMiddlelayer.ToString("n6"), SoilSettings.TempDeeplayer.ToString("n6"), SoilSettings.TempBedrockLayer.ToString("n6"), SoilSettings.WaterUpperlayer.ToString("n6"), SoilSettings.WaterMiddlelayer.ToString("n6"), SoilSettings.WaterDeeplayer.ToString("n6"), SoilSettings.WaterBedrockLayer.ToString("n6") };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (Sources != null)
            {
                string parallelTitle = "Sources";
                string[] parallelTag = new string[] { "userPolluName", "userPolluType", "userPartDiameter", "userPartDensity", "multipleSources", "activeChem", "isoprene" };
                string[] parallelValue = new string[] { Sources.UserPolluName, Sources.UserPolluType.ToString(), Sources.UserPartDiameter.ToString(), Sources.UserPartDensity.ToString(), Sources.MultipleSources.ToString(), Sources.ActiveChem.ToString(), Sources.ISOPRENE };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (Turbulence != null)
            {
                string parallelTitle = "Turbulence";
                string[] parallelTag = new string[] { "turbulenceModel" };
                string[] parallelValue = new string[] { Turbulence.TurbulenceModel.ToString() };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (TimeSteps != null)
            {
                string parallelTitle = "TimeSteps";
                string[] parallelTag = new string[] { "sunheight_step01", "sunheight_step02", "dt_step00", "dt_step01", "dt_step02" };
                string[] parallelValue = new string[] { TimeSteps.SunheightStep01.ToString("n6"), TimeSteps.SunheightStep02.ToString("n6"), TimeSteps.DtStep00.ToString("n6"), TimeSteps.DtStep01.ToString("n6"), TimeSteps.DtStep02.ToString("n6") };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (OutputSettings != null)
            {
                string parallelTitle = "OutputSettings";
                string[] parallelTag = new string[] { "mainFiles", "textFiles", "netCDF", "netCDFAllDataInOneFile", "inclNestingGrids"};
                string[] parallelValue = new string[] { OutputSettings.MainFiles.ToString(), OutputSettings.TextFiles.ToString(), OutputSettings.NetCDF.ToString(), OutputSettings.NetCDFAllDataInOneFile.ToString(), "0"};

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (Cloud != null && FullForcing == null)
            {
                string parallelTitle = "Clouds";
                string[] parallelTag = new string[] { "lowClouds", "middleClouds", "highClouds" };
                string[] parallelValue = new string[] { Cloud.LowClouds.ToString("n6"), Cloud.MiddleClouds.ToString("n6"), Cloud.HighClouds.ToString("n6") };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (Background != null)
            {
                string parallelTitle = "Background";
                string[] parallelTag = new string[] { "userSpec", "NO", "NO2", "O3", "PM_10", "PM_2_5" };
                string[] parallelValue = new string[] { Background.UserSpec.ToString("n6"), Background.No.ToString("n6"), Background.No2.ToString("n6"), Background.O3.ToString("n6"), Background.Pm10.ToString("n6"), Background.Pm25.ToString("n6") };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (SolarAdjust != null && FullForcing == null)
            {
                string parallelTitle = "SolarAdjust";
                string[] parallelTag = new string[] { "SWFactor" };
                string[] parallelValue = new string[] { SolarAdjust.SWfactor.ToString("n6") };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (BuildingSettings != null)
            {
                string parallelTitle = "Building";
                string[] parallelTag = new string[] { "indoorTemp", "indoorConst" };
                string[] parallelValue = new string[] { BuildingSettings.IndoorTemp.ToString("n6"), BuildingSettings.IndoorConst.ToString() };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (IVS != null)
            {
                string parallelTitle = "IVS";
                string[] parallelTag = new string[] { "IVSOn", "IVSMem" };
                string[] parallelValue = new string[] { IVS.IVSOn.ToString(), IVS.IVSMem.ToString() };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (ParallelCPU != null)
            {
                string parallelTitle = "Parallel";
                string[] parallelTag = new string[] { "CPUdemand" };
                string[] parallelValue = new string[] { ParallelCPU.CPU };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (SOR != null)
            {
                string parallelTitle = "SOR";
                string[] parallelTag = new string[] { "SORMode" };
                string[] parallelValue = new string[] { SOR.SORMode.ToString() };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (InflowAvg != null)
            {
                string parallelTitle = "InflowAvg";
                string[] parallelTag = new string[] { "inflowAvg" };
                string[] parallelValue = new string[] { InflowAvg.Avg.ToString() };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (PlantSetting != null)
            {
                string parallelTitle = "PlantModel";
                string[] parallelTag = new string[] { "CO2BackgroundPPM", "LeafTransmittance", "TreeCalendar" };
                string[] parallelValue = new string[] { PlantSetting.CO2.ToString(), PlantSetting.LeafTransmittance.ToString(), PlantSetting.TreeCalendar.ToString() };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (Facades != null)
            {
                string parallelTitle = "Facades";
                string[] parallelTag = new string[] { "FacadeMode" };
                string[] parallelValue = new string[] { Facades.FacadeMode.ToString() };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (LBC != null && (SimpleForcing == null || FullForcing == null))
            {
                string parallelTitle = "LBC";
                string[] parallelTag = new string[] { "LBC_TQ", "LBC_TKE" };
                string[] parallelValue = new string[] { LBC.TemperatureHumidity.ToString(), LBC.Turbolence.ToString() };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }

            if (FullForcing != null)
            {
                string parallelTitle = "FullForcing";
                string[] parallelTag = new string[] { "fileName", "forceT", "forceQ", "forceWind", "forcePrecip", "forceRadClouds", "interpolationMethod", "nudging", "nudgingFactor", "minFlowsteps", "limitWind2500", "maxWind2500", "z_0" };
                string[] parallelValue = new string[] { FullForcing.FileName, FullForcing.ForceTemperature.ToString(), FullForcing.ForceRelativeHumidity.ToString(), FullForcing.ForceWind.ToString(), FullForcing.ForcePrecipitation.ToString(), FullForcing.ForceRadClouds.ToString(), FullForcing.INTERPOLATION_METHOD, FullForcing.NUDGING, FullForcing.NUNDGING_FACTOR, FullForcing.MinFlowsteps.ToString(), FullForcing.LimitWind2500.ToString(), FullForcing.MaxWind2500.ToString(), FullForcing.Z_0 };

                Inx.CreateXmlSection(xWriter, parallelTitle, parallelTag, parallelValue, 0, empty);
            }


            xWriter.WriteEndElement();
            xWriter.Close();

        }
    }
}
