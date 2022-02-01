module Dsl

type Attributes = (string * string) seq

let tagEmpty name attrs =
    let attrsToString =
        attrs
        |> Seq.map (fun (a, b) -> $" {a}=\"{b}\"")
        |> String.concat ""
    $"<{name}{attrsToString} />"

let tag (name : string) (attrs : Attributes) (content : string) : string =
    let attrsToString =
        attrs
        |> Seq.map (fun (a, b) -> $" {a}=\"{b}\"")
        |> String.concat ""
    $"<{name}{attrsToString}>\n{content}\n</{name}>"

let tagList name attrs (list : string seq) =
    let inner = list |> String.concat "\n"
    tag name attrs inner


// big tags

let html attrs list = tagList "html" attrs list

let body attrs list = tagList "body" attrs list

let header attrs list = tagList "header" attrs list

let div attrs list = tagList "div" attrs list

// content ones

let title attrs contents = tag "title" attrs contents

let img (attrs : Attributes) (src : string) =
    attrs
    |> Seq.append [ "src", src ]
    |> tagEmpty "img"

let h3 attrs contents = tag "h3" attrs contents

let style (attrs : Attributes) =
    let inner =
        attrs
        |> Seq.map (fun (a, b) -> $"{a}: {b};")
        |> String.concat ""
    "style", $"{inner}"

let a (attrs : Attributes) href =
    attrs
    |> Seq.append [ "href", href ]
    |> tag "a"
