using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebApplication1.Tests.PageObjects;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Tests.SeleniumTests
{
	[TestClass]
	public class AccountTests
	{
		UserDAL dal = new UserDAL(@"Data Source=localhost\sqlexpress;Initial Catalog=Slime;Integrated Security=True");
        TournamentDAL tournyDal = new TournamentDAL(@"Data Source=localhost\sqlexpress;Initial Catalog=Slime;Integrated Security=True");
		private static IWebDriver driver;


		[ClassInitialize]
		public static void SetUp(TestContext context)
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("http://localhost:55393/");
		}

		[ClassCleanup]
		public static void CleanupDriver()
		{
			driver.Close();
			driver.Quit();
		}

		[TestMethod]
		public void Register_GoToHome()
		{
			Register entryPage = new Register(driver);
			entryPage.Navigate();

			RegisterResult result = entryPage.FillOutForm("jellymo@jellymo.com", "Jellymo2@", "Jellymo2@");

			Assert.AreEqual("Hello jellymo@jellymo.com!", result.Success.Text);
		}

		[TestMethod]
		public void Login_GoToHome()
		{
			Login entryPage = new Login(driver);
			entryPage.Navigate();

			LoginResult result = entryPage.FillOutForm("jellymo@jellymo.com", "Jellymo2@");

			Assert.AreEqual("Hello jellymo@jellymo.com!", result.Success.Text);
		}

		[TestMethod]
		public void CreateTournament_GoToIndex()
		{
			CreateTournament entryPage = new CreateTournament(driver);
			entryPage.Navigate();
			string start = "08092017";
			string end = "08102017";

			CreateTournamentResult result = entryPage.FillOutForm(start, end, "Test", "Test Location");

			Assert.AreEqual("Test", result.Success.Text);
		}

		[TestMethod]
		public void CreateTeam_GoToIndex()
		{
			CreateTeam entryPage = new CreateTeam(driver);
			entryPage.Navigate();

			CreateTeamResult result = entryPage.FillOutForm("Test");

			Assert.AreEqual("Test", result.Success.Text);

			
			dal.DeleteUser("jellymo@jellymo.com");
			tournyDal.DeleteTournament("Test");
			tournyDal.DeleteTeam("Test");
		}
	}
}
