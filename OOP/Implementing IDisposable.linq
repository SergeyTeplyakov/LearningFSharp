<Query Kind="FSharpProgram" />

// In F# 
type CustomDisposable() =
    do
        printfn "CustomDisposable.ctor"
    
    interface IDisposable with
        member x.Dispose() = printfn "CustomDisposable.Dispose"
        
let sample() =
    printfn "before new CustomDisposable()"
    use cs = new CustomDisposable()
    printfn "using CustomDisposable"
    
sample()
printfn "After calling sample()"