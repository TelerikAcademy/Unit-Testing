<!-- section start -->
<!-- attr: { id:'', class:'slide-title', showInPresentation:true, hasScriptWrapper:true } -->
# Isolation techniques
## Mocking frameworks
<article class="signature">
	<p class="signature-course">Unit Testing</p>
	<p class="signature-initiative">Telerik Software Academy</p>
	<a href="https://academy.telerik.com " class="signature-link">https://academy.telerik.com </a>
</article>

<!-- section start -->
<!-- attr: { id:'', showInPresentation:true, hasScriptWrapper:true } -->
# Table of Contents
- [Testable Code](#testable)
- [Fakes, Mocks, Stubs](#fakes)
- [Mocking](#isollation)

<!-- <img class="slide-image" showInPresentation="true" src="imgs\pic02.png" style="top:37.39%; left:62.69%; width:33.14%; z-index:-1; border-radius:10px;" /> -->


<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Testable Code -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs\pic03.png" style="top:42%; left:33%; width:35%; z-index:-1; border-radius:10px;" /> -->


<!-- attr: { id: 'testable', showInPresentation:true, hasScriptWrapper:true } -->
# <a id="testable"></a>How to Write Testable Code
- Inversion of Control Pattern
  - There is a decoupling of the execution of a certain task from implementation
  - Every module can focus on what it is designed for
  - Modules make no assumptions about what other systems do but rely on their contracts
  - Replacing modules has no side effect on other modules
  - More info at http://en.wikipedia.org/wiki/Inversion_of_control 


<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# How to Write Testable Code
- Public API should work with interfaces, not implementation classes (IEnumerable vs. List)
- Bad code:

```cs
public Card[] Cards { get; private set; }
```

- Good code:

```cs
public IList<ICard> Cards { get; private set; }
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# Dependency Injection
- IoC Containers
  - [Ninject](http://www.ninject.org/) 
  - [Unity]( https://msdn.microsoft.com/en-us/library/dn223671(v=pandp.30&rpar;.aspx )
- Consists of:
  - A dependent consumer
  - A declaration of a component's dependencies, defined as interface contracts
  - An injector (sometimes referred to as a provider or container) that creates instances of classes that implement a given dependency interface on request


<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# How to Write Testable Code
- Bad:

```cs
public interface IViewBase {}
public interface IPresenterBase {}
public class MemoryLayoutView: IViewBase {}

public class MemoryLayoutPresenter: IPresenterBase
{
    private MemoryLayoutView view = new MemoryLayoutView();
    public MemoryLayoutPresenter() { }
}
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.92em' } -->
# How to Write Testable Code
- Good:

```cs
public interface IViewBase {}
public interface IPresenterBase {}
public class MemoryLayoutView: IViewBase {}
public class MemoryLayoutPresenter : IPresenterBase
{
  private IViewBase view;
  public MemoryLayoutPresenter(IViewBase myView) 
  {
    this.view = myView;
  }
}
public class Program {
  static void Main() {
    InjectionContainer.Create<typeof(MemoryLayoutPresenter)>();
  }
}
```



<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Faking
## Fakes, Mocks, Stubs -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs\pic04.png" style="top:52%; left:34.49%; width:30%; z-index:-1; border-radius:10px;" /> -->


<!-- attr: { id:'fakes', showInPresentation:true, hasScriptWrapper:true } -->
# <a id="fakes"></a>Faking
- Makes Unit Testing more effective
  - Avoid writing boring boilerplate code
- Isolate dependencies among units
- Asserts expectations for code quality
  - Ex: Checks that a method is called only once

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# Fake vs Mock vs Stub

- **Fake** - objects actually have working implementations but with limited capabilities.

- **Stub** - provide canned answers to calls made during the test. May record information about calls.

- **Mock** - objects pre-programemd with expectations against we can assert


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Isollation frameworks
## Mocking -->



<!-- attr: { id:'isollation', showInPresentation:true, hasScriptWrapper:true } -->
<!-- # <a id="isollation"></a>Hand written mock -->

- You can use inheritance to replace logic
  - Maintainability - hard to achieve it
  - Gets really complicated
  - Could lead to errors

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Frameworks -->

- Could create fake objects
- Set the desired behaviour of the objects
- **Verify (Assert)** against the fake objects

<!-- attr: {  showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Constrained vs Unconstrained -->

- **Constrained** frameworks usually work by generating code at runtime that inherits and overrides interfaces or base classes
- In .NET, constrained frameworks are unable to fake:
  - **static methods**
  - **nonvirtual methods**
  - **nonpublic methods**
  - **and more**

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Constrained vs Unconstrained -->

- **Unconstrained** frameworks could be used as **constrained** as well
- Using unconstrained isolation frameworks has some advantage
  - You can write unit tests for previously untestable code
  - You can fake third-party systems that you can’t control 
  - If you don’t pay close attention, some tests can become unmaintainable


<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Moq -->

<!-- <img class="slide-image" showInPresentation="true" src="imgs\pic05.png" style="top:42%; left:35%; width:30%; z-index:-1; border-radius:10px;" /> -->


<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# Moq
- Install from the NuGet package manager
- Refer the library
- Use its API
- https://github.com/Moq/moq4 


<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# Moq syntax
- The most often used APIs:
  - **.Setup()**
  - **.Verifiable()**
  - **.Callback()**
  - **.Returns()**
  - **.Throws()**
  - **It.Is<type>(x => condition)**



<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
<!-- # JustMock -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs\pic06.png" style="top:32.62%; left:17.78%; width:68.76%; z-index:-1; border-radius:10px;" /> -->


<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# JustMock
- Use the Visual Studio NuGet package manager

- Two versions:
  - Free version (**constrained**)
  - Paid version  (**unconstrained**)


<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# JustMock syntax
- The most often used APIs:
  - **.CallOriginal()**
  - **.Returns()**
  - **.DoInstead()**
  - **.DoNothing()**
  - **.Throw()**
  - **Arg.Matches<type>(x => condition)**


<!-- attr: { id:'', class:'slide-section',showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Other frameworks -->

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Other frameworks -->
- Constrained
  - **FakeItEasy**
  - **nSubstitute**
  - **RhinoMocks**

- Unconstrained
  - **Isolator**
  - **MS Fakes**

<!-- section start -->
<!-- attr: { hasScriptWrapper:true, class:"slide-section", showInPresentation: true } -->
<!-- # Isolation techniques
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



