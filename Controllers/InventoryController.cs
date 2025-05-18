using BidUser.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BidUser.Controllers
{
    
 
  public class InventoryController : Controller
        {
            private readonly IInventoryService _inventoryService;

            public InventoryController(IInventoryService inventoryService)
            {
                _inventoryService = inventoryService;
            }

            public IActionResult Index()
            {
                var inventoryList = _inventoryService.GetAllInventoryDTOS();
                return View(inventoryList);
            }
        }
    }

