module ListBuilder

type ListBuilder<'a> () =
    member _.Yield el = [ el ]

    member _.Delay f = f ()

    member _.Combine (a, b) =
        List.append a b
    
    member _.For (seq, f) =
        seq |> Seq.map f |> Seq.collect id |> List.ofSeq

let inline lst<'a> () = ListBuilder<'a> ()

let l = lst() {
    3
    6
}