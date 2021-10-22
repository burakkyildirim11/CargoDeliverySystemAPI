﻿using CargoDeliverySystemAPI.Data;
using CargoDeliverySystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoDeliverySystemAPI.Operations.CargoOperations.Commands
{
    public class CreateCargoCommand
    {
        private readonly ICargoDeliveryDBContext _cargoDeliveryDBContext;

         public CreateCargoViewModel Model;
        public CreateCargoCommand(ICargoDeliveryDBContext cargoDeliveryDBContext)
        {
            _cargoDeliveryDBContext = cargoDeliveryDBContext;
        }
       

        public ResultModel<CreateCargoViewModel> Handle()
        {
            try
            {
                Cargo cargo = new Cargo()
                {
                    Latitude = Model.Latitude,
                    Longitude = Model.Longitude
                };

                _cargoDeliveryDBContext.Cargos.Add(cargo);
                _cargoDeliveryDBContext.SaveChanges();

                return ResultModel<CreateCargoViewModel>.GenerateResult(Model, "Successfully written to database");
            }
            catch (Exception ex)
            {
                return ResultModel<CreateCargoViewModel>.GenerateResult(Model, "Could not write to database. " + ex.Message);
            }
        }
    }
}
