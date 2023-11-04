using Leb2.Drivers;
using Leb2.PageObjects;
using NUnit.Framework;

namespace Leb2.StepDefinitions;

[Binding]
public sealed class CustomerSearchStepDefinitions
{
    private readonly CustomerSearchPageObjects _customerSearchPageObjects;
    private readonly BankManagerLoginPageObject _bankManagerLoginPageObject;
    private readonly ManagerPageObject _bankManagerPageObject;
    private readonly ScenarioContext _scenarioContext;

    public CustomerSearchStepDefinitions(BrowserDriver browserDriver, ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _bankManagerLoginPageObject = new BankManagerLoginPageObject(browserDriver.Current);
        _bankManagerPageObject = new ManagerPageObject(browserDriver.Current);
        _customerSearchPageObjects = new CustomerSearchPageObjects(browserDriver.Current);
    }

    [BeforeScenario]
    public void Navigation()
    {
        _bankManagerLoginPageObject.NavigateToBankManagerLogin();
        _bankManagerPageObject.NavigateToCustomerSearch();
    }

    [Given("name/surname/account number - (.*)")]
    public void GivenNameOrSurnameOrAccountNumber(string data)
    {
        _customerSearchPageObjects.EnterCustomerToSearch(data);
    }

    [Then("you should have (.*), (.*) and (.*)")]
    public void ThenTheResultShouldBe(string name, string surname, string accountNumber)
    {
        var actualResult = _customerSearchPageObjects.WaitForResult(false);

        var expectedResult = new List<string>
        {
            name,
            surname,
            accountNumber
        };

        Assert.AreEqual(expectedResult, actualResult.ToList());
    }

    [Then("should have account numbers (.*) and (.*)")]
    public void ThenShouldHaveCorrectAccountNumbers(string accountNumber1, string accountNumber2)
    {
        var actualResult = _customerSearchPageObjects.WaitForResult(true);

        var expectedResult = new List<string>
        {
            accountNumber1,
            accountNumber2
        };

        Assert.AreEqual(expectedResult, actualResult.ToList());
    }


    [Then("should have empty")]
    public void ThenShouldHaveEmpty()
    {
        var actualResult = _customerSearchPageObjects.ShouldReturnEmpty();

        Assert.AreEqual(false, actualResult);
    }
}