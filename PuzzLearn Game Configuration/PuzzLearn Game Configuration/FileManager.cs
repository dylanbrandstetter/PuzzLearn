using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public static class FileManager
    {
        private const string d = ",";
        private const string n = "\n";

        #region Write files

        private static void WriteInformationAddress(InformationAddress ia, StringBuilder builder)
        {
            builder.Append((int)ia.Type + d + ia.Description + d + ia.Address
                + d + ia.DefaultValue + d + ia.GetMax() + d + ia.ValueCategories.Count + n);
            foreach (var p in ia.ValueCategories)
                builder.Append(p.Key + d + p.Value + n);
        }

        private static void WriteIntegerAddress(IntegerAddress ia, StringBuilder builder)
        {
            builder.Append((int)ia.Type + d + ia.Description + d 
                + ia.Address + d + ia.Offset + d + ia.Multiply + n);
        }

        private static void WriteObjectBlock(ObjectBlock ob, StringBuilder builder)
        {
            int info = 0;
            if (ob.Information != null)
                info = 1;

            builder.Append((int)ob.Type + d + ob.Description + d + ob.FixedValue + d
                + ob.XAddresses.Count + d + ob.YAddresses.Count + d + info + n);

            foreach (var x in ob.XAddresses)
                WriteIntegerAddress(x, builder);

            foreach (var y in ob.YAddresses)
                WriteIntegerAddress(y, builder);

            if (ob.Information != null)
                WriteInformationAddress(ob.Information, builder);
        }

        private static void WriteAddressRegion(AddressRegion ar, StringBuilder builder)
        {
            builder.Append((int)ar.Type + d + ar.Description + d + ar.StartAddress + d
                + ar.EndAddress + d + ar.Increment + d + ar.Structures.Count + n);

            foreach (var s in ar.Structures)
            {
                switch (s.Type)
                {
                    case MemStructObject.ObjectType.OBJECT:
                        WriteObjectBlock((ObjectBlock)s, builder);
                        break;

                    case MemStructObject.ObjectType.REGION:
                        WriteAddressRegion((AddressRegion)s, builder);
                        break;
                }
            }
        }

        private static void WriteXYRegion(XYRegion xyr, StringBuilder builder)
        {
            builder.Append((int)xyr.Type + d + xyr.Description + d + xyr.StartAddress + d
                + xyr.Width + d + xyr.XOffset + d + xyr.Height + d + xyr.YOffset + d
                + xyr.RowOffset + d + xyr.DefaultValue + d + xyr.ValueCategories.Count + n);

            foreach (var p in xyr.ValueCategories)
                builder.Append(p.Key + d + p.Value + n);
        }

        private static void WriteAddressPlane(AddressPlane ap, StringBuilder builder)
        {
            builder.Append((int)ap.Type + d + ap.Description + d + ap.XMin + d + ap.XMax + d
                + ap.YMin + d + ap.YMax + d + ap.DefaultValue + d + ap.GetMax() + d
                + ap.Structures.Count + d + ap.XCenterAddress.Count + d + ap.YCenterAddress.Count + n);

            foreach (var s in ap.Structures)
            {
                switch (s.Type)
                {
                    case MemStructObject.ObjectType.OBJECT:
                        WriteObjectBlock((ObjectBlock)s, builder);
                        break;

                    case MemStructObject.ObjectType.REGION:
                        WriteAddressRegion((AddressRegion)s, builder);
                        break;

                    case MemStructObject.ObjectType.XYREGION:
                        WriteXYRegion((XYRegion)s, builder);
                        break;
                }
            }

            foreach (var x in ap.XCenterAddress)
                WriteIntegerAddress(x, builder);

            foreach (var y in ap.YCenterAddress)
                WriteIntegerAddress(y, builder);
        }

        public static string WriteDatabase(IList<MemStructObject> structures, IList<IntegerAddress> score, DatabaseSettings settings)
        {
            StringBuilder builder = new StringBuilder(1024);
            string releaseVal = settings.ReleaseButtons ? "1" : "0";

            builder.Append(settings.EndAddress + d + settings.EndValue + d
                + settings.Population + d + settings.StagnantGeneration + d
                + decimal.ToInt32(settings.Timeout * 100) + d
                + decimal.ToInt32(settings.StagnantTimeout * 100) + d
                + settings.CategoryColors.Count + d + settings.Buttons.Count + d
                + structures.Count + d + score.Count + d + releaseVal + n);

            foreach (var cc in settings.CategoryColors)
            {
                builder.Append(cc.Category + d + cc.Color.R + d
                    + cc.Color.G + d + cc.Color.B + n);
            }

            foreach (var b in settings.Buttons)
            {
                builder.Append(b + n);
            }

            foreach (var s in structures)
            {
                switch (s.Type)
                {
                    case MemStructObject.ObjectType.ADDRESSPLANE:
                        WriteAddressPlane((AddressPlane)s, builder);
                        break;

                    case MemStructObject.ObjectType.INFORMATION:
                        WriteInformationAddress((InformationAddress)s, builder);
                        break;
                }
            }

            foreach (var s in score)
            {
                WriteIntegerAddress(s, builder);
            }

            return builder.ToString();
        }

        public static void WriteFile(IList<MemStructObject> structures, IList<IntegerAddress> score, DatabaseSettings settings, Stream file)
        {
            StreamWriter sw = new StreamWriter(file);

            sw.Write(WriteDatabase(structures, score, settings));

            sw.Close();
        }

        #endregion

        #region Read files

        private static void ReadValueCategories(StreamReader reader, ref int lineCount, int vcCount, IDictionary<int, int> vc)
        {
            for (int i = 0; i < vcCount; ++i)
            {
                string[] vcLine = reader.ReadLine().Split(',');
                ++lineCount;

                if (vcLine.Count() != 2)
                    throw new FormatException("Invalid value-category pair line at line " + lineCount);

                int value = Convert.ToInt32(vcLine[0]);
                int category = Convert.ToInt32(vcLine[1]);

                vc[value] = category;
            }
        }

        private static InformationAddress ReadInformationAddress(string[] infoLine, StreamReader reader, ref int lineCount)
        {
            if (infoLine.Count() != 6)
                throw new FormatException("Invalid information address line at line " + lineCount);

            InformationAddress info;
            int vcCount;

            try
            {
                string description = infoLine[1];
                int address = Convert.ToInt32(infoLine[2]);
                int defaultValue = Convert.ToInt32(infoLine[3]);
                vcCount = Convert.ToInt32(infoLine[5]);

                info = new InformationAddress(address, description, defaultValue, new Dictionary<int, int>());
            }
            catch
            {
                throw new FormatException("Invalid information address line at line " + lineCount);
            }

            ReadValueCategories(reader, ref lineCount, vcCount, info.ValueCategories);

            return info;
        }

        private static IntegerAddress ReadIntegerAddress(StreamReader reader, ref int lineCount)
        {
            string[] intLine = reader.ReadLine().Split(',');
            ++lineCount;

            if (intLine.Count() != 5)
                throw new FormatException("Invalid integer address line at line " + lineCount);

            IntegerAddress intAddr;

            try
            {
                string desc = intLine[1];
                int address = Convert.ToInt32(intLine[2]);
                int offset = Convert.ToInt32(intLine[3]);
                decimal multiply = Convert.ToDecimal(intLine[4]);

                intAddr = new IntegerAddress(address, desc, offset, multiply);
            }
            catch
            {
                throw new FormatException("Invalid integer address line at line " + lineCount);
            }

            return intAddr;
        }

        private static ObjectBlock ReadObjectBlock(string[] objectLine, StreamReader reader, ref int lineCount)
        {
            ++lineCount;

            if (objectLine.Count() != 6)
                throw new FormatException("Invalid object block line at line " + lineCount);

            ObjectBlock ob;
            int xCount;
            int yCount;
            int hasInfo;

            try
            {
                string desc = objectLine[1];
                int fixedValue = Convert.ToInt32(objectLine[2]);
                xCount = Convert.ToInt32(objectLine[3]);
                yCount = Convert.ToInt32(objectLine[4]);
                hasInfo = Convert.ToInt32(objectLine[5]);

                ob = new ObjectBlock(desc, new List<IntegerAddress>(), new List<IntegerAddress>(), null, fixedValue);
            }
            catch
            {
                throw new FormatException("Invalid object block line at line " + lineCount);
            }

            for (int i = 0; i < xCount; ++i)
            {
                ob.XAddresses.Add(ReadIntegerAddress(reader, ref lineCount));
            }

            for (int i = 0; i < yCount; ++i)
            {
                ob.YAddresses.Add(ReadIntegerAddress(reader, ref lineCount));
            }

            if (hasInfo == 1)
            {
                string[] infoLine = reader.ReadLine().Split(',');
                ++lineCount;
                ob.Information = ReadInformationAddress(infoLine, reader, ref lineCount);
            }

            return ob;
        }

        private static AddressRegion ReadAddressRegion(string[] regionLine, StreamReader reader, ref int lineCount)
        {
            if (regionLine.Count() != 6)
                throw new FormatException("Invalid address region line at line " + lineCount);

            AddressRegion region;
            int structCount;
            try
            {
                string desc = regionLine[1];
                int sa = Convert.ToInt32(regionLine[2]);
                int ea = Convert.ToInt32(regionLine[3]);
                int inc = Convert.ToInt32(regionLine[4]);
                structCount = Convert.ToInt32(regionLine[5]);

                region = new AddressRegion(desc, new List<MemStructObject>(), sa, ea, inc);
            }
            catch
            {
                throw new FormatException("Invalid address region line at line " + lineCount);
            }

            for (int i = 0; i < structCount; ++i)
            {
                string[] nextLine = reader.ReadLine().Split(',');
                ++lineCount;

                int t = 0;
                if (!int.TryParse(nextLine[0], out t))
                    throw new FormatException("First argument must be an int at line " + lineCount);

                switch (t)
                {
                    case (int)MemStructObject.ObjectType.OBJECT:
                        region.Structures.Add(ReadObjectBlock(nextLine, reader, ref lineCount));
                        break;

                    case (int)MemStructObject.ObjectType.REGION:
                        region.Structures.Add(ReadAddressRegion(nextLine, reader, ref lineCount));
                        break;

                    default:
                        throw new FormatException("Invalid type for a region at line " + lineCount);
                }
            }

            return region;
        }

        private static XYRegion ReadXYRegion(string[] xyLine, StreamReader reader, ref int lineCount)
        {
            if (xyLine.Count() != 10)
                throw new FormatException("Invalid XY region line at line " + lineCount);

            XYRegion xyr;
            int vcCount;

            try
            {
                string desc = xyLine[1];
                int startAddr = Convert.ToInt32(xyLine[2]);
                int width = Convert.ToInt32(xyLine[3]);
                int xOffset = Convert.ToInt32(xyLine[4]);
                int height = Convert.ToInt32(xyLine[5]);
                int yOffset = Convert.ToInt32(xyLine[6]);
                int rowOffset = Convert.ToInt32(xyLine[7]);
                int defaultValue = Convert.ToInt32(xyLine[8]);
                vcCount = Convert.ToInt32(xyLine[9]);

                xyr = new XYRegion(desc, startAddr, width, xOffset, height, yOffset, rowOffset, defaultValue, new Dictionary<int, int>());
            }
            catch
            {
                throw new FormatException("Invalid XY region line at line " + lineCount);
            }

            ReadValueCategories(reader, ref lineCount, vcCount, xyr.ValueCategories);

            return xyr;
        }

        private static AddressPlane ReadAddressPlane(string[] planeLine, StreamReader reader, ref int lineCount)
        {
            string exceptionString = "Invalid address plane line at line " + lineCount;
            if (planeLine.Count() != 11)
                throw new FormatException(exceptionString);

            AddressPlane ap;
            int sCount;
            int xCount;
            int yCount;

            try
            {
                string desc = planeLine[1];
                int xMin = Convert.ToInt32(planeLine[2]);
                int xMax = Convert.ToInt32(planeLine[3]);
                int yMin = Convert.ToInt32(planeLine[4]);
                int yMax = Convert.ToInt32(planeLine[5]);
                int dVal = Convert.ToInt32(planeLine[6]);
                sCount = Convert.ToInt32(planeLine[8]);
                xCount = Convert.ToInt32(planeLine[9]);
                yCount = Convert.ToInt32(planeLine[10]);

                ap = new AddressPlane(new List<MemStructObject>(),
                    desc, xMin, xMax, yMin, yMax, dVal,
                    new List<IntegerAddress>(), new List<IntegerAddress>());
            }
            catch
            {
                throw new FormatException(exceptionString);
            }

            for (int i = 0; i < sCount; ++i)
            {
                string[] nextLine = reader.ReadLine().Split(',');
                ++lineCount;


                int t = 0;
                if (!int.TryParse(nextLine[0], out t))
                    throw new FormatException("First argument must be an int at line " + lineCount);

                switch (t)
                {
                    case (int)MemStructObject.ObjectType.OBJECT:
                        ap.Structures.Add(ReadObjectBlock(nextLine, reader, ref lineCount));
                        break;

                    case (int)MemStructObject.ObjectType.REGION:
                        ap.Structures.Add(ReadAddressRegion(nextLine, reader, ref lineCount));
                        break;

                    case (int)MemStructObject.ObjectType.XYREGION:
                        ap.Structures.Add(ReadXYRegion(nextLine, reader, ref lineCount));
                        break;

                    default:
                        throw new FormatException("Invalid type for a region at line " + lineCount);
                }
            }

            for (int i = 0; i < xCount; ++i)
            {
                ap.XCenterAddress.Add(ReadIntegerAddress(reader, ref lineCount));
            }

            for (int i = 0; i < yCount; ++i)
            {
                ap.YCenterAddress.Add(ReadIntegerAddress(reader, ref lineCount));
            }

            return ap;
        }

        public static Tuple<IList<MemStructObject>, IList<IntegerAddress>, DatabaseSettings> ReadFile(Stream file)
        {
            int lineCount = 0;
            List<MemStructObject> structures = new List<MemStructObject>();
            List<IntegerAddress> score = new List<IntegerAddress>();

            StreamReader reader = new StreamReader(file);
            ++lineCount;

            string[] settingsLine = reader.ReadLine().Split(',');
            if (settingsLine.Count() < 10)
                throw new FormatException("Invalid settings line at line " + lineCount);

            DatabaseSettings settings;
            int colorCount;
            int buttonsCount;
            int structuresCount;
            int scoreCount;

            try
            {
                int endAddress = Convert.ToInt32(settingsLine[0]);
                int endValue = Convert.ToInt32(settingsLine[1]);
                int population = Convert.ToInt32(settingsLine[2]);
                int stagnantGeneration = Convert.ToInt32(settingsLine[3]);
                decimal timeout = Convert.ToDecimal(settingsLine[4]) / 100;
                decimal stagnantTimeout = Convert.ToDecimal(settingsLine[5]) / 100;
                colorCount = Convert.ToInt32(settingsLine[6]);
                buttonsCount = Convert.ToInt32(settingsLine[7]);
                structuresCount = Convert.ToInt32(settingsLine[8]);
                scoreCount = Convert.ToInt32(settingsLine[9]);
                bool releaseButtons;
                if (settingsLine.Length == 10)
                    releaseButtons = false;
                else
                    releaseButtons = settingsLine[10] == "1";


                settings = new DatabaseSettings(new List<CategoryColor>(), new List<string>(),
                    population, stagnantGeneration, endAddress, endValue, timeout, stagnantTimeout,
                    releaseButtons);
            }
            catch
            {
                throw new FormatException("Invalid settings line at line " + lineCount);
            }

            for (int i = 0; i < colorCount; ++i)
            {
                string[] colorLine = reader.ReadLine().Split(',');
                ++lineCount;

                if (colorLine.Count() != 4)
                    throw new FormatException("Invalid color line at line " + lineCount);

                try
                {
                    int category = Convert.ToInt32(colorLine[0]);
                    int r = Convert.ToInt32(colorLine[1]);
                    int g = Convert.ToInt32(colorLine[2]);
                    int b = Convert.ToInt32(colorLine[3]);
                    Color color = Color.FromArgb(255, r, g, b);

                    settings.CategoryColors.Add(new CategoryColor(color, category));
                }
                catch
                {
                    throw new FormatException("Invalid color line at line " + lineCount);
                }
            }

            for (int i = 0; i < buttonsCount; ++i)
            {
                settings.Buttons.Add(reader.ReadLine());
                ++lineCount;
            }

            for (int i = 0; i < structuresCount; ++i)
            {
                string[] nextLine = reader.ReadLine().Split(',');
                ++lineCount;

                int t = 0;
                if (!int.TryParse(nextLine[0], out t))
                    throw new FormatException("First argument must be an int at line " + lineCount);

                switch (t)
                {
                    case (int)MemStructObject.ObjectType.ADDRESSPLANE:
                        structures.Add(ReadAddressPlane(nextLine, reader, ref lineCount));
                        break;

                    case (int)MemStructObject.ObjectType.INFORMATION:
                        structures.Add(ReadInformationAddress(nextLine, reader, ref lineCount));
                        break;

                    default:
                        throw new FormatException("Invalid type for a region at line " + lineCount);
                }
            }

            for (int i = 0; i < scoreCount; ++i)
            {
                score.Add(ReadIntegerAddress(reader, ref lineCount));
            }

            reader.Close();

            return new Tuple<IList<MemStructObject>, IList<IntegerAddress>, DatabaseSettings>(structures, score, settings);
        }

        #endregion

        public static void TestSaveFunction()
        {
            List<IntegerAddress> xCursors = new List<IntegerAddress>();
            List<IntegerAddress> yCursors = new List<IntegerAddress>();
            xCursors.Add(new IntegerAddress(0x326, "Cursor X", -96, (decimal)1 / 8));
            yCursors.Add(new IntegerAddress(0x327, "Cursor Y", -48, (decimal)1 / 8));

            Dictionary<int, int> orientationValues = new Dictionary<int, int>();
            orientationValues[0] = 1;
            orientationValues[2] = 2;
            orientationValues[4] = 3;
            orientationValues[6] = 4;
            orientationValues[8] = 5;
            orientationValues[10] = 6;
            orientationValues[12] = 7;
            orientationValues[14] = 8;
            orientationValues[16] = 9;
            orientationValues[18] = 10;
            orientationValues[20] = 9;
            orientationValues[22] = 10;
            orientationValues[24] = 11;
            orientationValues[26] = 11;
            orientationValues[28] = 11;
            orientationValues[30] = 11;
            orientationValues[32] = 12;
            orientationValues[34] = 13;
            orientationValues[36] = 12;
            orientationValues[38] = 13;
            orientationValues[40] = 14;
            orientationValues[42] = 15;
            orientationValues[44] = 16;
            orientationValues[46] = 17;
            orientationValues[48] = 18;
            orientationValues[50] = 19;
            orientationValues[52] = 18;
            orientationValues[54] = 19;

            InformationAddress shapeAndOrientation = new InformationAddress(0x317, "Block shape and orientation", 0, orientationValues);

            Dictionary<int, int> cv1 = new Dictionary<int, int>();
            cv1[0] = 0;

            XYRegion placedBlockLocations = new XYRegion("Placed block locations", 0x100, 12, -1, 0x17, -2, 0x10, 1, cv1);

            List<IntegerAddress> scoreAddresses = new List<IntegerAddress>();
            scoreAddresses.Add(new IntegerAddress(0x270, "Score 1", 0, 1));
            scoreAddresses.Add(new IntegerAddress(0x271, "Score 2", 0, 256));
            scoreAddresses.Add(new IntegerAddress(0x272, "Score 3", 0, 256*256));
            scoreAddresses.Add(new IntegerAddress(0x273, "Score 4", 0, 256*256*256));

            List<MemStructObject> planeObjects = new List<MemStructObject>();
            planeObjects.Add(placedBlockLocations);

            AddressPlane mainPlane = new AddressPlane(planeObjects, "Main plane", -6, 6, -1, 10, 1, xCursors, yCursors);

            List<MemStructObject> structures = new List<MemStructObject>();
            structures.Add(mainPlane);
            structures.Add(shapeAndOrientation);

            List<CategoryColor> cc = new List<CategoryColor>();
            cc.Add(new CategoryColor(Color.Black, 0));
            cc.Add(new CategoryColor(Color.White, 1));

            List<string> buttons = new List<string>();
            buttons.Add("P1 A");
            buttons.Add("P1 B");
            buttons.Add("P1 Down");
            buttons.Add("P1 Left");
            buttons.Add("P1 Right");

            DatabaseSettings settings = new DatabaseSettings(cc, buttons, 300, 30, 0x1912, 80, 600, 20);

            Stream fs = File.Create("Tetris & Dr. Mario - Tetris.plcf");

            WriteFile(structures, scoreAddresses, settings, fs);
        }
    }
}
