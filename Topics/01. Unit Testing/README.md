<!-- section start -->
<!-- attr: { hasScriptWrapper:true, class:"slide-title" } -->
# Unit Testing
## Building Rock-Solid Software

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic00.png" style="top:22.26%; left:7.84%; width:16.08%; z-index:-1" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic02.png" style="top:52.89%; left:81.40%; width:21.68%; z-index:-1; border-radius: 15px" /> -->

<div class="signature">
   <p class="signature-course">High-Quality Code - Unit Testing</p>
   <p class="signature-initiative">Telerik Software Academy</p>
   <a href="https://telerikacademy.com" class="signature-link">https://telerikacademy.com</a>
</div>

<!-- section start -->
<!-- attr: { hasScriptWrapper:true } -->
# Table of Contents
- [What is Unit Testing?](#definition)
- [Code and Test vs. Test Driven Development](#code-and-test-vs-tdd)
- [Unit testing Frameworks](#frameworks)
  - [Visual Studio Team Test](#vstt)
  - [Nunit](#n-unit)
  - [Gallio](#gallio-platform)
- [Unit Testing Best Practices](#best-practices)

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic04.png" style="top:32.18%; left:70.25%; width:33.20%; z-index:-1; border-radius: 15px" /> -->

<!-- section start -->
<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# What is Unit Testing?

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic06.png" style="top:45%; left:30%; width:40%; z-index:-1; border-radius: 15px" /> -->

<!-- attr: { id: 'definition', hasScriptWrapper:true, showInPresentation: true } -->
<!-- # <a id="definition"></a>Unit Test - Definition -->
A **unit test** is a piece of code written by a developer that exercises a very small, specific area of functionality of the code being tested.

**"Program testing can be used to show the presence of bugs, but never to show their absence!"**

Edsger Dijkstra, [1972]

<!-- attr: { id: 'code-and-test-vs-tdd', hasScriptWrapper:true } -->
# <a id="code-and-test-vs-tdd"></a>Manual Testing
- You have already done unit testing
  - Manually, by hand
- **Manual tests** are less efficient
  - Not structured
  - Not repeatable
  - Not on all your code
  - Not easy to do as it should be

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic07.png" style="top:38.49%; left:75.79%; width:27.91%; z-index:-1" /> -->

<!-- attr: { hasScriptWrapper:true } -->
# Unit Test - _Example_

```cs
int Sum(int[] array)
{
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
        sum += array[i];
    return sum;
}

void TestSum()
{
 if (Sum(new int[]{ 1, 2 }) != 3)
    throw new TestFailedException("1+2 != 3");
 if (Sum(new int[]{ -2 }) != -2)
    throw new TestFailedException("-2 != -2");
 if (Sum(new int[]{ }) != 0)
    throw new TestFailedException("0 != 0");
}
```

<!-- attr: { hasScriptWrapper:true } -->
# Unit Testing - Some Facts
- Tests are specific **pieces of code**
- In most cases unit tests are **written by developers**, not by QA engineers
- Unit tests are released into the code repository (TFS / SVN / Git) along with the code they test
- Unit testing **framework** is needed
  - Visual Studio Team Test (VSTT)
  - NUnit, MbUnit, Gallio, etc.

<!-- attr: { hasScriptWrapper:true } -->
# Unit Testing - More Facts
- All classes should be tested
- All methods should be tested
  - Trivial code may be omitted
    - E.g. property getters and setters
  - Private methods can be omitted
    - Some gurus recommend to never test private methods &rarr; this can be debatable
- Ideally **all unit tests should pass** before check-in into the source control repository

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic08.png" style="top:13.22%; left:83.27%; width:20.35%; z-index:-1" /> -->

<!-- attr: { hasScriptWrapper:true } -->
# Why Unit Tests?
- Dramatically **decreased number of defects** in the code
- **Improved design**
- Good **documentation**
- **Reduced cost** of change
- **Easier, more efficient refactoring**
- Decreased **defect-injection rate** due to refactoring / changes

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic09.png" style="top:22.92%; left:87.95%; width:15.44%; z-index:-1" /> -->

<!-- section start -->
<!-- attr: { hasScriptWrapper:true, class:"slide-section", showInPresentation: true } -->
<!-- # Unit Testing Frameworks -->

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic10.png" style="top:50%; left:59%; width:31.5%; z-index:-1; border-radius: 15px" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic11.png" style="top:50%; left:9%; width:45.88%; z-index:-1; border-radius: 15px" /> -->

<!-- attr: { id:'frameworks', hasScriptWrapper:true } -->
# <a id="frameworks"></a>Unit Testing Frameworks
- **JUnit**
  - The first popular unit testing framework
  - Based on Java, written by Kent Beck & Co.
- Similar frameworks have been developed for a broad range of computer languages
  - **NUnit** - for C# and all .NET languages
  - cppUnit, jsUnit, PhpUnit, PerlUnit, ...
- **Visual Studio Team Test** (VSTT)
  - Developed by Microsoft, integrated in VS

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic12.png" style="top:11.75%; left:93.57%; width:12.76%; z-index:-1" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic13.png" style="top:59.06%; left:93.32%; width:12.99%; z-index:-1" /> -->

<!-- section start -->
<!-- attr: { hasScriptWrapper:true, class:"slide-section", showInPresentation: true } -->
<!-- # Visual Studio Team Test - Features -->

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic16.png" style="top:60%; left:35%; width:30%; z-index:-1; border-radius: 15px" /> -->

<!-- attr: { id:'vstt', hasScriptWrapper:true } -->
# <a id="vstt"></a>Visual Studio Team Test - Features
- **Team Test (VSTT)** is very well integrated with Visual Studio
  - Create test projects and unit tests
  - Execute unit tests
  - View execution results
  - View code coverage
- Located in the assembly **Microsoft.VisualStudio.** **QualityTools.UnitTestFramework.dll**

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic17.png" style="top:40%; left:75%; width:35%; z-index:-1; border-radius: 15px" /> -->

<!-- attr: { hasScriptWrapper:true, style: 'font-size: 0.95em' } -->
# Visual Studio Team Test -  Attributes
- Test code is annotated using custom attributes:
  - `[TestClass]` - denotes a class holding unit tests
  - `[TestMethod]` - denotes a unit test method
  - `[ExpectedException]` - test causes an exception
  - `[Timeout]` - sets a timeout for test execution
  - `[Ignore]` - temporary ignored test case
  - `[ClassInitialize]`, `[ClassCleanup]` - setup / cleanup logic for the testing class
  - `[TestInitialize]`, `[TestCleanup]` - setup / cleanup logic for each test case

<!-- attr: { hasScriptWrapper:true, style: 'font-size: 0.9em' } -->
# Assertions
- **Predicate** is a `true` / `false` statement
- **Assertion** is a predicate placed in a program code (check for some condition)
  - Developers expect the predicate is always true at that place
  - If an assertion fails, the method call does not return and an error is reported
  - _Example_ of VSTT assertion:

```cs
Assert.AreEqual(expectedValue, actualValue, "Error message.");
```

<!-- attr: { hasScriptWrapper:true, style: 'font-size: 0.9em'  } -->
# VSTT - Assertions
- Assertions check a condition
  - Throw exception if the condition is not satisfied
- Comparing values for equality

```cs
Assert.AreEqual(expected_value, actual_value [,message])
```

- Comparing objects (by reference)

```cs
Assert.AreSame(expected_object, actual_object [,message])
```

- Checking for `null` value

```cs
Assert.IsNull(object [,message])
Assert.IsNotNull(object [,message])
```

<!-- attr: { hasScriptWrapper:true, style: 'font-size: 0.9em', showInPresentation: true } -->
<!-- # VSTT - Assertions -->

- Checking conditions

```cs
Assert.IsTrue(condition)
Assert.IsFalse(condition)
```
- Forced test fail

```cs
Assert.Fail(message)
```

<!-- attr: { hasScriptWrapper:true } -->
# The 3A Pattern
- **Arrange** all necessary preconditions and inputs
- **Act** on the object or method under test
- **Assert** that the expected results have occurred

```cs
[TestMethod]
public void TestDeposit()
{
  BankAccount account = new BankAccount();
  account.Deposit(125.0);
  account.Deposit(25.0);
  Assert.AreEqual(150.0, account.Balance,
    "Balance is wrong.");
}
```

<!-- attr: { hasScriptWrapper:true } -->
# Code Coverage
- **Code coverage**
  - Shows what percent of the code we’ve covered
  - High code coverage means less untested code
  - We may have pointless unit tests that are calculated in the code coverage
- **70-80%** coverage is excellent

<img class="slide-image" showInPresentation="true" src="imgs/pic19.png" style="top:65%; left:9.36%; width:83.86%; z-index:-1; border-radius: 5px" />

<!-- attr: { hasScriptWrapper:true, style: 'font-size: 0.95em' } -->
# VSTT - _Example_

```cs
public class Account
{
  private decimal balance;

  public void Deposit(decimal amount)
  {
    this.balance += amount;
  }

  public void Withdraw(decimal amount)
  {
    this.balance -= amount;
  }

  public void TransferFunds(
    Account destination, decimal amount) { … }

  public decimal Balance { … }
}
```

<!-- attr: { hasScriptWrapper:true, showInPresentation: true } -->
<!-- # VSTT - _Example_ -->

```cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class AccountTest
{
  [TestMethod]
  public void TransferFunds()
  {
    Account source = new Account();
    source.Deposit(200.00M);
    Account dest = new Account();
    dest.Deposit(150.00M);
    source.TransferFunds(dest, 100.00M);
    Assert.AreEqual(250.00M, dest.Balance);
    Assert.AreEqual(100.00M, source.Balance);
  }
}
```

<!-- attr: { hasScriptWrapper:true, showInPresentation: true } -->
<!-- # VSTT - Screenshot -->

<img class="slide-image" showInPresentation="true" src="imgs/pic20.png" style="top:13%; left:5%; width:95%; z-index:-1" />

<!-- attr: { class:"slide-section demo", hasScriptWrapper:true, showInPresentation: true } -->
<!-- # Visual Studio Team Test
## [Live Demo]() -->

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic21.png" style="top:55%; left:30%; width:40%; z-index:-1" /> -->

<!-- section start -->
<!-- attr: { hasScriptWrapper:true, class:"slide-section" } -->
# NUnit

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic25.png" style="top:45%; left:25%; width:50%; z-index:-1" /> -->

<!-- attr: { id:'n-unit', hasScriptWrapper:true, showInPresentation: true } -->
<!-- # <a id="n-unit"></a>NUnit - Features -->
- Test code is annotated using **custom attributes**
- Test code contains **assertions**
- Tests organized as **multiple assemblies**
- NUnit provides:
  - Creating and running tests as NUnit Test Projects
  - Visual Studio support



<!-- attr: { hasScriptWrapper:true, showInPresentation: true } -->
<!-- # NUnit - Features -->
- Two execution **interfaces**
    - GUI - **nunit-gui.exe**
    - Console - **nunit-console.exe**

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic26.png" style="top:38%; left:56%; width:44.96%; z-index:-1" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic27.png" style="top:38%; left:5%; width:46.45%; z-index:-1" /> -->

<!-- attr: { hasScriptWrapper:true } -->
# NUnit - _Example_: Test

```cs
using NUnit.Framework;

[TestFixture]
public class AccountTest
{
  [Test]
  public void TransferFunds()
  {
    Account source = new Account();
    source.Deposit(200.00F);
    Account dest = new Account();
    dest.Deposit(150.00F);
    source.TransferFunds(dest, 100.00F);
    Assert.AreEqual(250.00F, dest.Balance);
    Assert.AreEqual(100.00F, source.Balance);
  }
}
```

<!-- attr: { hasScriptWrapper:true, showInPresentation: true } -->
<!-- # NUnit - Screenshot -->

<img class="slide-image" showInPresentation="true" src="imgs/pic28.png" style="top:13.22%; left:10.14%; width:86.68%; z-index:-1" />

<!-- section start -->
<!-- attr: { hasScriptWrapper:true, class:"slide-section", showInPresentation: true } -->
<!-- # Gallio -->

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic29.png" style="top:42%; left:5%; width:45%; z-index:-1" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic30.png" style="top:58.74%; left:74.49%; width:28.27%; z-index:-1" /> -->

<!-- attr: { id:'gallio-platform', hasScriptWrapper:true } -->
# <a id="gallio-platform"></a>The Gallio Automation Platform
- The Gallio Automation Platform
  - An open, extensible, and neutral system for using many .NET test frameworks
  - Gallio can run tests from MbUnit, MSTest, NUnit, xUnit.Net, csUnit, and RSpec
  - Provides a common object model, runtime services and tools (such as test runners)
    - May be leveraged by any number of test frameworks
  - [https://github.com/Gallio](https://github.com/Gallio) <!-- www.gallio.org -->

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic31.png" style="top:75%; left:70%; width:28.81%; z-index:-1" /> -->

<!-- attr: { hasScriptWrapper:true, showInPresentation: true } -->
<!-- # Interfaces -->
- Gallio includes its own interfaces:
  - **Echo**
    - Command-line runner
  - **Icarus**
    - Windows GUI

<img class="slide-image" showInPresentation="true" src="imgs/pic32.png" style="top:34.14%; left:48.65%; width:54.66%; z-index:-1" />

<!-- section start -->
<!-- attr: { hasScriptWrapper:true, class:"slide-section", showInPresentation: true } -->
<!-- # Best Practices in Unit Testing -->

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic33.png" style="top:55%; left:30%; width:40%; z-index:-1; border-radius: 15px" /> -->

<!-- attr: { id:'best-practices', hasScriptWrapper:true } -->
# <a id="best-practices"></a>Naming Standards for Unit Tests
- The **test name** should express a specific requirement that is tested
  - Usually prefixed with `[Test]`
  - E.g. `TestAccountDepositNegativeSum()`
- The test name should include
  - Expected input or state
  - Expected result output or state
  - Name of the tested method or class

<!-- attr: { hasScriptWrapper:true } -->
# Naming Standards for Unit Tests - _Example_
- Given the method: 
  ```cs
    public int Sum(params int[] values)
  
  ```
with requirement to ignore numbers greater than 100 in the summing process
- The test name could be: `TestSum_NumberIgnoredIfGreaterThan100`

<!-- attr: { hasScriptWrapper:true, style: 'font-size: 0.85em' } -->
# When Should a Test be Changed or Removed?
- Generally, a passing test should **never** be removed
  - These tests make sure that code changes don't break working code
- A passing test should only be changed to make it more readable
- When failing tests don't pass, it usually means there are conflicting requirements

```cs
[ExpectedException(typeof), "Negatives not allowed")]
void TestSum_FirstNegativeNumberThrowsException()
{
  Sum(-1, 1, 2);
}
```

<!-- attr: { hasScriptWrapper:true, style: 'font-size: 0.9em' } -->
# When Should a Test be Changed or Removed?
- New features allow negative numbers
- New developer writes the following test:
- Earlier test fails due to a requirement change
- Two course of actions:
  1. Delete the failing test after verifying it is invalid
  1. Change the old test:
    - Either testing the new requirement
    - Or test the older requirement under new settings

<!-- attr: { hasScriptWrapper:true, style: 'font-size: 0.85em' } -->
# Tests Should Reflect Required Reality
- Consider the following method:

```cs
int Sum(int a, int b) -> return sum of a and b
```

- What’s wrong with the following test?

```cs
public void Sum_AddsOneAndTwo()
{
    int result = Sum(1, 2);
    Assert.AreEqual(4, result, "Bad sum");
}
```
- A failing test should prove that there is something wrong with the production code, not with the unit test code

<!-- attr: { hasScriptWrapper:true } -->
# Assert Messages
- Assert message in a test could be one of the most important things
  - Tells us what we expected to happen but didn’t, and what happened instead
  - Good assert message helps us track bugs and understand unit tests more easily
- **_Example_**:
  - <span style="color: lightblue">_"Withdrawal failed: accounts are not supposed to have negative balance."_</span>

<!-- attr: { hasScriptWrapper:true, showInPresentation: true } -->
<!-- # Assert Messages -->
- Express what **should** have happened and what **did not** happen
  - <span style="color: lightblue">"<b>Verify()</b> did not throw any exception"</span>
  - <span style="color: lightblue">"<b>Connect()</b> did not open the connection before returning it"</span>
- Do not:
  - Provide empty or meaningless messages
  - Provide messages that repeat the name of the test case

<!-- attr: { hasScriptWrapper:true } -->
# Avoid Multiple Asserts in a Single Test

```cs
void TestSum_AnyParamBiggerThan100IsNotSummed()
{
	Assert.AreEqual(3, Sum(1001, 1, 2));
	Assert.AreEqual(3, Sum(1, 1001, 2));
	Assert.AreEqual(3, Sum(1, 2, 1001));
}
```

- **Avoid multiple asserts in a single test case**
  - If the first assert fails, the test execution stops for this test case
  - Affect future coders to add assertions to test rather than introducing a new one

<!-- attr: { hasScriptWrapper:true, style: 'font-size: 0.9em'  } -->
# Unit Testing - The Challenge
- The concept of unit testing has been around the developer community for many years
- New methodologies in particular Scrum and XP, have turned unit testing into a cardinal foundation of software development
- Writing good & effective unit tests is hard!
  - This is where supporting integrated tools and suggested guidelines enter the picture
- The ultimate goal is tools that generate unit tests automatically

<!-- section start -->
<!-- attr: { hasScriptWrapper:true, class:"slide-section", showInPresentation: true } -->
<!-- # Unit Testing
## Questions? -->

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# Free Trainings @ Telerik Academy
- C# Programming @ Telerik Academy
    - [Unit Testing Course](http://academy.telerik.com/student-courses/programming/high-quality-code/about)
  - Telerik Software Academy
    - [telerikacademy.com](https://telerikacademy.com)
  - Telerik Academy @ Facebook
    - [facebook.com/TelerikAcademy](facebook.com/TelerikAcademy)
  - Telerik Software Academy Forums
    - [forums.academy.telerik.com](forums.academy.telerik.com)

<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic35.png" style="top:60.37%; left:92.39%; width:13.45%; z-index:-1" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic36.png" style="top:30.85%; left:68.14%; width:36.30%; z-index:-1" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic37.png" style="top:46.32%; left:95.14%; width:10.85%; z-index:-1" /> -->
