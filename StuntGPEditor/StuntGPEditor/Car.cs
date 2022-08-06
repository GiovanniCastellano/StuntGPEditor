using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuntGPEditor
{
    public class Car
    {
        #region ATTRIBUTES
        public string name { get; set; }
        public string cost { get; set; }
        public string baseMass { get; set; }
        public string additiveMass { get; set; }
        public string trackFront { get; set; }
        public string trackRear { get; set; }
        public string wheelBase { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string comA { get; set; }
        public string comB { get; set; }
        public string comH { get; set; }
        public string rideHeight { get; set; }
        public string cm { get; set; }
        public string rpmIdle { get; set; }
        public string rpmLimit { get; set; }
        public string rpmMax { get; set; }
        public string maxTorque { get; set; }
        public string torqueEnv { get; set; }
        public string driveMode { get; set; }
        public string finalDrive { get; set; }
        public string gears { get; set; }
        public string shift { get; set; }
        public string efficiency { get; set; }
        public string split4WD { get; set; }
        public string gearCog1 { get; set; }
        public string gearCog2 { get; set; }
        public string gearCog3 { get; set; }
        public string gearCog4 { get; set; }
        public string gearCog5 { get; set; }
        public string gearCog6 { get; set; }
        public string gearCog7 { get; set; }
        public string gearCog8 { get; set; }
        public string brakeBias { get; set; }
        public string brakeAccel { get; set; }
        public string radius { get; set; }
        public string pressure { get; set; }
        public string travelIn { get; set; }
        public string dampingIn { get; set; }
        public string stiffnessIn { get; set; }
        public string maxTravel { get; set; }
        public string maxDamp { get; set; }
        public string maxStiffness { get; set; }
        public string tread { get; set; }
        public string tyreEnvelope { get; set; }
        public string cs { get; set; }
        public string ck { get; set; }
        public string cd { get; set; }
        public string cl { get; set; }
        public string sensitivity { get; set; }
        public string acceleration { get; set; }
        public string steeringAngle { get; set; }
        public string maxFuel { get; set; }
        public string fuelConsumption { get; set; }
        public string refuelRate { get; set; }
        public string unitMass { get; set; }
        public string rpmAcc { get; set; }
        public string rpmMax2 { get; set; }
        public string cm2 { get; set; }
        public string powerMult { get; set; }
        public string maxConsump { get; set; }
        public string fuelCutOff { get; set; }
        public string horn { get; set; }
        public string engine { get; set; }
        public string engineIdle { get; set; }
        public string engineBoost { get; set; }
        public string launchTime { get; set; }
        public string launchTolerance { get; set; }
        public string launchSpeed { get; set; }
        public string matRotSpeedX { get; set; }
        public string matRotSpeedY { get; set; }
        public string brakeAssist { get; set; }
        public string steerAssist { get; set; }
        public string bonusLivery { get; set; }
        public string strength { get; set; }
        #endregion

        public Car() { }

        public Car(Car car)
        {
            this.name =             car.name;
            this.cost =             car.cost;
            this.baseMass =         car.baseMass;
            this.additiveMass =     car.additiveMass;
            this.trackFront =       car.trackFront;
            this.trackRear =        car.trackRear;
            this.wheelBase =        car.wheelBase;
            this.length =           car.length;
            this.width =            car.width;
            this.height =           car.height;
            this.comA =             car.comA;
            this.comB =             car.comB;
            this.comH =             car.comH;
            this.rideHeight =       car.rideHeight;
            this.cm =               car.cm;
            this.rpmIdle =          car.rpmIdle;
            this.rpmLimit =         car.rpmLimit;
            this.rpmMax =           car.rpmMax;
            this.maxTorque =        car.maxTorque;
            this.torqueEnv =        car.torqueEnv;
            this.driveMode =        car.driveMode;
            this.finalDrive =       car.finalDrive;
            this.gears =            car.gears;
            this.shift =            car.shift;
            this.efficiency =       car.efficiency;
            this.split4WD =         car.split4WD;
            this.gearCog1 =         car.gearCog1;
            this.gearCog2 =         car.gearCog2;
            this.gearCog3 =         car.gearCog3;
            this.gearCog4 =         car.gearCog4;
            this.gearCog5 =         car.gearCog5;
            this.gearCog6 =         car.gearCog6;
            this.gearCog7 =         car.gearCog7;
            this.gearCog8 =         car.gearCog8;
            this.brakeBias =        car.brakeBias;
            this.brakeAccel =       car.brakeAccel;
            this.radius =           car.radius;
            this.pressure =         car.pressure;
            this.travelIn =         car.travelIn;
            this.dampingIn =        car.dampingIn;
            this.stiffnessIn =      car.stiffnessIn;
            this.maxTravel =        car.maxTravel;
            this.maxDamp =          car.maxDamp;
            this.maxStiffness =     car.maxStiffness;
            this.tread =            car.tread;
            this.tyreEnvelope =     car.tyreEnvelope;
            this.cs =               car.cs;
            this.ck =               car.ck;
            this.cd =               car.cd;
            this.cl =               car.cl;
            this.sensitivity =      car.sensitivity;
            this.acceleration =     car.acceleration;
            this.steeringAngle =    car.steeringAngle;
            this.maxFuel =          car.maxFuel;
            this.fuelConsumption =  car.fuelConsumption;
            this.refuelRate =       car.refuelRate;
            this.unitMass =         car.unitMass;
            this.rpmAcc =           car.rpmAcc;
            this.rpmMax2 =          car.rpmMax2;
            this.cm2 =              car.cm2;
            this.powerMult =        car.powerMult;
            this.maxConsump =       car.maxConsump;
            this.fuelCutOff =       car.fuelCutOff;
            this.horn =             car.horn;
            this.engine =           car.engine;
            this.engineIdle =       car.engineIdle;
            this.engineBoost =      car.engineBoost;
            this.launchTime =       car.launchTime;
            this.launchSpeed =      car.launchSpeed;
            this.launchTolerance =  car.launchTolerance;
            this.matRotSpeedX =     car.matRotSpeedX;
            this.matRotSpeedY =     car.matRotSpeedY;
            this.brakeAssist =      car.brakeAssist;
            this.steerAssist =      car.steerAssist;
            this.bonusLivery =      car.bonusLivery;
            this.strength =         car.strength;
        }

        public override string ToString()
        {
            return  name + "," +
                    cost + "," +
                    baseMass + "," +
                    additiveMass + "," +
                    trackFront + "," +
                    trackRear + "," +
                    wheelBase + "," +
                    length + "," +
                    width + "," +
                    height + "," +
                    comA + "," +
                    comB + "," +
                    comH + "," +
                    rideHeight + "," +
                    cm + "," +
                    rpmIdle + "," +
                    rpmLimit + "," +
                    rpmMax + "," +
                    maxTorque + "," +
                    torqueEnv + "," +
                    driveMode + "," +
                    finalDrive + "," +
                    gears + "," +
                    shift + "," +
                    efficiency + "," +
                    split4WD + "," +
                    gearCog1 + "," +
                    gearCog2 + "," +
                    gearCog3 + "," +
                    gearCog4 + "," +
                    gearCog5 + "," +
                    gearCog6 + "," +
                    gearCog7 + "," +
                    gearCog8 + "," +
                    brakeBias + "," +
                    brakeAccel + "," +
                    radius + "," +
                    pressure + "," +
                    travelIn + "," +
                    dampingIn + "," +
                    stiffnessIn + "," +
                    maxTravel + "," +
                    maxDamp + "," +
                    maxStiffness + "," +
                    tread + "," +
                    tyreEnvelope + "," +
                    cs + "," +
                    ck + "," +
                    cd + "," +
                    cl + "," +
                    sensitivity + "," +
                    acceleration + "," +
                    steeringAngle + "," +
                    maxFuel + "," +
                    fuelConsumption + "," +
                    refuelRate + "," +
                    unitMass + "," +
                    rpmAcc + "," +
                    rpmMax2 + "," +
                    cm2 + "," +
                    powerMult + "," +
                    maxConsump + "," +
                    fuelCutOff + "," +
                    horn + "," +
                    engine + "," +
                    engineIdle + "," +
                    engineBoost + "," +
                    launchTime + "," +
                    launchTolerance + "," +
                    launchSpeed + "," +
                    matRotSpeedX + "," +
                    matRotSpeedY + "," +
                    brakeAssist + "," +
                    steerAssist + "," +
                    bonusLivery + "," +
                    strength + "\n";
    }
    }
}
