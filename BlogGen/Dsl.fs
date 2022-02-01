module Dsl

type Attributes = (string * string) seq

let tagEmpty name attrs =
    let attrsToString =
        attrs
        |> Seq.map (fun (a, b) -> $" {a}=\"{b}\"")
        |> String.concat ""
    $"<{name}{attrsToString} />"

let tag (name : string) (attrs : Attributes) (content : string) : string =
    let indented = content.Replace("\n", "\n    ")
    let attrsToString =
        attrs
        |> Seq.map (fun (a, b) -> $" {a}=\"{b}\"")
        |> String.concat ""
    $"<{name}{attrsToString}>{indented}</{name}>"

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

let h1 attrs contents = tag "h1" attrs contents

let h2 attrs contents = tag "h2" attrs contents

let h3 attrs contents = tag "h3" attrs contents

let span attrs list = tagList "span" attrs list

let p attrs contents = tag "p" attrs contents

let style attrs (classes : string seq) = tag "style" attrs (String.concat "" classes)

let inplaceStyle (attrs : Attributes) =
    let inner =
        attrs
        |> Seq.map (fun (a, b) -> $"{a}: {b};")
        |> String.concat ""
    "style", $"{inner}"

let a (attrs : Attributes) href =
    attrs
    |> Seq.append [ "href", href ]
    |> tag "a"

let link (attrs : Attributes) = tagEmpty "link" attrs

let cssFilter filter attrs =
    let inner =
        attrs
        |> Seq.map (fun (a, b) -> $"{a}: {b};")
        |> String.concat "\n"
    $"{filter} {{\n{inner}\n}}\n"

let cssClass name attrs = cssFilter $".{name}" attrs

let theme themeName attrs =
    let inner = attrs |> String.concat ""
    $"@media (prefers-color-scheme: {themeName}) {{\n{inner}\n}}"

let lightTheme attrs = theme "light" attrs

let darkTheme attrs = theme "dark" attrs