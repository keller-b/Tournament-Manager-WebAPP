using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebApplication1.Tests.PageObjects
{
	public class LoginResult : BasePage
	{
		public LoginResult(IWebDriver driver)
			: base(driver, "/Home")
		{
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Name, Using = "Success")]
		public IWebElement Success { get; set; }
	}
}
