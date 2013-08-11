<Query Kind="FSharpProgram" />

open System

// Extensions for System.Int32
type Int32 with
	
    // Add enumerator to the int value.
    // Than we can use it with "for n in 5 do printfn "%d " n"
    member x.GetEnumerator() =
        {1..x}.GetEnumerator()
    
	// Int.FromString string -> int option
	static member FromString(s: string) =
		match Int32.TryParse(s) with
		| (true, v) -> Some(v)
		| (false, _) -> None
	
	// Return string representation in hexademical form
	member this.ToHex() =
		this.ToString("X")
	
	// Return string representation in hexademical form (from property)
	member this.Hex with get() = this.ToHex()
	
	// Static identifier
	static member InvalidId = -1

//-----------------------------------------------------------------------
// Extending for loop
//-----------------------------------------------------------------------
for n in 5 do printf "%d " n

//-----------------------------------------------------------------------
// Using static extension method
//-----------------------------------------------------------------------
let i1 = Int32.FromString("42")
i1.Dump()

let i2 = Int32.FromString("Foo")
i2.Dump()

//-----------------------------------------------------------------------
// Using static extension property
//-----------------------------------------------------------------------
Int32.InvalidId.Dump()

//-----------------------------------------------------------------------
// Using instance extension methods and properties
//-----------------------------------------------------------------------
let n = 42
n.ToHex().Dump()
n.Hex.Dump()