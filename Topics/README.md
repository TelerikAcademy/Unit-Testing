# Unit testing - Succinctly

## The definition of a unit test (_by Roy Osherove_)

#### Prerequisites   
A _**unit of work**_ is the sum of actions that take place between the invocation of a public method in the system and a single noticeable end result by a test of that system. A noticeable end result can be observed without looking at the internal state of the system and only through its public APIs and behavior. An end result is any of the following:
 - The invoked public method returns a value (a function that’s not void).  
 - There’s a noticeable change to the state or behavior of the system before and after invocation that can be determined without interrogating private state.  
 - There’s a callout to a third-party system over which the test has no control, and that third-party system doesn’t return any value, or any return value from that system is ignored. (Example: calling a third-party logging system that was not written by you and you don’t have the source to.)  

#### Definition  
A **unit test** is a piece of code that invokes a **unit of work** and checks one specific end result of that unit of work. If the assumptions on the end result turn out to be wrong, the unit test has failed. A unit test's scope can span as little as a method or as much as multiple classes.

## The properties of a good unit test (_by Donald Belcham_)
_A unit test should be:_  

  - _**Atomic**_ - a unit test should test **one small piece of functionality**.
  - _**Deterministic**_ - a unit test should **always** either **pass or fail** and should never be inconclusive.
  - _**Repeatable**_ - a unit test is repeatable, when it passes consistently. If a test passes, and then fails without changing the test or any of the dependent code, then it is not repeatable.
  - _**Order independent & Isolated**_ - a test should not be required to run in any specific order to pass, and that other tests or external forces should not affect your unit test ability to pass.
  - _**Fast**_ - when I say fast, I mean **really fast**. If a unit test takes 1 second to run - this is slow. A unit test should take **milliseconds** to run.
  - _**Easy to setup**_ - if you have to do a lot of coding, just to get the test setup and ready to run - there should be a better way to do things.

## The properties of a good unit test (_by Roy Osherove_)

 - _**It should be automated and repeatable**_
 - _**It should be easy to implement**_
 - _**It should run quickly**_
 - _**It should be relevant tomorrow**_
 - _**Anyone should be able to run it at the push of a button**_
 - _**Consistent in its results** (it always returns the same result if you don't change anything between test runs)_
 - _**It should have full control of the unit under test**_
 - _**It should be fully isolated** (runs independently of other tests)_
 - _**When it fails, it should be easy to detect what was expected and determine how to pinpoint the problem**_

## What is Mocking?

#### Prerequisites

If you look up the noun _**mock**_ in the dictionary you will find that one of the definitions of the word is "_**something made as an imitation**_".

#### Definition

Mocking is primarily used in unit testing. An **object under test** may have **dependencies on other (complex) objects**. In order to **isolate the behavior of the object you want to test**, you **replace** the other objects(dependencies) with _**mocks**_ that **simulate** the behavior of the real objects. This is useful when the real objects are impractical to incorporate into the unit test, or when the real objects might change some sensitive system state or data, and we want to avoid messing things up.    

In short, mocking is a technique used for creating fake objects that simulate the behavior of the real objects, in order for us to have _**full control**_ over the _**unit**_ that is under test.  

## Extras

 - Unit testing, and particularly the Test-Driven-Development is a **design** process, **not** a **testing** process. TDD is a robust way of designing software components (“units”) interactively so that their behavior is specified through unit tests.
