using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebApplication1.Tests.PageObjects
{
	public class Register : BasePage
	{
		public Register(IWebDriver driver)
			: base(driver, "/Account/Register")
		{
			PageFactory.InitElements(driver, this);
		}


		[FindsBy(How = How.Name, Using = "Email")]
		public IWebElement Email { get; set; }

		[FindsBy(How = How.Name, Using = "Password")]
		public IWebElement Password { get; set; }

		[FindsBy(How = How.Name, Using = "ConfirmPassword")]
		public IWebElement ConfirmPassword { get; set; }

		[FindsBy(How = How.ClassName, Using = "btn")]
		public IWebElement Submit { get; set; }


		public RegisterResult FillOutForm(string email,  string password, string confirmPassword)
		{
			// Set the Principal
			Email.SendKeys(email.ToString());

			Password.SendKeys(password.ToString());

			ConfirmPassword.SendKeys(confirmPassword.ToString());

			Submit.Click();

			return new RegisterResult(driver);
		}
	}
}
