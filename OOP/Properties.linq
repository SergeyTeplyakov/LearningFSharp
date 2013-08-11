<Query Kind="FSharpProgram" />

type TypeWithProperties(x: string) =
    // Readonly Property that initialized from constructor
    member val Name = x
    // Readonly Property with default value
    member val DefaultName = "Default Name value"
    // Another form of readonly property
    member val Foo = 42 with get
    
    // I don't know is it possible
    // Readonly property without explicit default value
    //member val Boo: int with get
    
    // Read-Write property with default value
    member val Text = "" with get, set
    // Read-Write DateTime property with complex default value
    member val Now = DateTime.Now with get, set
    
//    member val YetAnotherProp with get() = "foo"
    
    
let t = TypeWithProperties("John Doe")

// Playing with Name property
printfn "Name is %s" t.Name
let nameProp = t.GetType().GetProperty("Name")
printfn "Is Name property readable? %b" nameProp.CanRead // True
printfn "Is Name property wridable? %b" nameProp.CanWrite // False

// Playing with Text property
printfn "Text is \"%s\"" t.Text
t.Text <- "Custom Text"
printfn "Text after mutation is \"%s\"" t.Text