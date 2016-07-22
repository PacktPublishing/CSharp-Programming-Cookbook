using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    #region Recipe 1 - Using Inheritance in C#
    /// <summary>
    /// Description:    This is the code for the Using Inheritance in C# Recipe found in Chapter 3
    /// Recipe:         Recipe 1 - Inheritance
    /// Chapter:        3
    /// </summary>
    public class SpaceShip
    {
        public void ControlBridge()
        {

        }
        public void MedicalBay(int patientCapacity)
        {

        }
        public void EngineRoom(int warpDrives)
        {

        }
        public void CrewQuarters(int crewCapacity)
        {

        }
        public void TeleportationRoom()
        {

        }
    }

    public class Destroyer : SpaceShip
    {
        public void WarRoom()
        {

        }
        public void Armory(int payloadCapacity)
        {

        }

        public void WarSpecialists(int activeBattalions)
        {

        }
    }

    public class Annihilator : Destroyer
    {
        public void TractorBeam()
        {

        }

        public void PlanetDestructionCapability()
        {

        }
    }
    #endregion

    #region Recipe 2 - Using Abstraction
    public abstract class SpaceCadet
    {
        public abstract void ChartingStarMaps();
        public abstract void BasicCommunicationSkill();
        public abstract void BasicWeaponsTraining();
        public abstract void Negotiation();
    }

    public abstract class SpacePrivate : SpaceCadet
    {
        public abstract void AdvancedCommunicationSkill();
        public abstract void AdvancedWeaponsTraining();
        public abstract void Persuader();
    }

    public class LabResearcher : SpaceCadet
    {
        public override void BasicCommunicationSkill()
        {
            throw new NotImplementedException();
        }

        public override void BasicWeaponsTraining()
        {
            throw new NotImplementedException();
        }

        public override void ChartingStarMaps()
        {
            throw new NotImplementedException();
        }

        public override void Negotiation()
        {
            throw new NotImplementedException();
        }
    }

    public class PlanetExplorer : SpacePrivate
    {
        public override void AdvancedCommunicationSkill()
        {
            throw new NotImplementedException();
        }

        public override void AdvancedWeaponsTraining()
        {
            throw new NotImplementedException();
        }

        public override void BasicCommunicationSkill()
        {
            throw new NotImplementedException();
        }

        public override void BasicWeaponsTraining()
        {
            throw new NotImplementedException();
        }

        public override void ChartingStarMaps()
        {
            throw new NotImplementedException();
        }

        public override void Negotiation()
        {
            throw new NotImplementedException();
        }

        public override void Persuader()
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    
    #region Recipe 3 - Leveraging Encapsulation
    public class LaunchShuttle
    {
        private double _EngineThrust;
        private double _TotalShuttleMass;
        private double _LocalGravitationalAcceleration;

        private const double EarthGravity = 9.81;
        private const double MoonGravity = 1.63;
        private const double MarsGravity = 3.75;
        private double UniversalGravitationalConstant;

        public enum Planet { Earth, Moon, Mars }

        public LaunchShuttle(double engineThrust, double totalShuttleMass, double gravitationalAcceleration)
        {
            _EngineThrust = engineThrust;
            _TotalShuttleMass = totalShuttleMass;
            _LocalGravitationalAcceleration = gravitationalAcceleration;

        }

        public LaunchShuttle(double engineThrust, double totalShuttleMass, Planet planet)
        {
            _EngineThrust = engineThrust;
            _TotalShuttleMass = totalShuttleMass;
            SetGraviationalAcceleration(planet);

        }

        public LaunchShuttle(double engineThrust, double totalShuttleMass, double planetMass, double planetRadius)
        {
            _EngineThrust = engineThrust;
            _TotalShuttleMass = totalShuttleMass;
            SetUniversalGravitationalConstant();
            _LocalGravitationalAcceleration = Math.Round(CalculateGravitationalAcceleration(planetRadius, planetMass), 2);
        }

        private void SetGraviationalAcceleration(Planet planet)
        {
            switch (planet)
            {
                case Planet.Earth:
                    _LocalGravitationalAcceleration = EarthGravity;
                    break;
                case Planet.Moon:
                    _LocalGravitationalAcceleration = MoonGravity;
                    break;
                case Planet.Mars:
                    _LocalGravitationalAcceleration = MarsGravity;
                    break;
                default:
                    break;
            }
        }

        private void SetUniversalGravitationalConstant()
        {
            UniversalGravitationalConstant = 6.6726 * Math.Pow(10, -11);
        }

        private double CalculateThrustToWeightRatio()
        {
            // TWR = Ft/m.g > 1
            return _EngineThrust / (_TotalShuttleMass * _LocalGravitationalAcceleration);
        }

        private double CalculateGravitationalAcceleration(double radius, double mass)
        {
            return (UniversalGravitationalConstant * mass) / Math.Pow(radius, 2);
        }

        public double TWR()
        {
            return Math.Round(CalculateThrustToWeightRatio(), 2);
        }
    }
    #endregion
    
    #region Recipe 4 - Implementing Polymorphism
    public abstract class Shuttle
    {
        public abstract double TWR();
    }

    public class NasaShuttle : Shuttle
    {
        public NasaShuttle(double engineThrust, double totalShuttleMass, double gravitationalAcceleration)
        {

        }

        public NasaShuttle(double engineThrust, double totalShuttleMass, double planetMass, double planetRadius)
        {

        }

        public override double TWR()
        {
            throw new NotImplementedException();
        }
    }

    public class RoscosmosShuttle : Shuttle
    {
        public override double TWR()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region Recipe 5 - SRP
    public class Starship
    {
        public void SetMaximumTroopCapacity(int capacity)
        {
            try
            {
                // Read current capacity and try to add more
            }
            catch (Exception ex)
            {
                string connectionString = "connection string goes here";
                string sql = $"INSERT INTO tblLog (error, date) VALUES ({ex.Message}, GetDate())";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                throw ex;
            }
        }
    }
    #endregion

    #region Recipe 6 - Open Closed Principle

    public class StarTrooper
    {
        public enum TrooperClass { Soldier, Medic, Scientist }
        List<string> TroopSkill;

        public List<string> GetSkills(TrooperClass troopClass)
        {
            switch (troopClass)
            {
                case TrooperClass.Soldier:
                    return TroopSkill = new List<string>(new string[] { "Weaponry", "TacticalCombat", "HandToHandCombat" });

                case TrooperClass.Medic:
                    return TroopSkill = new List<string>(new string[] { "CPR", "AdvancedLifeSupport" });

                case TrooperClass.Scientist:
                    return TroopSkill = new List<string>(new string[] { "Chemistry", "MollecularDeconstruction", "QuarkTheory" });

                default:
                    return TroopSkill = new List<string>(new string[] { "none" });

            }
        }
    }


    public class Trooper
    {
        public virtual List<string> GetSkills()
        {
            return new List<string>(new string[] { "none" });
        }
    }

    public class Soldier : Trooper
    {
        public override List<string> GetSkills()
        {
            return new List<string>(new string[] { "Weaponry", "TacticalCombat", "HandToHandCombat" });
        }
    }

    public class Medic : Trooper
    {
        public override List<string> GetSkills()
        {
            return new List<string>(new string[] { "CPR", "AdvancedLifeSupport" });
        }
    }

    public class Scientist : Trooper
    {
        public override List<string> GetSkills()
        {
            return new List<string>(new string[] { "Chemistry", "MollecularDeconstruction", "QuarkTheory" });
        }
    }


    public class Engineer : Trooper
    {
        public override List<string> GetSkills()
        {
            return new List<string>(new string[] { "Construction", "Demolition" });
        }
    }

    #endregion

}
