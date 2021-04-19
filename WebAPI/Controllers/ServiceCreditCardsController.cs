using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCreditCardsController : Controller
    {
        private IServiceCreditCardService _serviceCreditCardService;

        public ServiceCreditCardsController(IServiceCreditCardService serviceCreditCardService)
        {
            _serviceCreditCardService = serviceCreditCardService;
        }
        [HttpPost("buy")]
        public IActionResult Buy(BuyDetailDto buyDto)
        {
            var result = _serviceCreditCardService.Buy(buyDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("refund")]
        public IActionResult Refund(BuyDetailDto buyDto)
        {
            var result = _serviceCreditCardService.Refund(buyDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
