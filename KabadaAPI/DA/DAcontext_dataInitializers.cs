using KabadaAPIdao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace KabadaAPI {
  partial class DAcontext {

        private void AddData_PartnersTypes(ModelBuilder modelBuilder)
        {
            //--- Distributors types
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Self distribution", Kind = (int)TexterRepository.EnumTexterKind.keyDistributors, LongValue = "Possible if you distribute your products through your own channels – directly, your own store, homepage. Often the case in some service sectors" });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Highly diversified distributors", Kind = (int)TexterRepository.EnumTexterKind.keyDistributors, LongValue = "You can choose «Many Distributors» if you believe that distribution channels are strongly diversified and no distributor is of high importance" });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Retailers", Kind = (int)TexterRepository.EnumTexterKind.keyDistributors });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Wholesalers", Kind = (int)TexterRepository.EnumTexterKind.keyDistributors });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 5, Value = "Agents", Kind = (int)TexterRepository.EnumTexterKind.keyDistributors });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 6, Value = "Others", Kind = (int)TexterRepository.EnumTexterKind.keyDistributors });
            //--- Suppliers types
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Raw materials, finished or semi-finished goods", Kind = (int)TexterRepository.EnumTexterKind.keySuppliers });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Equipment and real estate", Kind = (int)TexterRepository.EnumTexterKind.keySuppliers });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Outsourced services", Kind = (int)TexterRepository.EnumTexterKind.keySuppliers });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Financiers", Kind = (int)TexterRepository.EnumTexterKind.keySuppliers });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 5, Value = "Human resources", Kind = (int)TexterRepository.EnumTexterKind.keySuppliers });
            //--- Other types
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Associations", Kind = (int)TexterRepository.EnumTexterKind.keyPartnersOther });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Government institutions", Kind = (int)TexterRepository.EnumTexterKind.keyPartnersOther });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Non-governmental institutions", Kind = (int)TexterRepository.EnumTexterKind.keyPartnersOther });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Consultants", Kind = (int)TexterRepository.EnumTexterKind.keyPartnersOther });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.keyPartnersOther });
         }
        private void AddData_KeyResourcesTexters(ModelBuilder modelBuilder)
        {
            var catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 1, Value = "Physical resources", Kind = (int)TexterRepository.EnumTexterKind.keyResourceCategory, LongValue = "Physical assets are tangible resources that a company uses to create its value proposition. These could include equipment, inventory, buildings, manufacturing plants and distribution networks that enable the business to function." });
            var typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 1, Value = "Buildings", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            //modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Office", Kind = (int)TexterRepository.EnumTexterKind.keyResourceSubType, MasterId = typeGuid });
            //modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Manufacturing Buildings", Kind = (int)TexterRepository.EnumTexterKind.keyResourceSubType, MasterId = typeGuid });
            //modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Inventory Buildings", Kind = (int)TexterRepository.EnumTexterKind.keyResourceSubType, MasterId = typeGuid });
            //modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Sales Buildings (Shop)", Kind = (int)TexterRepository.EnumTexterKind.keyResourceSubType, MasterId = typeGuid });
            //modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 5, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.keyResourceSubType, MasterId = typeGuid });
            var options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Rent", selected=default},
                new Kabada.ResourceOption(){title="Buy", selected=default},
                new Kabada.ResourceOption(){title="Own", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Ownership type", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Permanently", selected=default},
                new Kabada.ResourceOption(){title="Time to time", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Frequency", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });

            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 2, Value = "Equipment", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Rent", selected=default},
                new Kabada.ResourceOption(){title="Buy", selected=default},
                new Kabada.ResourceOption(){title="Own", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Ownership type", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Permanently", selected=default},
                new Kabada.ResourceOption(){title="Time to time", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Frequency", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });

            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 3, Value = "Transport", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Rent", selected=default},
                new Kabada.ResourceOption(){title="Buy", selected=default},
                new Kabada.ResourceOption(){title="Own", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Ownership type", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Permanently", selected=default},
                new Kabada.ResourceOption(){title="Time to time", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Frequency", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });

            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 4, Value = "Raw materials", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Buy", selected=default},
                new Kabada.ResourceOption(){title="Own", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Ownership type", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });
           
            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 5, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Rent", selected=default},
                new Kabada.ResourceOption(){title="Buy", selected=default},
                new Kabada.ResourceOption(){title="Own", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Ownership type", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Permanently", selected=default},
                new Kabada.ResourceOption(){title="Time to time", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Frequency", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });


            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 2, Value = "Intellectual resources", Kind = (int)TexterRepository.EnumTexterKind.keyResourceCategory, LongValue = "These are non-physical, intangible resources like brand, patents, IP, copyrights, and even partnerships. Customer lists, customer knowledge, and even your own people, represent a form of intellectual resource. Intellectual resources take a great deal of time and expenditure to develop. But once developed, they can offer unique advantages to the company." });
            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 1, Value = "Brands", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 2, Value = "Licenses", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 3, Value = "Software", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 4, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });

            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 3, Value = "Human resources", Kind = (int)TexterRepository.EnumTexterKind.keyResourceCategory, LongValue = "Employees are often the most important and yet the most easily overlooked assets of an organization. Specifically for companies in the service industries or require a great deal of creativity and an extensive knowledge pool, human resources such as customer service representatives, software engineers or scientists are pivotal." });
            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 1, Value = "Specialists & Know-how", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Employ", selected=default},
                new Kabada.ResourceOption(){title="Outsource", selected=default},
                new Kabada.ResourceOption(){title="Myself", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Ownership type", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Permanently", selected=default},
                new Kabada.ResourceOption(){title="Time to time", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Frequency", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });

            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 2, Value = "Administrative", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Employ", selected=default},
                new Kabada.ResourceOption(){title="Outsource", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Ownership type", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Permanently", selected=default},
                new Kabada.ResourceOption(){title="Time to time", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Frequency", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });

            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 3, Value = "Employees directly involved in production or service", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Employ", selected=default},
                new Kabada.ResourceOption(){title="Outsource", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Ownership type", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Permanently", selected=default},
                new Kabada.ResourceOption(){title="Time to time", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Frequency", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue = options });

            typeGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 4, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Employ", selected=default},
                new Kabada.ResourceOption(){title="Outsource", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Ownership type", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue=options });           
            options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            {
                new Kabada.ResourceOption(){title="Permanently", selected=default},
                new Kabada.ResourceOption(){title="Time to time", selected=default},
            });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Frequency", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = typeGuid, LongValue=options });

            //catGuid = Guid.NewGuid();
            //modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 4, Value = "Financial resources", Kind = (int)TexterRepository.EnumTexterKind.keyResourceCategory, LongValue = "The financial resource includes cash, lines of credit and the ability to have stock option plans for employees. All businesses have key resources in finance, but some will have stronger financial resources than other, such as banks that are based entirely on the availability of this key resource." });
            //typeGuid = Guid.NewGuid();
            //modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 1, Value = "For start-up", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            //typeGuid = Guid.NewGuid();
            //modelBuilder.Entity<Texter>().HasData(new Texter { Id = typeGuid, OrderValue = 2, Value = "Operational", Kind = (int)TexterRepository.EnumTexterKind.keyResourceType, MasterId = catGuid });
            ////selGuid = Guid.NewGuid();
            //options = Newtonsoft.Json.JsonConvert.SerializeObject(new List<Kabada.ResourceOption>()
            //{
            //    new Kabada.ResourceOption(){title="Yes", selected=default},
            //    new Kabada.ResourceOption(){title="No", selected=default},
            //});
            //modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Is available?", Kind = (int)TexterRepository.EnumTexterKind.keyResourcesSelection, MasterId = catGuid, LongValue=options });

            //catGuid = Guid.NewGuid();
            //modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 5, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.keyResourceCategory, LongValue = "" });
        }

        private void AddData_SWOTtexters(ModelBuilder modelBuilder)
        {
            //Strengths and weaknesses part
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Land", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 1 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Facilities and equipment", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 2 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Vehicles", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 3 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Inventory", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 4 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Skills and experience of employees", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 5 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Corporate image", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 6 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Patents", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 7 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Trademarks", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 8 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Copyrights", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 9 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Operational processes", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 10 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Management processes", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 11 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Supporting processes", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 12 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Product design", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 13 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Product assortment", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 14 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Packaging and labeling", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 15 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Complementary and after-sales service", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 16 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Guarantees and warranties", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 17 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Return of goods", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 18 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Price", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 19 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Discounts", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 20 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Payment terms", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 21 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Customer convenient access to products", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 22 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Advertising, PR and sales promotion", Kind = (int)TexterRepository.EnumTexterKind.strength, LongValue = "a", OrderValue = 23 });
            //opportinities part
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Political stability", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 1});
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Government regulation", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 2 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Economic growth", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 3 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Income and wealth", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 4 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Inflation", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 5 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Exchange rate", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 6 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Interest rate", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 7 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Accessibility of human resources", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 8 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Accessibility of tangible resources", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 9 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Accessibility of financial resources", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 10 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Market size", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 11 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "New markets", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 12 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Infrastructure", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 13 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Demographic trends", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 14 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Cultural norms and values", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 15 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Lifestyle trends", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 16 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Technological change", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 17 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Cybersecurity", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 18 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Climate and its change", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 19 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Natural disasters", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 20 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Competition", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 21 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Bargaining power of suppliers", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 22 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Bargaining power of buyers", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 23 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Potential/future competition", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 24 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Substitution possibilities", Kind = (int)TexterRepository.EnumTexterKind.oportunity, OrderValue = 25 });
        }

        private void AddData_Countries(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Austria", ShortCode = "AT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Bosnia and Herzegovina", ShortCode = "BA" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Belgium", ShortCode = "BE" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Bulgaria", ShortCode = "BG" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Croatia", ShortCode = "HR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Cyprus", ShortCode = "CY" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Czechia", ShortCode = "CZ" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Denmark", ShortCode = "DK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Estonia", ShortCode = "EE" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Finland", ShortCode = "FI" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "France", ShortCode = "FR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Germany", ShortCode = "DE" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Greece", ShortCode = "EL" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Hungary", ShortCode = "HU" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Iceland", ShortCode = "IS" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Ireland", ShortCode = "IE" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Italy", ShortCode = "IT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Latvia", ShortCode = "LV" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Liechtenstein", ShortCode = "LI" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Lithuania", ShortCode = "LT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Luxembourg", ShortCode = "LU" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Malta", ShortCode = "MT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Netherlands", ShortCode = "NL" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "North Macedonia", ShortCode = "MK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Norway", ShortCode = "NO" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Poland", ShortCode = "PL" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Portugal", ShortCode = "PT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Romania", ShortCode = "RO" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Serbia", ShortCode = "RS" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Slovakia", ShortCode = "SK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Slovenia", ShortCode = "SI" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Spain", ShortCode = "ES" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Sweden", ShortCode = "SE" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Switzerland", ShortCode = "CH" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "Turkey", ShortCode = "TR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Title = "United Kingdom", ShortCode = "UK" });
        }

        private void AddData_UserTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 1, Title = "Administrator" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 100, Title = "Simple" });
        }

       private void AddData_Languages(ModelBuilder modelBuilder) {
         modelBuilder.Entity<Language>().HasData(new Language { Id = Guid.NewGuid(), Code="EN", Title="English" });
         }

       private void AddData_ProductsTypes (ModelBuilder modelBuilder) {
         modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Physical good", Kind = (int)TexterRepository.EnumTexterKind.productType, OrderValue = 1 });
         modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Service", Kind = (int)TexterRepository.EnumTexterKind.productType, OrderValue = 2 });
         }

    private void act(ModelBuilder modelBuilder, Guid g, string v1, string v2) {
      var o=new Activity(){ Code=v1, Title=v2, Id=Guid.NewGuid(), IndustryId=g};
      modelBuilder.Entity<Activity>().HasData(o);
      }

    private Guid ind(ModelBuilder modelBuilder, string v1, string v2) {
      var o=new Industry(){ Code=v1, Language="EN", Title=v2, Id=Guid.NewGuid()};
      modelBuilder.Entity<Industry>().HasData(o);
      return o.Id;
      }

    private void AddData_ProductIncomeSources (ModelBuilder modelBuilder) {
        modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Non time limited usage", Kind = (int)TexterRepository.EnumTexterKind.productAdditionalIncomeSource, OrderValue = 1 });
        modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Additional functions", Kind = (int)TexterRepository.EnumTexterKind.productAdditionalIncomeSource, OrderValue = 2 });
        modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Paid plans", Kind = (int)TexterRepository.EnumTexterKind.productAdditionalIncomeSource, OrderValue = 3 });
        modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Different price for business", Kind = (int)TexterRepository.EnumTexterKind.productAdditionalIncomeSource, OrderValue = 4 });
        modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Different price for individuals", Kind = (int)TexterRepository.EnumTexterKind.productAdditionalIncomeSource, OrderValue = 5 });
        modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Fees come from another product", Kind = (int)TexterRepository.EnumTexterKind.productAdditionalIncomeSource, OrderValue = 6 });
        modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.productAdditionalIncomeSource, OrderValue = 7 });
        }
    private void AddData_ProductFeatures (ModelBuilder modelBuilder) {
        modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Not different from competitors", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 1 });
        modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Product or service already exists in the market", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 2 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "No improvements or innovations", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 3 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Continuous", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 4 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Based on old technology", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 5 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Dominant design unchanged", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 6 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Improvement of existing characteristics", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 7 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Result of R&D", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 8 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Driven by market pull", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 9 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Discontinuous", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 10 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Based on new technologies", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 11 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Leads to a new design", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 12 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Uncertainty", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 13 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "New set of features", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 14 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Driven by technology", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 15 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Expertise of manufacturer", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 16 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Manufacturing complexity", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 17 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Special materials and components", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 18 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Workmanship", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 19 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Rarity", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 20 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Durability", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 21 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Comfortability & Usability", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 22 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Safety", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 23 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Aesthetics", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 24 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Extraordinariness", Kind = (int)TexterRepository.EnumTexterKind.productFeature, OrderValue = 25 });

        }
        private void AddData_ProductsPriceLevels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Free", Kind = (int)TexterRepository.EnumTexterKind.productPriceLevel, OrderValue = 1 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Economy", Kind = (int)TexterRepository.EnumTexterKind.productPriceLevel, OrderValue = 2 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Market", Kind = (int)TexterRepository.EnumTexterKind.productPriceLevel, OrderValue = 3 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "High-end", Kind = (int)TexterRepository.EnumTexterKind.productPriceLevel, OrderValue = 4 });
        }
        private void AddData_ProductsInnovativeOptions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Not", Kind = (int)TexterRepository.EnumTexterKind.productInnovativeOption, OrderValue = 1 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Medium", Kind = (int)TexterRepository.EnumTexterKind.productInnovativeOption, OrderValue = 2 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Highly", Kind = (int)TexterRepository.EnumTexterKind.productInnovativeOption, OrderValue = 3 });
        }
        private void AddData_ProductsQualityOptions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Basic", Kind = (int)TexterRepository.EnumTexterKind.productQualityOption, OrderValue = 1 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Medium", Kind = (int)TexterRepository.EnumTexterKind.productQualityOption, OrderValue = 2 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Premium", Kind = (int)TexterRepository.EnumTexterKind.productQualityOption, OrderValue = 3 });
        }
        private void AddData_ProductsDiffOptions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Not", Kind = (int)TexterRepository.EnumTexterKind.productDifferentiationOption, OrderValue = 1 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Medium", Kind = (int)TexterRepository.EnumTexterKind.productDifferentiationOption, OrderValue = 2 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Highly", Kind = (int)TexterRepository.EnumTexterKind.productDifferentiationOption, OrderValue = 3 });
        }
        private void AddData_CostTypes(ModelBuilder modelBuilder)
        {
            //----fixed cost
            var catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 1, Value = "Rent of office", Kind = (int)TexterRepository.EnumTexterKind.fixedCostCategory});            
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 2, Value = "Rent of buildings", Kind = (int)TexterRepository.EnumTexterKind.fixedCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Manufacturing buildings", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Inventory buildings", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Sales buildings (shops)", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 3, Value = "Rent of equipment", Kind = (int)TexterRepository.EnumTexterKind.fixedCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "IT (office) equipment", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Production equipment and machinery", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Transport", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 4, Value = "Utilities", Kind = (int)TexterRepository.EnumTexterKind.fixedCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Electricity", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Water", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Gas", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Heat", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 5, Value = "Maintenance", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 6, Value = "Communication", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 7, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 4, Value = "Outsourcing of services", Kind = (int)TexterRepository.EnumTexterKind.fixedCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Accountant", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "IT support", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 5, Value = "Outsourcing of specified services", Kind = (int)TexterRepository.EnumTexterKind.fixedCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 6, Value = "Salaries", Kind = (int)TexterRepository.EnumTexterKind.fixedCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Management", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Factory workers / service", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Finance management", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Marketing", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 5, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 7, Value = "Permits & Licenses", Kind = (int)TexterRepository.EnumTexterKind.fixedCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 8, Value = "Marketing", Kind = (int)TexterRepository.EnumTexterKind.fixedCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 9, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.fixedCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            //----variable cost
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 1, Value = "Resources", Kind = (int)TexterRepository.EnumTexterKind.variableCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 2, Value = "Rent (short term)", Kind = (int)TexterRepository.EnumTexterKind.variableCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Manufacturing building", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Office", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Equipment", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 3, Value = "Packaging", Kind = (int)TexterRepository.EnumTexterKind.variableCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 4, Value = "Salaries", Kind = (int)TexterRepository.EnumTexterKind.variableCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Employees directly involved in production / service", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 5, Value = "Outsourcing of specified services", Kind = (int)TexterRepository.EnumTexterKind.variableCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 6, Value = "Permits & licenses", Kind = (int)TexterRepository.EnumTexterKind.variableCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 7, Value = "Marketing", Kind = (int)TexterRepository.EnumTexterKind.variableCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 8, Value = "Distribution", Kind = (int)TexterRepository.EnumTexterKind.variableCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Transport", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Cost of warehouse", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Fees to distributors", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 9, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.variableCostCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Other", Kind = (int)TexterRepository.EnumTexterKind.costType, MasterId = catGuid });

        }
        private void AddData_RevenueStreamTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Asset sale", Kind = (int)TexterRepository.EnumTexterKind.revenueStreamType, OrderValue = 1 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Usage fee", Kind = (int)TexterRepository.EnumTexterKind.revenueStreamType, OrderValue = 2 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Subscription fee", Kind = (int)TexterRepository.EnumTexterKind.revenueStreamType, OrderValue = 3 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Lending, renting, leasing", Kind = (int)TexterRepository.EnumTexterKind.revenueStreamType, OrderValue = 4 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Licensing", Kind = (int)TexterRepository.EnumTexterKind.revenueStreamType, OrderValue = 5 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Brokerage fees", Kind = (int)TexterRepository.EnumTexterKind.revenueStreamType, OrderValue = 6 });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Advertising", Kind = (int)TexterRepository.EnumTexterKind.revenueStreamType, OrderValue = 7 });
        }
        private void AddData_RevenuePriceTypes(ModelBuilder modelBuilder)
        {           
            var catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 1, Value = "Fixed pricing", Kind = (int)TexterRepository.EnumTexterKind.revenuePriceCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "List price", Kind = (int)TexterRepository.EnumTexterKind.revenuePriceType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Product feature dependent", Kind = (int)TexterRepository.EnumTexterKind.revenuePriceType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Volume dependent", Kind = (int)TexterRepository.EnumTexterKind.revenuePriceType, MasterId = catGuid });
            catGuid = Guid.NewGuid();
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = catGuid, OrderValue = 2, Value = "Dynamic pricing", Kind = (int)TexterRepository.EnumTexterKind.revenuePriceCategory });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Negotiation", Kind = (int)TexterRepository.EnumTexterKind.revenuePriceType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Yield management", Kind = (int)TexterRepository.EnumTexterKind.revenuePriceType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Real time market", Kind = (int)TexterRepository.EnumTexterKind.revenuePriceType, MasterId = catGuid });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Auctions", Kind = (int)TexterRepository.EnumTexterKind.revenuePriceType, MasterId = catGuid });

        }
    }
    }
