using AutoMapper;
using FridgeBE.Api.Controllers;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Mapping;
using FridgeBE.Core.Models.ResponseModels;
using FridgeBE.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace FridgeBE.Tests.Controllers
{
    public class IngredientControllerTest
    {
        [Fact]
        public async void GetByIdTest()
        {
            var mapConfig = new MapperConfiguration(config => config.AddProfile<AutoMapperProfile>());
            var controller = new IngredientController(new IngredientService(new Mock<IUnitOfWork>().Object, mapConfig.CreateMapper(), new Mock<IConfiguration>().Object));

            var id = Guid.NewGuid();
            ActionResult<IngredientModel> model = await controller.GetById(id);

            
        }
    }
}