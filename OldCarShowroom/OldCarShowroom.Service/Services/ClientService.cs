using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using OldCarShowroom.Service.Models;
using OldCarShowroom.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldCarShowroom.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly OldCarShowroomContext _context;
        public ClientService(OldCarShowroomContext context)
        {
            _context = context;
        }
        public async Task<Client?> Login(string email, string password)
        {
            var account = await _context.Set<Client>().FirstOrDefaultAsync(c => c.Email == email);
            if (account != null && BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                return account;
            }
            else
            {
                return null;
            }
        }
    }
}
