using KabadaAPI;
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
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 1, Value = "Raw materials, finished or semi-finished goods", Kind = (int)TexterRepository.EnumTexterKind.keySupplies });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 2, Value = "Equipment and real estate", Kind = (int)TexterRepository.EnumTexterKind.keySupplies });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 3, Value = "Outsourced services", Kind = (int)TexterRepository.EnumTexterKind.keySupplies });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 4, Value = "Financiers", Kind = (int)TexterRepository.EnumTexterKind.keySupplies });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), OrderValue = 5, Value = "Human resources", Kind = (int)TexterRepository.EnumTexterKind.keySupplies });
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
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Arrival of new technology", Kind = (int)TexterRepository.EnumTexterKind.oportunity, LongValue = "a" });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "New regulations", Kind = (int)TexterRepository.EnumTexterKind.oportunity, LongValue = "a" });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Unfulfilled customer need", Kind = (int)TexterRepository.EnumTexterKind.oportunity, LongValue = "a" });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Taking business courses (training)", Kind = (int)TexterRepository.EnumTexterKind.oportunity, LongValue = "a" });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "Trend changes", Kind = (int)TexterRepository.EnumTexterKind.oportunity, LongValue = "a" });
            modelBuilder.Entity<Texter>().HasData(new Texter { Id = Guid.NewGuid(), Value = "New substitute products", Kind = (int)TexterRepository.EnumTexterKind.oportunity, LongValue = "a" });
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
    }
  }
