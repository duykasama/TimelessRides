using OldCarShowroom.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldCarShowroom.Service.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client?> Login(string email, string password);
    }
}
