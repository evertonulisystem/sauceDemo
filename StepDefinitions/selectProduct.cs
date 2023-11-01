using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MyNamespace
{
    [Binding]
    public class StepDefinitions
    {
       // private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver; // objeto do Selenium

        public StepDefinitions(ScenarioContext scenarioContext)
        {
           
        }

        [BeforeScenario]
        public void SetUp()
        {
            // Instanciando o ChromeDriver através do WebDriverManager
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(); // instanciou o Selenium como Chrome
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDown()
        {
            //driver.Quit(); // encerrou o Selenium
        }


        [Given(@"que acesso a página inicial do site")]
        public void DadoQueAcessoAPaginaInicialDoSite()
        {
           driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"preencho o usuário como ""(.*)""")]
        public void QuandoPreenchoOUsuarioComo(string username)
        {
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        }

        [When(@"a senha ""(.*)"" e clico no botao Login")]
        public void QuandoASenhaEClicoNoBotaoLogin(string password)
        {
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");        
        driver.FindElement(By.Id("login-button")).Click(); 


        }

        [When(@"adiciono o produto ""(.*)"" ao carrinho")]
        public void QuandoAdicionoOProdutoAoCarrinho(string product)
        {
          String productSelector = "add-to-cart-" + product.ToLower().Replace(" ","-");
          Console.WriteLine($"Seletor de Produto = {productSelector}");

        }

        [When(@"clico no icone do carrinho de compras")]
        public void QuandoClicoNoIconeDoCarrinhoDeCompras()
        {
         //*[@id="header_container"]/div[2]/span
        }

        [Then(@"exibe ""(.*)"" no titulo da secao")]
        public void EntaoExibeNoTituloDaSecao(string title)
        {
           //Thread.Sleep(4000); funciona mas o ideal é o de baixo
           //Espera explicita
           new WebDriverWait (driver, TimeSpan.FromMilliseconds(3000)).Until(Expec)

           Assert.That(driver.FindElement(By.CssSelector("span.title")).Text, Is.EqualTo(title)); 
           //Assert.That(driver.FindElement(By.XPath("//*[@id="header_container"]/div[2]/span")).Text, Is.EqualTo(title));
           
        }           

        [Then(@"exibe a pagina do carrinho com a quantidade ""(.*)""")]
        public void EntaoExibeAPaginaDoCarrinhoComAQuantidade(string p0)
        {
           
        }

        [Then(@"nome do produto ""(.*)""")]
        public void EntaoNomeDoProduto(string p0)
        {
           
        }

        [Then(@"o preco como ""(.*)""")]
        public void EntaoOPrecoComo(string p0)
        {
           
        }
    }
}