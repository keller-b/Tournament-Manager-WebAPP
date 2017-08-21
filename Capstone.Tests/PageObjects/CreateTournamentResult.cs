using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebApplication1.Tests.PageObjects
{
	public class CreateTournamentResult : BasePage
	{
			public CreateTournamentResult(IWebDriver driver)
				: base(driver, "/Tournaments/Index")
			{
				PageFactory.InitElements(driver, this);
			}

			[FindsBy(How = How.Name, Using = "Name")]
			public IWebElement Success { get; set; }
		}
	}
