using Porta.DataAccess.Domain;
using Portal.MetaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace Portal.WebApp
{
    public class AutoMapperBootStrapper
    {
        public static void BootStrap()
        {
            Mapper.CreateMap<Employee, EmployeeMetaData>();
            Mapper.CreateMap<EmployeeMetaData, Employee>();
        }
    }
}