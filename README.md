# Xunit.Categories
Friendlier attributes to help categorize your tests. 

## Messy Traits?
The xUnit built in option *Traits* can get a little messy. Its just 2 strings representing a key and value, unless you are familiar with xUnit and the Trait attribute it looks a little magical.

Also both key and value must be specified on the command line. This means if you decorate your test with 
`[Trait("Category","Bug")]` you cannot run only tests from a specific bug without adding another trait `([Trait("Bug","8675309"])`

## Friendly Attributes Included
- Category 
- Feature
- User Story
- Bug
- Integration Test
- Unit Test
- Exploratory
- Documentation
- Known Bug
- Work Item
- System Test
- Test Case
- Database Test
- Snapshot Test
- Expensive
- Author
- Description

Open an issue or pull request to add more.


## Example

```csharp
[Fact]
[Bug]
public void TestBug()
{
    throw new NotImplementedException("I'm a bug");
}

[Fact]
[Bug("777")]
public void TestBugWithId()
{
    throw new NotImplementedException("I've got your number");
}
```

Using this attribute you get descriptive information and flexibility when running tests. 
You can run all tests marked as Bugs

```bat
xunit.console.exe ... -trait "Category=Bug"

-or via dotnet test

dotnet test --filter "Category=Bug" 
```

or get more granular
```bat
xunit.console.exe ... -trait "Bug=777"

-or via dotnet test
dotnet test --filter "Bug=777" 
```
