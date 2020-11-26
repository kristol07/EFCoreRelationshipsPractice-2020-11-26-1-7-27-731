﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EFCoreRelationshipsPracticeTest
{
    public class CompanyServiceTests : TestBase
    {
        public CompanyServiceTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_create_company_success_via_company_service()
        {
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19
                },
            };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };

            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<CompanyDbContext>();

            var companyService = new CompanyService(context);
            await companyService.AddCompany(companyDto);
            Assert.Single(context.Companies);
        }
    }
}
