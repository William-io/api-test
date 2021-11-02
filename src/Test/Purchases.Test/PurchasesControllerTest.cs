using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Purchases.API.Controllers;
using Purchases.API.Models;
using Purchases.API.Services;
using Xunit;

namespace Purchases.Test
{
    public class PurchasesControllerTest
    {
        PurchasesController _controller;
        IPurchaseService _service;

        public PurchasesControllerTest()
        {
            _service = new PurchaseServiceFake();
            _controller = new PurchasesController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.Get();
            //Assert
            //Se o método retorna o OkObjectResult, que representa o código de resposta HTTP 200;
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            //Act
            var okResult = _controller.Get().Result as OkObjectResult;
            //Assert
            //Se o objeto retornado contém nossa lista CompraItem e todos os nossos itens;
            var items = Assert.IsType<List<PurchaseItem>>(okResult.Value);
            //Determina o número de itens que precisa ser retornado para passar no teste.
            //Sendo esperado 2 item.
            Assert.Equal(2, items.Count); 
        }


    }

}