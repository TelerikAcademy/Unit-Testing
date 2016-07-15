<!-- section start -->
# Mocking with Moq and JustMock
## Mocking tools for easier unit testing
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic00.png" style="top:11.46%; left:7.49%; width:21.94%; z-index:-1" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic01.png" style="top:52.11%; left:57.08%; width:47.62%; z-index:-1" /> -->
<div class="signature">
	<p class="signature-course">- High Quality Code</p>
	<p class="signature-initiative">- Telerik Software Academy</p>
	<a href="- http://academy.telerik.com " class="signature-link">- http://academy.telerik.com </a>
</div>

<!-- section start -->
# Table of Contents
- Testable Code
- Mocking
- Moq
  - Moq demo
- JustMock
  - JustMock demo
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic02.png" style="top:37.39%; left:62.69%; width:33.14%; z-index:-1" /> -->

<!-- section start -->
# Testable Code
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic03.png" style="top:28.21%; left:29.01%; width:51.13%; z-index:-1" /> -->

# How to Write Testable Code
- Inversion of Control Pattern
  - There is a decoupling of the execution of a certain task from implementation
  - Every module can focus on what it is designed for
  - Modules make no assumptions about what other systems do but rely on their contracts
  - Replacing modules has no side effect on other modules
  - More info at http://en.wikipedia.org/wiki/Inversion_of_control 

# How to Write Testable Code
- Public API should work with interfaces, not implementation classes (IEnumerable vs. List)
- Bad code:
- Good code:

# How to Write Testable Code
- Dependency Injection
  - Ninject – http://www.ninject.org/ 
- Consists of:
  - A dependent consumer
  - A declaration of a component's dependencies, defined as interface contracts
  - An injector (sometimes referred to as a provider or container) that creates instances of classes that implement a given dependency interface on request

# How to Write Testable Code
- Bad:

# How to Write Testable Code
- Good:

<!-- section start -->
# Mocking
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic04.png" style="top:27.33%; left:36.49%; width:37.02%; z-index:-1" /> -->

# Mocking
- Makes Unit Testing more effective
  - Avoid writing boring boilerplate code
- Isolate dependencies among units
- Asserts expectations for code quality
  - Ex: Checks that a method is called only once

<!-- section start -->
# Moq
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic05.png" style="top:28.21%; left:32.75%; width:44.08%; z-index:-1" /> -->

# Moq
- Install from the NuGet package manager
- Refer the library
- Use its API
- https://github.com/Moq/moq4 

# Moq
- The most often used APIs:
  - .Setup()
  - .Verifiable()
  - .Callback()
  - .Returns()
  - .Throws()
  - It.Is<type>(x => condition)

<!-- section start -->
# Telerik JustMock
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic06.png" style="top:32.62%; left:17.78%; width:68.76%; z-index:-1" /> -->

# Telerik JustMock
- Install from the Telerik account
  - http://www.telerik.com/products/mocking.aspx
- Use the Visual Studio NuGet package manager

# Telerik JustMock
- Two versions:
  - Free version – excellent when the code is written with testability in mind
  - Paid version – mocks everything (mscorlib, EntityFramework, SQL), legacy code base which is not written to be testable, statics, privates, etc.
- More information here:
  - http://www.telerik.com/help/justmock/getting-started-commercial-vs-free-version.html

# Telerik JustMock
- The most often used APIs:
  - .CallOriginal()
  - .Returns()
  - .DoInstead()
  - .DoNothing()
  - .Throw()
  - Arg.Matches<type>(x => condition)

# Mocking
## [Demo]()
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic07.png" style="top:17.63%; left:31.56%; width:46.31%; z-index:-1" /> -->

# Mocking with Moq and JustMock

```js
http://academy.telerik.com
```

# Free Trainings @ Telerik Academy
- C# Programming @ Telerik Academy
    - csharpfundamentals.telerik.com
  - Telerik Software Academy
    - academy.telerik.com
  - Telerik Academy @ Facebook
    - facebook.com/TelerikAcademy
  - Telerik Software Academy Forums
    - forums.academy.telerik.com
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic08.png" style="top:60.37%; left:92.39%; width:13.45%; z-index:-1" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic09.png" style="top:30.85%; left:68.14%; width:36.30%; z-index:-1" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic10.png" style="top:46.32%; left:95.14%; width:10.85%; z-index:-1" /> -->
<!-- <img class="slide-image" showInPresentation="true" src="imgs/pic11.png" style="top:13.00%; left:92.85%; width:13.01%; z-index:-1" /> -->
