﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WoflDogWebCode.Models;
using WoflDogWebCode.Services;

namespace WoflDogWebCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuService _menuService;

        private readonly IResourceNetworkInfoService? _resourceNetworkInfoService;

        private readonly IResourceClassService? _resourceClassService;

        public HomeController(ILogger<HomeController> logger, IMenuService menuService, IResourceNetworkInfoService resourceNetworkInfoService, IResourceClassService resourceClassService)
        {
            _logger = logger;
            _menuService = menuService;
            _resourceNetworkInfoService = resourceNetworkInfoService;
            _resourceClassService = resourceClassService;
        }

        // 定义 Index Action，用于显示主页
        public IActionResult Index()
        {
            try
            {
                var menus = _menuService.GetMenus();
                ViewBag.Menus = menus;
                var resourceClasses = _resourceClassService.GetResourceClasses();
                ViewBag.ResourceClasses = resourceClasses;
                return View("Index");
            }
            catch (System.Exception)
            {
                // 如果发生异常，则返回 Error404 视图，并传递错误信息
                return View("Error404", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        // 定义 HomePage Action，用于显示 HomePage
        public IActionResult HomePage()
        {
            try
            {
                var menus = _menuService.GetMenus();
                ViewBag.Menus = menus;
                var resourceClasses = _resourceClassService.GetResourceClasses();
                ViewBag.ResourceClasses = resourceClasses;
                return View("HomePage");
            }
            catch (System.Exception)
            {
                // 如果发生异常，则返回 Error404 视图，并传递错误信息
                return View("Error404", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        // 定义 Error404 Action，用于显示 404 错误页面
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error404()
        {
            // 返回 Error404 视图，并传递错误信息
            return View("Error404", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
