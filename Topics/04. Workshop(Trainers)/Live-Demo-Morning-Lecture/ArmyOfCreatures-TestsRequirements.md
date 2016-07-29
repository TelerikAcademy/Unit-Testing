# Tests Requirements

## Class - ArmyOfCreatures.Console.Commands.AddCommand

### Test cases:

 - ProcessCommand should throw ArgumentNullException, when the "IBattleManager battleManager" is null.
 - ProcessCommand should throw ArgumentNullException, when the "params string[] arguments" is null.
 - ProcessCommand should throw ArgumentNullException, when the number of "params string[] arguments" is invalid (lower than 2).
 - ProcessCommand should call IBattleManager.AddCreatures(), when the command is parsed successfully.

## Class - ArmyOfCreatures.Logic.Specialties.DoubleDefenseWhenDefending

### Test cases:

 - ApplyWhenDefending should throw ArgumentNullException, when the "ICreaturesInBattle defenderWithSpecialty" is null.
 - ApplyWhenDefending should throw ArgumentNullException, when the "ICreaturesInBattle attacker" is null.
 - ApplyWhenDefending should return and not change the CurrentDefense property of "defenderWithSpecialty", when the effect is expired.
 - ApplyWhenDefending should multiply by 2 the CurrentDefense property of "defenderWithSpecialty", when the effect has not expired.  

## Class - ArmyOfCreatures.Extended.BattleManagerWithThreeArmies

### Test cases:

 - Constructor should call base() constructor and instantiate the object with all properties set up. (Use C# integrated PrivateObject class, to expose private fields, so that you can assert, that the object was instantiated properly).

## Class - ArmyOfCreatures.Extended.ExtendedCreaturesFactory

### Test cases:

 - CreateCreature should throw ArgumentException with message that contains the string "Invalid creature type", when a string representing non-existing creature type is passed as a method argument.
 - CreateCreature should return the corresponding creature type based on the string that is passed as a method argument. Test with (AncientBehemoth, CyclopsKing, Goblin, Griffin, WolfRaider, and something else for the default case).

## Class - ArmyOfCreatures.Logic.Battles.BattleManager

### Test cases:

 - Add creatures should throw ArgumentNullException, when Identifier is null
 - Add creatures should call CreteCreature from factory
 - Add creatures should call WriteLine from Logger
 - Adding creature to Army 3 (not existing) should throw ArgumentException
 - Attacking with null identifier should throw ArgumentNullException
 - Attacking with null unit should throw ArgumentException
 - Attacking successful should call WriteLine from Logger exactly 4 times
 - Attacking with two Behemoths should return right result (two Behemoths attack 1 Behemoth and the expected result is 56) -  could be tried with all the other creatures

## Class - ArmyOfCreatures.Logic.Battles.CreatureIdentifier

### Test cases:

  - Call with null valueToParse should throw ArgumentNullException
  - Call with invalid Army number (ex: Angel(test)) test cannot be parsed should throw FormatExcepition
  - Call with invalid string (without brackets to split) should throw IndexOutOfRangeException
  - ToString should output expected result


## Class -ArmyOfCreatures.Logic.Battles.CreaturesInBattle

### Test cases:

  - Deal Damage with null defender should throw ArgumentNullException
  - Deal Damage should return expected result
  - Skip should call ApplyOnSkip  the count of the specialties times (think about how to make it)
  - ToString should output expected result
