using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OGTools.Shared;
using OGTools.Shared.Models;

namespace OGTools.Server.Services
{
    public interface IShipFlightTimeService
    {
        List<ShipInfo> GetDefaultShipFlightParameters(PlayerTechnologies playerTechnologies);
    }

    public class ShipFlightTimeService : IShipFlightTimeService
    {
        /// <summary>
        ///
        ///     combustion drive    +10% per level
        ///     impulse drive       +20% per level
        ///     hyperspace drive    +30% per level
        /// 
        /// </summary>
        /// <param name="playerTechnologies"> player input from website </param>
        /// <returns> Default speed parameters including ONLY standard technologies (not life forms) </returns>
        public List<ShipInfo> GetDefaultShipFlightParameters(PlayerTechnologies playerTechnologies)
        {
            var shipsWithX1Speed = GetListOfShipsWithStandardInfo();

            shipsWithX1Speed.ForEach(ship =>
            {
                switch (ship.ShipDriveType)
                {
                    case (ShipDriveType.CombustionDrive):
                    {
                        if (ship.ShipName == "Small cargo" & playerTechnologies.ImpulseDriveLevel >= 5)
                            ship.PlayerClassBonus = CalculatePercentageByTechnology(ship.ShipBaseSpeed, 20, playerTechnologies.ImpulseDriveLevel);
                        else
                            ship.PlayerClassBonus = CalculatePercentageByTechnology(ship.ShipBaseSpeed, 10, playerTechnologies.CombustionDriveLevel);

                        break;
                    }
                    case (ShipDriveType.ImpulseDrive):
                    {
                        if(ship.ShipName == "Bomber" & playerTechnologies.HyperspaceDriveLevel >= 8)
                            ship.PlayerClassBonus = CalculatePercentageByTechnology(ship.ShipBaseSpeed, 30, playerTechnologies.ImpulseDriveLevel);

                        if(ship.ShipName == "Recycler" & playerTechnologies.HyperspaceDriveLevel >= 15)
                            ship.PlayerClassBonus = CalculatePercentageByTechnology(ship.ShipBaseSpeed, 30, playerTechnologies.ImpulseDriveLevel);
                        else
                            ship.PlayerClassBonus = CalculatePercentageByTechnology(ship.ShipBaseSpeed, 20, playerTechnologies.ImpulseDriveLevel);

                        break;
                    }
                    case (ShipDriveType.HyperspaceDrive):
                    {
                        ship.PlayerClassBonus = CalculatePercentageByTechnology(ship.ShipBaseSpeed, 30, playerTechnologies.ImpulseDriveLevel);
                        break;
                    }
                }
            });

            return shipsWithX1Speed;
        }

        private List<ShipInfo> GetListOfShipsWithStandardInfo()
        {
            return new List<ShipInfo>
            {
                new ShipInfo { ShipName = "Small cargo", ShipBaseSpeed = 10000, ShipDriveType = ShipDriveType.CombustionDrive},
                new ShipInfo { ShipName = "Large cargo", ShipBaseSpeed = 7500, ShipDriveType = ShipDriveType.CombustionDrive},
                new ShipInfo { ShipName = "Light fighter", ShipBaseSpeed = 12500, ShipDriveType = ShipDriveType.CombustionDrive},
                new ShipInfo { ShipName = "Heavy Fighter", ShipBaseSpeed = 10000, ShipDriveType = ShipDriveType.ImpulseDrive},
                new ShipInfo { ShipName = "Cruiser", ShipBaseSpeed = 15000, ShipDriveType = ShipDriveType.ImpulseDrive},
                new ShipInfo { ShipName = "Battleship", ShipBaseSpeed = 10000, ShipDriveType = ShipDriveType.HyperspaceDrive},
                new ShipInfo { ShipName = "Battlecruiser", ShipBaseSpeed = 10000, ShipDriveType = ShipDriveType.HyperspaceDrive},
                new ShipInfo { ShipName = "Bomber", ShipBaseSpeed = 5000, ShipDriveType = ShipDriveType.ImpulseDrive},
                new ShipInfo { ShipName = "Destroyer", ShipBaseSpeed = 5000, ShipDriveType = ShipDriveType.HyperspaceDrive},
                new ShipInfo { ShipName = "Death star", ShipBaseSpeed = 100, ShipDriveType = ShipDriveType.HyperspaceDrive},
                new ShipInfo { ShipName = "Reaper", ShipBaseSpeed = 7000, ShipDriveType = ShipDriveType.HyperspaceDrive},
                new ShipInfo { ShipName = "Pathfinder", ShipBaseSpeed = 12000, ShipDriveType = ShipDriveType.HyperspaceDrive},
                new ShipInfo { ShipName = "Colony ship", ShipBaseSpeed = 2500, ShipDriveType = ShipDriveType.ImpulseDrive},
                new ShipInfo { ShipName = "Recycler", ShipBaseSpeed = 6000, ShipDriveType = ShipDriveType.CombustionDrive},
                new ShipInfo { ShipName = "Espionage probe", ShipBaseSpeed = 100000000, ShipDriveType = ShipDriveType.CombustionDrive}
            };
        }
        private decimal CalculatePercentageByTechnology(decimal baseSpeed, int percentage, int technologyLevel)
        {
            decimal percentagePerOneLevel = (decimal) percentage / 100 * baseSpeed;
            decimal percentageByTechnology = percentagePerOneLevel * technologyLevel;

            return percentageByTechnology;
        }
    }
}
