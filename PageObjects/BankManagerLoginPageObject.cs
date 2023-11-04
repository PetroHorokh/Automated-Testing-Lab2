namespace Leb2.PageObjects;

public class BankManagerLoginPageObject
{
    private readonly IWebDriver _webDriver;

    private readonly string _bankManagerLoginButton = "/html/body/div/div/div[2]/div/div[1]/div[2]/button";

    public BankManagerLoginPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public void NavigateToBankManagerLogin()
    {
        _webDriver.FindElement(By.XPath(_bankManagerLoginButton)).Click();
        Thread.Sleep(1000);
    }
}