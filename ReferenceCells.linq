<Query Kind="FSharpProgram" />

// Declaration (allowed for ref and val types)

//-----------------------------------------------------------------------
// Creating new reference cells
//-----------------------------------------------------------------------
// ref is a method that return new instance of the reference cell
let refString = ref "foo"
let refInt = ref 42
// Reference cells are records so we can create them using records expression
let refDt = {contents = DateTime.Now}

//-----------------------------------------------------------------------
// Modification
//-----------------------------------------------------------------------
refString := "New value"
refInt.Value <- refInt.Value + 1
refString.contents = "empty:)"

//-----------------------------------------------------------------------
// Getting value
//-----------------------------------------------------------------------
printfn "refString is %s" !refString
printfn "refInt is %d" refInt.Value
printfn "ref string is %s" refString.contents

//-----------------------------------------------------------------------
// Passing by reference
//-----------------------------------------------------------------------

// int byref is similar to byref<int>
let increment(x: int byref) =
	x <- x + 1

type C() =
	static member public Increment(x: byref<int>) =
		x <- x + 1
		
let v = ref 42
// increment(v) // Not allowed (WTF) (hint: stackoverflow.com/questions/14526854/why-am-i-not-allowed-to-use-reference-cell-as-arguemnt-for-byref-parameter-in-le)
increment(&v.contents)
C.Increment(v) // Allowed (OK), v = 43
C.Increment(ref 42) // Allowed (WTF)

let mutable b = 30
increment(&b) // b = 31
C.Increment(&b) // b = 32

//-----------------------------------------------------------------------
// Reference cells and closures
//-----------------------------------------------------------------------
// We can't closed over local mutable values. We should use reference cells in this case.

type T() =
	let mutable counter = 0
	
	member public x.GetIncrementor() =
		// We can capture mutable field
		fun unit -> counter <- counter + 1; counter
		
	member public x.GetLocalIncrementor() =
		// But we can't capture mutable locals
		// let mutable lCounter = 0 // Wan't compile!
		let lCounter = ref 0
		fun unit -> lCounter := !lCounter + 1; !lCounter

let t = T()
let incrementor = t.GetIncrementor()
printfn "incrementor(): %d" (incrementor()) // will print 1

let localIncrementor = t.GetLocalIncrementor()
printfn "localIncrementor(): %d" (localIncrementor()) // will print 1

//-----------------------------------------------------------------------
// Custom reference cell
//-----------------------------------------------------------------------
//// Custom reference cell (similar to original one)
//// TODO create all additional operators!!!
//type CustomRef<'a> = {mutable Content: 'a} with
//	member public this.Value with get() = this.Content and set c = this.Content <- c
//	
//let cr = {Content = 42}
//
//// Closing over custom ref cell
//let increment() = cr.Value <- cr.Value + 1
//
//cr.Content.Dump() // 42
//increment()
//cr.Content.Dump() // 43

//refString.GetType().GetMethods() |> Seq.map(fun f -> f.Name) |> Dump