using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCSharp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCSharp.Context
{
    public class ScheduleContext : DbContext
    {
        //Gerencimento da conexão com o banco de dados
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {

        }

        //Referenciando a entidade para a tabela do banco de dados
        public DbSet<Contact> Contacts {get; set;}
    }
}