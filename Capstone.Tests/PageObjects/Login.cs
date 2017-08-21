using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebApplication1.Tests.PageObjects
{
	public class Login : BasePage
	{
		public Login(IWebDriver driver)
			: base(driver, "/Account/Login")
		{
			PageFactory.InitElements(driver, this);
		}


		[FindsBy(How = How.Name, Using = "Email")]
		public IWebElement Email { get; set; }

		[FindsBy(How = How.Name, Using = "Password")]
		public IWebElement Password { get; set; }

		[FindsBy(How = How.ClassName, Using = "btn")]
		public IWebElement Submit { get; set; }

		public LoginResult FillOutForm(string email, string password)
		{
			// Set the Principal
			Email.SendKeys(email.ToString());

			Password.SendKeys(password.ToString());

			Submit.Click();

			return new LoginResult(driver);
		}
	}
}
