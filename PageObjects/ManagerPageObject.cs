namespace Leb2.PageObjects;

public class ManagerPageObject
{
    private readonly IWebDriver _webDriver;

    private readonly string _customersButton = "/html/body/div/div/div[2]/div/div[1]/button[3]";

    public ManagerPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public void NavigateToCustomerSearch()
    {
        _webDriver.FindElement(By.XPath(_customersButton)).Click();
        Thread.Sleep(1000);
    }
}