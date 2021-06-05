﻿using Core.Managers.Helpers;
using Core.Managers.MangersImplementations;
using DataContracts;
using Model;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace ManagerCreater
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new AdwentureWorksContext());

            var salesPersons = unitOfWork.SalesPerson.GetList().ToList();
            List<UserDTO> managers = new List<UserDTO>();

            var userManager = new UserManager();
            foreach(var salesPerson in salesPersons)
            {
                var uniqUnit = Guid.NewGuid().ToString().Split('-').First();

                string email = uniqUnit + "@m.kz";
                string password = uniqUnit;

                var userDto = new UserDTO()
                {
                    Email = email,
                    Password = password,
                    UserName = email,
                    Role = "admin"
                };

                var businessEntity = unitOfWork.BusinessEntity.Get(salesPerson.BusinessEntityID);

                var applicationUser = ApplicationUserCreator.CreateFromUserDTO(userDto);

                var a = unitOfWork.ApplicationUser.Create(applicationUser, userDto.Password);
                unitOfWork.ApplicationUser.AddToRole(applicationUser.Id, userDto.Role);

                var aspNetUsersBusinesEntity = unitOfWork.AspNetUsersBusinesEntity.Create(AspNetUsersBusinesEntityCreator.Create(applicationUser, businessEntity));
                unitOfWork.Complete();

                Console.WriteLine(email + "\t" + password + "\t" + salesPerson.TerritoryID);
            }
            Console.ReadLine();
        }
    }
}
