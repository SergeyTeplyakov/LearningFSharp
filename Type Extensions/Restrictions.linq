<Query Kind="FSharpProgram" />

// It is impossible to extend "cosed constructed types" like Ref<int> or Seq<string> in F#.
// This means that following code wan't compile!

type Ref<'a when 'a :> string> with
    member x.Foo() =
    ()