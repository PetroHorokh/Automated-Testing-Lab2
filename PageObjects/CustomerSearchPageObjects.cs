using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace Leb2.PageObjects;

public class CustomerSearchPageObjects
{
    private readonly IWebDriver _webDriver;

    private readonly string _searchFieldXPath = "/html/body/div/div/div[2]/div/div[2]/div/form/div/div/input";
    private readonly string _tableFieldXPath = "/html/body/div/div/div[2]/div/div[2]/div/div/table/tbody";

    public CustomerSearchPageObjects(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    private IWebElement SearchField => 
        _webDriver.FindElement(By.XPath(_searchFieldXPath));
    private IWebElement TableField =>
        _webDriver.FindElement(By.XPath(_tableFieldXPath));

    public void EnterCustomerToSearch(string name)
    {
        SearchField.Clear();
        SearchField.SendKeys(name);
    }

    public IEnumerable<string> WaitForResult(bool onlyAccountNumbers)
    {
        var rows = TableChildren();
        var result = new List<string>();

        foreach (var element in rows)
        {
            result.AddRange(TableRowContent(element, onlyAccountNumbers));
        }

        return result;
    }

    public bool ShouldReturnEmpty() => TableChildren().Any();

    private string ElementResult(IWebElement element) => element.Text;

    private IEnumerable<IWebElement> TableChildren() => TableField.FindElements(By.TagName("tr"));

    private IEnumerable<string> TableRowContent(IWebElement element, bool onlyAccountNumbers) =>
        onlyAccountNumbers ? new List<string>()
        {
            element.FindElement(By.XPath("./td[4]")).Text,
        } : new List<string>()
        {
            element.FindElement(By.XPath("./td[1]")).Text,
            element.FindElement(By.XPath("./td[2]")).Text,
            element.FindElement(By.XPath("./td[4]")).Text,
        };
}