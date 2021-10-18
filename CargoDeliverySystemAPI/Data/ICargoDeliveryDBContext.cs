using CargoDeliverySystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoDeliverySystemAPI.Data
{
    interface ICargoDeliveryDBContext
    {
        DbSet<Carrier> Carrier { get; set; }
        DbSet<CarriersLog> CarriersLogs { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Cargo> Cargos { get; set; }
    }
}
