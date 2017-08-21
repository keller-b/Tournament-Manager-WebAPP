using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebApplication1.Tests.PageObjects
{
	public class CreateTeam : BasePage
	{
		public CreateTeam(IWebDriver driver)
			: base(driver, "/Teams/Create/3")
		{
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Name, Using = "Name")]
		public IWebElement Name { get; set; }

		[FindsBy(How = How.ClassName, Using = "btn")]
		public IWebElement Submit { get; set; }

		public CreateTeamResult FillOutForm(string name)
		{
			// Set the Principal
			Name.SendKeys(name);

			Submit.Click();

			return new CreateTeamResult(driver);
		}
	}
}

