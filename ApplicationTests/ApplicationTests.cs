using AutoMapper;
using Domain.Commands.ApplicationCommand;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace ApplicationTests
{

    public class ApplicationServiceTests
    {
        [Fact]
        public void GetAll_ShouldReturnAplications_WhenAplicationsExists()
        {
            //Arrange 
            var applications = GetApplications();
            Mock<IApplicationRepository> mockRepo = new Mock<IApplicationRepository>();
            mockRepo.Setup(x => x.GetAsync()).ReturnsAsync(value: applications);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMapProfile());
            });
            var mapper = mockMapper.CreateMapper();

            ApplicationService applicationService = new ApplicationService(mockRepo.Object, mapper);
            // Act
            var result = applicationService.GetAsync();

            // Assert
            Assert.Equal(applications, result.Result);

        }

        [Fact]
        public void Get_ShouldReturnAplication_WhenAplicationExists()
        {
            //Arrange 
            var application = GetApplication();
            Mock<IApplicationRepository> mockRepo = new Mock<IApplicationRepository>();
            mockRepo.Setup(x => x.GetAsync(1)).ReturnsAsync(value: application);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMapProfile());
            });
            var mapper = mockMapper.CreateMapper();

            ApplicationService applicationService = new ApplicationService(mockRepo.Object, mapper);
            // Act
            var result = applicationService.GetAsync(1);

            // Assert
            Assert.Equal(application, result.Result);
        }

        [Fact]
        public void CreateApplication_ShouldReturnAddedApplication()
        {
            //Arrange 
            AddApplicationCommand applicationCommand = GetApplicationCommand();
            Application application = GetApplication();
            Mock<IApplicationRepository> mockRepo = new Mock<IApplicationRepository>();
            mockRepo.Setup(x => x.GetAsync(1)).ReturnsAsync(value: application);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMapProfile());
            });
            var mapper = mockMapper.CreateMapper();

            ApplicationService applicationService = new ApplicationService(mockRepo.Object, mapper);
            // Act
            var result = applicationService.CreateAsync(applicationCommand);
            var addedApplication = applicationService.GetAsync(1);
            // Assert
            Assert.Equal(addedApplication.Result, application);
        }

        [Fact]
        public async Task DeleteApplication_ShouldReturnAddedApplication()
        {
            //Arrange 
            var applications = GetApplications();
            AddApplicationCommand applicationCommand = GetApplicationCommand();
            Application application = GetApplication();
            Mock<IApplicationRepository> mockRepo = new Mock<IApplicationRepository>();
            mockRepo.Setup(x => x.DeleteAsync(1)).ReturnsAsync(value: application);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMapProfile());
            });
            var mapper = mockMapper.CreateMapper();

            ApplicationService applicationService = new ApplicationService(mockRepo.Object, mapper);
            // Act
            await applicationService.CreateAsync(applicationCommand);
            var result = applicationService.DeleteAsync(1);
            //var addedApplication = applicationService.GetAsync(1);
            // Assert
            Assert.DoesNotContain(result.Result, applications);
        }
        private List<Application> GetApplications()
        {
            var pet = new Pet()
            {
                Id = 1,
                Name = "Moysha",
                Breed = "shepherd",
                Weight = 11,
                Adress = "Syvorova 6-a",
                UserId = 1
            };
            var petsitter = new Petsitter()
            {
                Id = 1,
                Name = "Andrey",
                Description = "Softer with my doggy",
                Picture = "D://11/1.jpg"
            };
            var service = new PetsittingJob()
            {
                Id = 1,
                Description = "More shampoo",
                Price = 999
            };
            List<Application> applications = new List<Application>()
            {

    new Application()
    {
        Id = 1,
        PetId = 1,
        Pet=pet,
        PetsitterId = 1,
        Petsitter =petsitter,
        ServiceId = 1,
        Service = service
    },
    new Application()
    {
        Id = 1,
        PetId = 1,
        Pet=pet,
        PetsitterId = 1,
        Petsitter =petsitter,
        ServiceId = 1,
        Service = service
    },
    new Application()
    {
        Id = 1,
        PetId = 1,
        Pet=pet,
        PetsitterId = 1,
        Petsitter =petsitter,
        ServiceId = 1,
        Service = service
    }

    };
            return applications;
        }
        private Application GetApplication()
        {
            var pet = new Pet()
            {
                Id = 2,
                Name = "Boryh",
                Breed = "shepherd",
                Weight = 12,
                Adress = "frunze 33",
                UserId = 2
            };
            var petsitter = new Petsitter()
            {
                Id = 2,
                Name = "Nikita",
                Description = "",
                Picture = "D://11/2.jpg"
            };
            var service = new PetsittingJob()
            {
                Id = 2,
                Description = "Intensive wash",
                Price = 999
            };


            var application = new Application()
            {
                Id = 1,
                PetId = 1,
                Pet = pet,
                PetsitterId = 1,
                Petsitter = petsitter,
                ServiceId = 1,
                Service = service
            };
            return application;
        }
        private AddApplicationCommand GetApplicationCommand()
        {
            var pet = new Pet()
            {
                Id = 2,
                Name = "Boryh",
                Breed = "shepherd",
                Weight = 12,
                Adress = "frunze 33",
                UserId = 2
            };
            var petsitter = new Petsitter()
            {
                Id = 2,
                Name = "Nikita",
                Description = "",
                Picture = "D://11/2.jpg"
            };
            var service = new PetsittingJob()
            {
                Id = 2,
                Description = "Intensive wash",
                Price = 999
            };


            var application = new AddApplicationCommand()
            {
                Id = 1,
                PetId = 1,
                Pet = pet,
                PetsitterId = 1,
                Petsitter = petsitter,
                ServiceId = 1,
                Service = service
            };
            return application;
        }


    }

}
