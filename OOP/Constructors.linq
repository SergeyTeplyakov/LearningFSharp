<Query Kind="FSharpProgram" />


//-----------------------------------------------------------------------
// Type without constructor
//-----------------------------------------------------------------------

// Using explicit constructor syntax even default constructor should be 
// defined explicitely
type PointWithoutCtor = 
    val x: int
    val y: int
    
let pointType = typeof<PointWithoutCtor>
printfn "Constructors count in PointWithoutCtor type: %d" (pointType.GetConstructors().Length)