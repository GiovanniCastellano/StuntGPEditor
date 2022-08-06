using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace StuntGPEditor
{
    public class FileManager
    {
        public void Read(string filename)
        {
            if(!filename.Contains("setup.wad"))
            {
                CustomConsole.WriteError("Error: opened file is not a setup.wad file, check if the file has been modified, renamed or deleted");
                return;
            }

            CustomConsole.WriteMessage("Reading data at \"" + filename + "\"... ");

            StreamReader streamReader;
            int bytesRead = 0;
            char[] buffer = new char[10000];

            try
            {
                streamReader = new StreamReader(filename);
                buffer = new char[9709];
                streamReader.Read(buffer, 0, 9708);
                buffer = new char[6307];
                bytesRead = streamReader.Read(buffer, 0, 6306);
                streamReader.Close();

                if (!(new string(buffer)).Contains("Car01"))
                {
                    CustomConsole.WriteMessage("\n");
                    CustomConsole.WriteErrorLine("Error: setup.wad is corrupted, please reinstall the game before trying again");
                    return;
                }
            }
            catch(Exception)
            {
                CustomConsole.WriteMessage("\n");
                CustomConsole.WriteWarningLine("Warning: couldn't find setup.wad, try moving this executable to the game directory to automatically open setup.wad on launch");
                return;
            }


            BindingList<Car> carList = new BindingList<Car>();
            
            int i = 0;
            while (i < bytesRead)
            {
                Car car = new Car();
                car.name =              getNext(ref i, buffer);
                car.cost =              getNext(ref i, buffer);
                car.baseMass =          getNext(ref i, buffer);
                car.additiveMass =      getNext(ref i, buffer);
                car.trackFront =        getNext(ref i, buffer);
                car.trackRear =         getNext(ref i, buffer);
                car.wheelBase =         getNext(ref i, buffer);
                car.length =            getNext(ref i, buffer);
                car.width =             getNext(ref i, buffer);
                car.height =            getNext(ref i, buffer);
                car.comA =              getNext(ref i, buffer);
                car.comB =              getNext(ref i, buffer);
                car.comH =              getNext(ref i, buffer);
                car.rideHeight =        getNext(ref i, buffer);
                car.cm =                getNext(ref i, buffer);
                car.rpmIdle =           getNext(ref i, buffer);
                car.rpmLimit =          getNext(ref i, buffer);
                car.rpmMax =            getNext(ref i, buffer);
                car.maxTorque =         getNext(ref i, buffer);
                car.torqueEnv =         getNext(ref i, buffer);
                car.driveMode =         getNext(ref i, buffer);
                car.finalDrive =        getNext(ref i, buffer);
                car.gears =             getNext(ref i, buffer);
                car.shift =             getNext(ref i, buffer);
                car.efficiency =        getNext(ref i, buffer);
                car.split4WD =          getNext(ref i, buffer);
                car.gearCog1 =          getNext(ref i, buffer);
                car.gearCog2 =          getNext(ref i, buffer);
                car.gearCog3 =          getNext(ref i, buffer);
                car.gearCog4 =          getNext(ref i, buffer);
                car.gearCog5 =          getNext(ref i, buffer);
                car.gearCog6 =          getNext(ref i, buffer);
                car.gearCog7 =          getNext(ref i, buffer);
                car.gearCog8 =          getNext(ref i, buffer);
                car.brakeBias =         getNext(ref i, buffer);
                car.brakeAccel =        getNext(ref i, buffer);
                car.radius =            getNext(ref i, buffer);
                car.pressure =          getNext(ref i, buffer);
                car.travelIn =          getNext(ref i, buffer);
                car.dampingIn =         getNext(ref i, buffer);
                car.stiffnessIn =       getNext(ref i, buffer);
                car.maxTravel =         getNext(ref i, buffer);
                car.maxDamp =           getNext(ref i, buffer);
                car.maxStiffness =      getNext(ref i, buffer);
                car.tread =             getNext(ref i, buffer);
                car.tyreEnvelope =      getNext(ref i, buffer);
                car.cs =                getNext(ref i, buffer);
                car.ck =                getNext(ref i, buffer);
                car.cd =                getNext(ref i, buffer);
                car.cl =                getNext(ref i, buffer);
                car.sensitivity =       getNext(ref i, buffer);
                car.acceleration =      getNext(ref i, buffer);
                car.steeringAngle =     getNext(ref i, buffer);
                car.maxFuel =           getNext(ref i, buffer);
                car.fuelConsumption =   getNext(ref i, buffer);
                car.refuelRate =        getNext(ref i, buffer);
                car.unitMass =          getNext(ref i, buffer);
                car.rpmAcc=             getNext(ref i, buffer);
                car.rpmMax2=            getNext(ref i, buffer);
                car.cm2=                getNext(ref i, buffer);
                car.powerMult=          getNext(ref i, buffer);
                car.maxConsump =        getNext(ref i, buffer);
                car.fuelCutOff =        getNext(ref i, buffer);
                car.horn =              getNext(ref i, buffer);
                car.engine =            getNext(ref i, buffer);
                car.engineIdle =        getNext(ref i, buffer);
                car.engineBoost =       getNext(ref i, buffer);
                car.launchTime =        getNext(ref i, buffer);
                car.launchTolerance =   getNext(ref i, buffer);
                car.launchSpeed =       getNext(ref i, buffer);
                car.matRotSpeedX =      getNext(ref i, buffer);
                car.matRotSpeedY =      getNext(ref i, buffer);
                car.brakeAssist =       getNext(ref i, buffer);
                car.steerAssist =       getNext(ref i, buffer);
                car.bonusLivery =       getNext(ref i, buffer);
                car.strength =          getLast(ref i, buffer, bytesRead);

                carList.Add(car);
            }

            /*foreach (Car car in carList)
            {
                Console.Write(car.ToString());
            }
            Console.WriteLine("EOF");*/


            BindingList<Car> cars = new BindingList<Car>();
            foreach(Car car in carList)
            {
                cars.Add(new Car(car));
            }
            Program.carList = cars;

            Program.setupWadPath = filename;

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = carList;

            Program.mainForm.mainDataGrid.AutoGenerateColumns = true;
            Program.mainForm.mainDataGrid.DataSource = bindingSource;
            Program.mainForm.mainDataGrid.BindingContext = new BindingContext();

            Program.mainForm.mainDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Program.mainForm.mainDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Program.mainForm.mainDataGrid.Columns[0].Frozen = true;
            Program.mainForm.mainDataGrid.Columns[0].ReadOnly = true;

            Program.mainForm.mainDataGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            Program.mainForm.mainDataGrid.AllowUserToAddRows = false;

            CustomConsole.WriteMessageLine("completed!");
        }

        public void Write()
        {
            if (Program.setupWadPath == "")
            {
                CustomConsole.WriteErrorLine("Error: nothing to save");
                return;
            }
            CustomConsole.WriteMessage("Saving... ");

            BindingList<Car> carList = new BindingList<Car>();

            string toWrite = "";

            foreach (DataGridViewRow row in Program.mainForm.mainDataGrid.Rows)
            {
                Car car = new Car();

                car.name =              row.Cells[0].Value.ToString();
                car.cost =              row.Cells[1].Value.ToString();
                car.baseMass =          row.Cells[2].Value.ToString();
                car.additiveMass =      row.Cells[3].Value.ToString();
                car.trackFront =        row.Cells[4].Value.ToString();
                car.trackRear =         row.Cells[5].Value.ToString();
                car.wheelBase =         row.Cells[6].Value.ToString();
                car.length =            row.Cells[7].Value.ToString();
                car.width =             row.Cells[8].Value.ToString();
                car.height =            row.Cells[9].Value.ToString();
                car.comA =              row.Cells[10].Value.ToString();
                car.comB =              row.Cells[11].Value.ToString();
                car.comH =              row.Cells[12].Value.ToString();
                car.rideHeight =        row.Cells[13].Value.ToString();
                car.cm =                row.Cells[14].Value.ToString();
                car.rpmIdle =           row.Cells[15].Value.ToString();
                car.rpmLimit =          row.Cells[16].Value.ToString();
                car.rpmMax =            row.Cells[17].Value.ToString();
                car.maxTorque =         row.Cells[18].Value.ToString();
                car.torqueEnv =         row.Cells[19].Value.ToString();
                car.driveMode =         row.Cells[20].Value.ToString();
                car.finalDrive =        row.Cells[21].Value.ToString();
                car.gears =             row.Cells[22].Value.ToString();
                car.shift =             row.Cells[23].Value.ToString();
                car.efficiency =        row.Cells[24].Value.ToString();
                car.split4WD =          row.Cells[25].Value.ToString();
                car.gearCog1 =          row.Cells[26].Value.ToString();
                car.gearCog2 =          row.Cells[27].Value.ToString();
                car.gearCog3 =          row.Cells[28].Value.ToString();
                car.gearCog4 =          row.Cells[29].Value.ToString();
                car.gearCog5 =          row.Cells[30].Value.ToString();
                car.gearCog6 =          row.Cells[31].Value.ToString();
                car.gearCog7 =          row.Cells[32].Value.ToString();
                car.gearCog8 =          row.Cells[33].Value.ToString();
                car.brakeBias =         row.Cells[34].Value.ToString();
                car.brakeAccel =        row.Cells[35].Value.ToString();
                car.radius =            row.Cells[36].Value.ToString();
                car.pressure =          row.Cells[37].Value.ToString();
                car.travelIn =          row.Cells[38].Value.ToString();
                car.dampingIn =         row.Cells[39].Value.ToString();
                car.stiffnessIn =       row.Cells[40].Value.ToString();
                car.maxTravel =         row.Cells[41].Value.ToString();
                car.maxDamp =           row.Cells[42].Value.ToString();
                car.maxStiffness =      row.Cells[43].Value.ToString();
                car.tread =             row.Cells[44].Value.ToString();
                car.tyreEnvelope =      row.Cells[45].Value.ToString();
                car.cs =                row.Cells[46].Value.ToString();
                car.ck =                row.Cells[47].Value.ToString();
                car.cd =                row.Cells[48].Value.ToString();
                car.cl =                row.Cells[49].Value.ToString();
                car.sensitivity =       row.Cells[50].Value.ToString();
                car.acceleration =      row.Cells[51].Value.ToString();
                car.steeringAngle =     row.Cells[52].Value.ToString();
                car.maxFuel =           row.Cells[53].Value.ToString();
                car.fuelConsumption =   row.Cells[54].Value.ToString();
                car.refuelRate =        row.Cells[55].Value.ToString();
                car.unitMass =          row.Cells[56].Value.ToString();
                car.rpmAcc =            row.Cells[57].Value.ToString();
                car.rpmMax2 =           row.Cells[58].Value.ToString();
                car.cm2 =               row.Cells[59].Value.ToString();
                car.powerMult =         row.Cells[60].Value.ToString();
                car.maxConsump =        row.Cells[61].Value.ToString();
                car.fuelCutOff =        row.Cells[62].Value.ToString();
                car.horn =              row.Cells[63].Value.ToString();
                car.engine =            row.Cells[64].Value.ToString();
                car.engineIdle =        row.Cells[65].Value.ToString();
                car.engineBoost =       row.Cells[66].Value.ToString();
                car.launchTime =        row.Cells[67].Value.ToString();
                car.launchTolerance =   row.Cells[68].Value.ToString();
                car.launchSpeed =       row.Cells[69].Value.ToString();
                car.matRotSpeedX =      row.Cells[70].Value.ToString();
                car.matRotSpeedY =      row.Cells[71].Value.ToString();
                car.brakeAssist =       row.Cells[72].Value.ToString();
                car.steerAssist =       row.Cells[73].Value.ToString();
                car.bonusLivery =       row.Cells[74].Value.ToString();
                car.strength =          row.Cells[75].Value.ToString();

                toWrite += car.ToString();

                carList.Add(car);
            }
        
            for(int i = 0; i < carList.Count; i++)
            {
                if (carList[i].ToString().Length != Program.carList[i].ToString().Length)
                {
                    CustomConsole.WriteMessage("\n");
                    CustomConsole.WriteErrorLine("Error: byte size mismatch, aborting file save");
                    CustomConsole.WriteWarningLine("Length in bytes need to match, click on the Help button for more information");
                    return;
                }
            }

            Program.carList = carList;

            try
            {
                FileStream file = new FileStream(Program.setupWadPath, FileMode.OpenOrCreate);
                file.Seek(9708, SeekOrigin.Begin);
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(toWrite);
                file.Write(byteArray, 0, toWrite.Length);
                file.Close();
            }
            catch(Exception)
            {
                CustomConsole.WriteErrorLine("Error: saving failed, check that the opened file is accessible and not opened in other programs");
                return;
            }

            CustomConsole.WriteMessageLine("completed!");
        }

        private string getNext(ref int i, char[] buffer)
        {
            char readByte;
            string component = "";
            while ((readByte = buffer[i++]) != ',')
            {
                component += readByte;
            }

            return component;
        }
        
        private string getLast(ref int i, char[] buffer, int bytesRead)
        {
            char readByte;
            string component = "";
            bool stop = false;
            while (!stop)
            {
                if (i < bytesRead)
                    if ((readByte = buffer[i++]) != '\n')
                        component += readByte;
                    else
                        stop = true;
                else
                    stop = true;
            }

            return component;
        }
    }
}
